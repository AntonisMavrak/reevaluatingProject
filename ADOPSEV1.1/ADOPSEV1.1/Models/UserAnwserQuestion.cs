using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class UserAnwserQuestion
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public int quizId { get; set; }
        [Required]
        public int questionId { get; set; }
        [Required]
        public bool isCorrect { get; set; }

        public UserAnwserQuestion()
        {

        }

        public UserAnwserQuestion(int userId, int quizId, int questionId, bool isCorrect)
        {
            this.userId = userId;
            this.quizId = quizId;
            this.questionId = questionId;
            this.isCorrect = isCorrect;
        }
    }
}
