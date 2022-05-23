using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ADOPSEV1._1.Controllers
{
    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {

            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.Quizzes = _db.quizzes.ToList();
            ViewBag.Subjects = _db.subjects.ToList();
            ViewBag.Users = _db.users.ToList();
            ViewBag.QuizQuestions = _db.quizQuestions.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

