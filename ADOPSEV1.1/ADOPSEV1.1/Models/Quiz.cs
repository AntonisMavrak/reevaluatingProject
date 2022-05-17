using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Quiz
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public string title { get; set; }

        [Required]
        public int subjectId { get; set; }

        [Required]
        public int minutes { get; set; }
        public int numberOfQuestions { get; set; }
        public int madeBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
