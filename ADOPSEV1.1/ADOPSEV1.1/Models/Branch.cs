using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Branch
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Editable(false)]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
