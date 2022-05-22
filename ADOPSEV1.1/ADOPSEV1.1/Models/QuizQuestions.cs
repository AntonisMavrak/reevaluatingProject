using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class QuizQuestions
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int quizId { get; set; }
        [Required]
        public int questionId { get; set; }

    }
}
