using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BranchesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Branch> objBranchList = _db.branches;
            return View(objBranchList);
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
        public IActionResult Create(Branch obj)
        {

            if (ModelState.IsValid)
            {
                _db.branches.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Branch created succesfully";
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
            var branchFromDb = _db.branches.Find(id);

            if (branchFromDb == null)
            {
                return NotFound();
            }

            return View(branchFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Branch obj)
        {

            if (ModelState.IsValid)
            {
                _db.branches.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Branch updated succesfully";
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
            var branchFromDb = _db.branches.Find(id);

            if (branchFromDb == null)
            {
                return NotFound();
            }

            return View(branchFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.branches.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.branches.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Branch deleted succesfully";
            return RedirectToAction("Index");

        }


        //GET: Branches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.branches == null)
            {
                return NotFound();
            }

            var branch = await _db.branches
                .FirstOrDefaultAsync(m => m.id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }
    }
}
