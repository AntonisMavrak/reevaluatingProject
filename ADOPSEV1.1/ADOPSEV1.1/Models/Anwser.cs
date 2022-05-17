using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Anwser
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string text { get; set; }
        [Required]
        public int questionId { get; set; }
        [Required]
        public bool isCorrect { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
