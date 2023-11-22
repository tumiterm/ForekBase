using ForekBase.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForekBase.Web.Controllers
{
    public class SurveyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SurveyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var surveys = _unitOfWork.Survey.GetAll();

            return View(surveys);
        }
    }
}
