using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
namespace ADOPSEV1._1.Controllers
{

    public class AnwserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AnwserController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
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
        public IActionResult Create(Anwser obj)
        {

            if (ModelState.IsValid)
            {
                _db.anwsers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created succesfully";
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
            var categoryFromDb = _db.anwsers.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Anwser obj)
        {

            if (ModelState.IsValid)
            {
                _db.anwsers.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated succesfully";
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
            var categoryFromDb = _db.anwsers.Find(id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.anwsers.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.anwsers.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("Index");

        }
    }
}
