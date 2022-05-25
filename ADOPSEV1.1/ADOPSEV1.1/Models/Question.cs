using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ADOPSEV1._1.Models
{
    public class Question
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }
        [Required]
        [DisplayName("Question's Text")]
        public string text { get; set; }
        [Required]
        [DisplayName("Subject")]
        public int subjectId { get; set; }
        [Required]
        [DisplayName("Creator")]
        public int madeBy { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public Question(int id, string text, int subjectId, int madeBy)
        {
            this.id = id;
            this.text = text;
            this.subjectId = subjectId;
            this.madeBy = madeBy;
            CreatedDateTime = DateTime.Now;
        }

        public Question()
        {

        }
    }
}
