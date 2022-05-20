using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuestionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Subject = _db.subjects.ToList();
            IEnumerable<Question> objQuestionList = _db.questions;
            return View(objQuestionList);
        }

        //CREATE SECTION

        //GET
        public IActionResult Create()
        {
            ViewBag.Subject = _db.subjects.ToList();
            ViewBag.Questions = _db.questions.ToList();
            ViewBag.Anwsers = _db.anwsers.ToList();
            return View();
        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateQuestion(DualModel obj)
        {

            if (ModelState.IsValid)
            {

                _db.questions.Add(obj.question);
                _db.SaveChanges();
                TempData["success"] = "Question created succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Question creation failed";
            }
            return View(obj);


        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnwser(DualModel obj)
        {

            if (ModelState.IsValid)
            {
                _db.anwsers.Add(obj.anwser);
                _db.SaveChanges();
                TempData["success"] = "Anwser created succesfully";
                return RedirectToAction("Create", "Questions");
            }
            else
            {
                TempData["error"] = "Anwser creation failed";
            }
            return RedirectToAction("Create", "Questions");


        }






        //EDIT SECTION

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DualModel num = new DualModel();
            num.question = _db.questions.Find(id);

            num.anwser = _db.anwsers.FirstOrDefault(u => u.questionId == id);

            if (num.question == null)
            {
                return NotFound();
            }

            if (num.anwser == null)
            {
                return NotFound();
            }
            ViewBag.Subject = _db.subjects.ToList();
            ViewBag.Questions = _db.questions.ToList();

            return View(num);
        }



        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DualModel obj)
        {

            if (ModelState.IsValid)
            {
                _db.questions.Update(obj.question);
                _db.anwsers.Update(obj.anwser);
                _db.SaveChanges();
                TempData["success"] = "Question updated succesfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Question update failed";
            }
            return View(obj);


        }






        //DELETE SECTION

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var questionFromDb = _db.questions.Find(id);

            if (questionFromDb == null)
            {
                return NotFound();
            }

            ViewBag.Subject = _db.subjects.ToList();

            return View(questionFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.questions.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.questions.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Question deleted succesfully";
            return RedirectToAction("Index");

        }

        //GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.questions == null)
            {
                return NotFound();
            }

            var question = await _db.questions
                .FirstOrDefaultAsync(m => m.id == id);
            if (question == null)
            {
                return NotFound();
            }

            ViewBag.Subject = _db.subjects.ToList();

            return View(question);
        }

        public IActionResult LoadFromDb()
        {
            IEnumerable<Question> objQuestionList = _db.questions;
            return View(objQuestionList);
        }

    }

}
