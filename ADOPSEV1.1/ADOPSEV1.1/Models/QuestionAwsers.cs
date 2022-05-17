using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    [Keyless]
    public class QuestionAwsers
    {
        [Required]
        public int questionId { get; set; }
        [Required]
        public int anwserId { get; set; }

    }
}

