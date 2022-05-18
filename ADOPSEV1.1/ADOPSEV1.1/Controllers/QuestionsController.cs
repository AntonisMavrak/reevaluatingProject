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
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Question obj)
        {

            if (ModelState.IsValid)
            {
                _db.questions.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Question created succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }






        //EDIT SECTION

        //GET
        public IActionResult Edit(int? id)
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
        public IActionResult Edit(Question obj)
        {

            if (ModelState.IsValid)
            {
                _db.questions.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Question updated succesfully";
                return RedirectToAction("Index");
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
