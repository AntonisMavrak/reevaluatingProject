using ADOPSEV1._1.Models;
using Microsoft.EntityFrameworkCore;

namespace ADOPSEV1._1.Data
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> options) : base(options)
        {

        }

        public DbSet<User> users { get; set; }
    }
}
