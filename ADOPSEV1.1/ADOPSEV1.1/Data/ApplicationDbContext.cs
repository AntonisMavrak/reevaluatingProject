using ADOPSEV1._1.Models;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {

        }

        public DbSet<User> users { get; set; }
    }
}
