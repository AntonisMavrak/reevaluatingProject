using ADOPSEV1._1.Data;
using Microsoft.AspNetCore.Mvc;

namespace ADOPSEV1._1.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BranchesController(ApplicationDbContext db)
        {
            _db = db;
        }

    }
}
