﻿using ForekBase.Application.Common.Interfaces;
using ForekBase.Application.Common.Utility;
using ForekBase.Domain.Entities;
using ForekBase.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ForekBase.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        public IActionResult Login(string returnUrl=null)
        {
            returnUrl??= Url.Content("~/");

            LoginVM loginVM = new()
            {
                RedirectUrl = returnUrl,
            };

            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password,
                                                                      loginVM.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(loginVM.RedirectUrl))
                    {
                        return RedirectToAction("Whatever", "Wherever");

                    }
                    else
                    {
                        return LocalRedirect(loginVM.RedirectUrl);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login Attempt");
                }

            }

            return View(loginVM);
        }

        public IActionResult Register()
        {
            if(!_roleManager.RoleExistsAsync(Permissions.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new IdentityRole(Permissions.Role_Admin)).Wait();

                _roleManager.CreateAsync(new IdentityRole(Permissions.Role_SuperAdmin)).Wait();
            }

            RegisterVM registerVM = new()
            {
                RoleList = _roleManager.Roles.Select(x => new SelectListItem
                {
                    Text = x.Name,

                    Value = x.Id
                })
            };

            return View(registerVM);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {

            ApplicationUser user = new()
            {
                Name = registerVM.Name, 

                Email = registerVM.Email,

                PhoneNumber = registerVM.PhoneNumber,

                NormalizedEmail = registerVM.Email.ToUpper(),

                EmailConfirmed = true,

                UserName = registerVM.Email,

                CreatedOn = DateTime.Now,
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded) 
            {
                if(!string.IsNullOrEmpty(registerVM.Role)) 
                { 
                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, Permissions.Role_Unknown);   
                }

                await _signInManager.SignInAsync(user, isPersistent: false);

                if(string.IsNullOrEmpty(registerVM.RedirectUrl)) 
                {
                    return RedirectToAction("Whatever", "Wherever");

                }
                else
                {
                    return LocalRedirect(registerVM.RedirectUrl);
                }

            }

            foreach(var error in result.Errors) 
            {
                ModelState.AddModelError("", error.Description);
            }


            registerVM.RoleList = _roleManager.Roles.Select(x => new SelectListItem
            {
                Text = x.Name,

                Value = x.Id
            });
            

            return View(registerVM);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Whatever", "Whenever");
        }
    }
}
