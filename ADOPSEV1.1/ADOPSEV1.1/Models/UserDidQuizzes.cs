using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class UserDidQuizzes
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public int quizId { get; set; }
    }
}
