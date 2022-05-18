using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Branch
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }
        [Required]
        [DisplayName("Branch Name")]
        public string name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
