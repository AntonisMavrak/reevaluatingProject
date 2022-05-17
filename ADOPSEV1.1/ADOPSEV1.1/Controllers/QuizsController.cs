using ADOPSEV1._1.Data;
using Microsoft.AspNetCore.Mvc;

namespace ADOPSEV1._1.Controllers
{
    public class QuizsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public QuizsController(ApplicationDbContext db)
        {
            _db = db;
        }

    }
}
