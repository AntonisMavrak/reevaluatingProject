using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADOPSEV1._1.Models
{
    public class UserConntectsSubject
    {

        [Key]
        public int id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int userId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int lessonId { get; set; }
    }
}
