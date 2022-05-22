using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class QuestionAwsers
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int questionId { get; set; }
        [Required]
        public int anwserId { get; set; }

    }
}

