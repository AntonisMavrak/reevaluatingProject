using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Quiz
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }

        [Required]
        [DisplayName("Title")]
        [StringLength(maximumLength: 60, MinimumLength = 2)]
        public string title { get; set; }

        [Required]
        [DisplayName("Subject")]
        public int subjectId { get; set; }

        [Required]
        [DisplayName("Timer")]
        public int minutes { get; set; }
        [DisplayName("Number Of Questions")]
        public int numberOfQuestions { get; set; }
        [DisplayName("Creator")]
        public int madeBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
