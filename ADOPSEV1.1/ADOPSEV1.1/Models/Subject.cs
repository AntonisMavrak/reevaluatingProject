using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Subject
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
