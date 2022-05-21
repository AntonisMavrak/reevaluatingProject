using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    [Keyless]
    public class UserConnectsSubject
    {
        [Required]

        public int userId { get; set; }
        [Required]

        public int subjectId { get; set; }
    }
}
