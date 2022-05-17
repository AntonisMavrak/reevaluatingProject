using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Question
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public int subjectId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
