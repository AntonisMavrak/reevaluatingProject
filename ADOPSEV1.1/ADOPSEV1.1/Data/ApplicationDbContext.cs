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
        public DbSet<Quiz> quizzes { get; set; }
        public DbSet<Anwser> anwsers { get; set; }
        public DbSet<Branch> branches { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<QuestionAwsers> questionAwsers { get; set; }
        public DbSet<QuizQuestions> quizQuestions { get; set; }
        public DbSet<UserConnectsSubject> userConnectsSubjects { get; set; }
        public DbSet<UserAnwserQuestion> userAnwserQuestion { get; set; }

    }
}
