using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    [Keyless]
    public class UserConnectsSubject
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SubjectId { get; set; }
    }
}
