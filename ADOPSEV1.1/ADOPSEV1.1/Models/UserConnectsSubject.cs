using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{

    public class UserConnectsSubject
    {
        [Key]
        public int id { get; set; }
        [Required]

        public int userId { get; set; }
        [Required]

        public int subjectId { get; set; }
    }
}
