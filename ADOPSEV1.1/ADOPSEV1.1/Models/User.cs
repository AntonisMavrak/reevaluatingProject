using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace ADOPSEV1._1.Models
{
    public class User
    {
        [Key]
        [DisplayName("Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "First Name: ")]
        public string first_name { get; set; }

        [Required]
        [Display(Name = "Last Name: ")]
        public string last_name { get; set; }

        [EmailAddress]
        [StringLength(150)]
        [Display(Name = "Email Address: ")]
        public string email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(150, MinimumLength = 6)]
        [Display(Name = "Password: ")]
        public string password { get; set; }
        // public string PasswordSalt { get; set; }

        [DisplayName("Username")]
        public string username { get; set; }
        [DisplayName("Role")]
        public int role { get; set; }
        [DisplayName("Validated")]
        public bool validated { get; set; }
        [DisplayName("Branch")]
        public int branchId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;


        // public int SaveDetails()
        //{
        //string connectionString = configuration.GetConnectionString("Default");
        //SqlConnection con = new(connectionString);
        //string query = "INSERT INTO users(Name, Age, City) values ('" + first_name + "','" + last_name + "','" + email + "','" + password + "','" + username + "')";
        //SqlCommand cmd = new SqlCommand(query, con);
        //con.Open();
        //int i = cmd.ExecuteNonQuery();
        //con.Close();
        //return i;

        //}

    }
}
