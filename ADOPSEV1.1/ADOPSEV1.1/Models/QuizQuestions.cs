using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    [Keyless]
    public class QuizQuestions
    {
        [Required]
        public int quizId { get; set; }
        [Required]
        public int questionId { get; set; }

    }
}
