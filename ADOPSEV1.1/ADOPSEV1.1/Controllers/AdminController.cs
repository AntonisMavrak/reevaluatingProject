using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }


        //test
        public Boolean canEnterPanel()
        {

            int user_role;
            string usr;
            Boolean chk = false;
            if (User.Identity.IsAuthenticated)
            {
                usr = User.Identity.Name;
                user_role = _context.users.Where(u => u.username == usr).Select(u => u.role).FirstOrDefault();
                if(user_role == 6)
                {
                    chk = true;
                }
                else
                {
                    chk = false;
                }
                
            }
            return chk;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {

            Boolean canVisit = canEnterPanel();
            if (canVisit) { 
                IEnumerable<User> objUserList = _context.users;

                IEnumerable<User> lastRegistered = objUserList.OrderBy(x => x.CreatedDateTime).ToList();

                int teachers = 0;
                int students = 0;
                foreach (User user in lastRegistered)
                {
                    if(user.role == 2)
                    {
                        teachers += 1;
                    }
                    if(user.role == 0)
                    {
                        students += 1;
                    }
                }
                ViewBag.teachers = teachers;
                ViewBag.students = students;
                //ViewBag.NameSort = sortOrder == "Name" ? "Name_desc" : "Name";
                ViewBag.TotalUsers = objUserList.Count();
                return View(lastRegistered);
            }
            else
            {
                return View("AccessDenied");
            }
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,first_name,last_name,email,password,username,role,validated,branchId,CreatedDateTime")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,first_name,last_name,email,password,username,role,validated,branchId,CreatedDateTime")] User user)
        {
            if (id != user.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.users == null)
            {
                return NotFound();
            }

            var user = await _context.users
                .FirstOrDefaultAsync(m => m.id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.users == null)
            {
                return Problem("Entity set 'ApplicationDbContext.users'  is null.");
            }
            var user = await _context.users.FindAsync(id);
            if (user != null)
            {
                _context.users.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
          return (_context.users?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
