using System;
using Microsoft.AspNetCore.Mvc;
using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;

namespace ADOPSEV1._1.Controllers
{
    public class LessonsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LessonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Lessons
        public async Task<IActionResult> Index()
        {
            
            IEnumerable<Lesson> allLessons = _context.lessons;
            return View(allLessons);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int lessonInput)
        {
            int users;
            string usr;
            if (User.Identity.IsAuthenticated)
            {
                usr = User.Identity.Name;
                users = _context.users.Where(u => u.username == usr).Select(u => u.id).FirstOrDefault();
                _context.userConnectsSubjects.Add(new UserConntectsSubject { lessonId = lessonInput, userId = users });
                _context.SaveChanges();
            }
            IEnumerable<Lesson> allLessons = _context.lessons;

            //_context.userConnectsSubjects.Add(new UserConntectsSubject { userId = 5, lessonId = lessonid.ToString() });
            
            return View("Index", allLessons);
        }

       

       
      
    

    }
}
