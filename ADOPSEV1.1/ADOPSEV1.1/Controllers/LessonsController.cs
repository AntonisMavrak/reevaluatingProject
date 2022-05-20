//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using ADOPSEV1._1.Data;
//using ADOPSEV1._1.Models;
//using System.Security.Claims;
//using System.Web;
//using System.Security.Principal;

//namespace ADOPSEV1._1.Controllers
//{
//    public class LessonsController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public LessonsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: Lessons
//        public async Task<IActionResult> Index()
//        {
//            string usr;
//            //var userId = User.Identity.GetUserId();
//            if (User.Identity.IsAuthenticated) { 
//               usr = User.Identity.Name;
//               var users = _context.users.Where(u => u.username == usr).Select(u => u.id).FirstOrDefault();
//                ViewBag.users = users;
//               return View(users);
//            }
//            //var UserId = System.Web.HttpContext.Current.User.Identity.Name;
//            //ViewData["UserId"] = UserId;
//            //WindowsIdentity user;
//            //user = HttpContext.Request.LogonUserIdentity;

//            //ApplicationBuilderUser applicationUser = await _userManager.GetUserAsync(User);
//            IEnumerable<Lesson> allLessons = _context.lessons;
//            return View(allLessons);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Create(Lesson obj)
//        {
//            IEnumerable<Lesson> allLessons = _context.lessons;
//            var lessonid = obj.id;

//            _context.userConnectsSubjects.Add(new UserConntectsSubject { lessonId = 5, userId = 5 });



//            //_context.userConnectsSubjects.Add(new UserConntectsSubject { userId = 5, lessonId = lessonid.ToString() });
//            _context.SaveChanges();
//            return View("Index", allLessons);
//        }







//    }
//}
