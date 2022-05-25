using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Controllers
{

    public class QuestionsController : Controller
    {
        public static string questionName;
        public static Nullable<int> subjectId;

        private readonly ApplicationDbContext _db;

        public QuestionsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Users = _db.users.ToList();
            ViewBag.Subject = _db.subjects.ToList();
            IEnumerable<Question> objQuestionList = _db.questions;
            return View(objQuestionList);
        }

        //CREATE SECTION

        //GET
        public IActionResult Create()
        {
            ViewBag.questionText = questionName;
            ViewBag.subjectId = subjectId;
            ViewBag.Subject = _db.subjects.ToList();
            ViewBag.Questions = _db.questions.ToList();
            ViewBag.Anwsers = _db.anwsers.ToList();
            return View();
        }

        public IActionResult CreateFromQuiz()
        {
            ViewBag.questionText = questionName;
            ViewBag.subjectId = subjectId;
            ViewBag.Subject = _db.subjects.ToList();
            ViewBag.Questions = _db.questions.ToList();
            ViewBag.Anwsers = _db.anwsers.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFromQuiz(DualModel obj)
        {
            questionName = null;
            subjectId = null;
            if (ModelState.IsValid)
            {

                _db.questions.Add(obj.question);
                _db.SaveChanges();
                TempData["success"] = "Question created succesfully";
                return RedirectToAction("Create", "Quizzes");
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
        public IActionResult CreateQuestion(DualModel obj)
        {

            questionName = null;
            subjectId = null;
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
                questionName = obj.question.text;
                subjectId = obj.question.subjectId;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAnwserFromQuiz(DualModel obj)
        {

            if (ModelState.IsValid)
            {
                questionName = obj.question.text;
                subjectId = obj.question.subjectId;
                _db.anwsers.Add(obj.anwser);
                _db.SaveChanges();
                TempData["success"] = "Anwser created succesfully";
                return RedirectToAction("CreateFromQuiz", "Questions");
            }
            else
            {
                TempData["error"] = "Anwser creation failed";
            }
            return RedirectToAction("CreateFromQuiz", "Questions");


        }

        public IActionResult CreateAnwserQuestion(DualModel obj)
        {

            if (ModelState.IsValid)
            {
                questionName = obj.question.text;
                subjectId = obj.question.subjectId;
                _db.anwsers.Add(obj.anwser);
                _db.SaveChanges();
                TempData["success"] = "Anwser created succesfully";
                return RedirectToAction("Create", "Questions");
            }
            else
            {
                TempData["error"] = "Anwser creation failed";
            }
            return RedirectToAction("Create", "Questions", new { id = obj.question.id });


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
            num.anwser = new Anwser(0, "dummy", 0, false);

            if (num.question == null)
            {
                return NotFound();
            }

            if (num.anwser == null)
            {
                return NotFound();
            }
            ViewBag.Subject = _db.subjects.ToList();
            ViewBag.Anwsers = _db.anwsers.ToList();
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

            _db.anwsers.RemoveRange(_db.anwsers.Where(x => x.questionId == id));
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

        //GET
        public IActionResult LoadFromDb(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.quizzes.Find(id);
            if (obj == null)
            {
                ViewBag.Exist = false;
            }
            else
            {
                ViewBag.Exist = true;
            }

            ViewBag.QuizQuestions = _db.quizQuestions.ToList();
            ViewBag.QuizId = id;
            ViewBag.Subjects = _db.subjects.ToList();
            ViewBag.Users = _db.users.ToList();
            IEnumerable<Question> objQuestionList = _db.questions;
            return View(objQuestionList);
        }

        //POST
        public IActionResult AddToQuiz(int idQuiz, int idQuestion)
        {

            foreach (QuizQuestions item in _db.quizQuestions)
            {
                if (item.questionId == idQuestion && item.quizId == idQuiz)
                {
                    TempData["error"] = "Question already in Quiz";
                    return RedirectToAction("LoadFromDb", new { id = idQuiz });
                }
            }
            if (idQuestion == null || idQuestion == 0 || idQuiz == null || idQuiz == 0)
            {
                return NotFound();
            }


            TempData["success"] = "Question added to Quiz";
            _db.quizQuestions.Add(new QuizQuestions { questionId = idQuestion, quizId = idQuiz });
            _db.SaveChanges();

            return RedirectToAction("LoadFromDb", new { id = idQuiz });

        }


    }
}
