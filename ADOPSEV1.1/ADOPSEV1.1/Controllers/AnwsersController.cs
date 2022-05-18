using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Controllers
{
    public class AnwsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AnwsersController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            IEnumerable<Anwser> objAnwserList = _db.anwsers;
            return View(objAnwserList);
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
                TempData["success"] = "Anwser created succesfully";
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
            var anwserFromDb = _db.anwsers.Find(id);

            if (anwserFromDb == null)
            {
                return NotFound();
            }

            return View(anwserFromDb);
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
                TempData["success"] = "Answer updated succesfully";
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
            var anwserFromDb = _db.anwsers.Find(id);

            if (anwserFromDb == null)
            {
                return NotFound();
            }

            return View(anwserFromDb);
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
            TempData["success"] = "Anwser deleted succesfully";
            return RedirectToAction("Index");

        }


        //GET: Anwsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.anwsers == null)
            {
                return NotFound();
            }

            var anwser = await _db.anwsers
                .FirstOrDefaultAsync(m => m.id == id);
            if (anwser == null)
            {
                return NotFound();
            }

            return View(anwser);
        }

    }
}