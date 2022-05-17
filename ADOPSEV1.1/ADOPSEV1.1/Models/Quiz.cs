using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 2)]

        public string Title { get; set; }

        [Required]
        public int SubjectId { get; set; }
    }
}
