using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ADOPSEV1._1.Models
{
    [Keyless]
    public class UserConnectsSubject
    {
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
    }
}
