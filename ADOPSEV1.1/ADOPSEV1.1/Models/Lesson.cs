using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Lesson
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
    }
}
