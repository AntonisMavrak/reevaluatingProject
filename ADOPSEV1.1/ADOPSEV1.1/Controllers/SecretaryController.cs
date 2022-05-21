using ADOPSEV1._1.Data;
using ADOPSEV1._1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Controllers
{
    public class SecretaryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SecretaryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public Boolean canEnterPanel()
        {

            int user_role;
            string usr;
            Boolean chk = false;
            if (User.Identity.IsAuthenticated)
            {
                usr = User.Identity.Name;
                user_role = _db.users.Where(u => u.username == usr).Select(u => u.role).FirstOrDefault();
    
                //user with secretary and above rights are allowed
                if (user_role >= 4)
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
        public IActionResult Index()
        {
            Boolean canVisit = canEnterPanel();
            if (canVisit)
            {
                IEnumerable<User> UserList = _db.users;
                IEnumerable<User> correctUsers = UserList.Where(d => d.role < 4).ToList();
                return View(correctUsers);
            }
            else
            {
                return View("AccessDenied");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.users == null)
            {
                return NotFound();
            }

            var user = await _db.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,first_name,last_name,email,password,username,role,validated,branchId,CreatedDateTime")] User user)
        {
            
            if (id != user.id)
            {
                return NotFound();
            }
            ModelState.Remove("password");
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(user);
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (user.id == 100)
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
    }
}
