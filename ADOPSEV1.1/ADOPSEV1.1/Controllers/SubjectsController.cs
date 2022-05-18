using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            IEnumerable<Subject> objSubjectList = _db.subjects;
            return View(objSubjectList);
        }





        //CREATE SECTION

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Subject obj)
        {

            if (ModelState.IsValid)
            {
                _db.subjects.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Subject created succesfully";
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
            var subjectFromDb = _db.subjects.Find(id);

            if (subjectFromDb == null)
            {
                return NotFound();
            }

            return View(subjectFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Subject obj)
        {

            if (ModelState.IsValid)
            {
                _db.subjects.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Subject updated succesfully";
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
            var subjectFromDb = _db.subjects.Find(id);

            if (subjectFromDb == null)
            {
                return NotFound();
            }

            return View(subjectFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.subjects.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.subjects.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Subject deleted succesfully";
            return RedirectToAction("Index");

        }

        //GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.subjects == null)
            {
                return NotFound();
            }

            var subject = await _db.subjects
                .FirstOrDefaultAsync(m => m.id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }
    }
}
