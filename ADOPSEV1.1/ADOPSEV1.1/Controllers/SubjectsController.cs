using ADOPSEV1._1.Data;
using Microsoft.AspNetCore.Mvc;

namespace ADOPSEV1._1.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SubjectsController(ApplicationDbContext db)
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
