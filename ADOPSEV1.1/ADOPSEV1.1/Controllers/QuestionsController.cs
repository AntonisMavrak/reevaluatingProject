using ADOPSEV1._1.Data;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

    }
}
