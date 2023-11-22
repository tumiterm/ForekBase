using ForekBase.Application.Common.Interfaces;
using ForekBase.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ForekBase.Web.Controllers
{
    public class QuestionsController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;

        public QuestionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var questions = _unitOfWork.Question.GetAll(includeProperties: "Survey");

            return View(questions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question question)
        {
            //bool questionExist = _unitOfWork.Question.Any(q => q.Id == question.Id);

            if (ModelState.IsValid)
            {
                _unitOfWork.Question.Add(question);

                _unitOfWork.Save();

                TempData["success"] = "Saved successfully";

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Update(int QuestionId)
        {
            Question? question = _unitOfWork.Question.Get(u => u.Id == QuestionId);

            if (question == null)
            {
                return RedirectToAction("Whatever");
            }
            return View(question);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Question question)
        {
            if(ModelState.IsValid) 
            { 
                _unitOfWork.Question.Update(question);

                _unitOfWork.Save();

                TempData["success"] = "Saved successfully";

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
    }
}
