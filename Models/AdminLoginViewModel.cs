using System.ComponentModel.DataAnnotations;

namespace lamia12771.Models
{
    public class AdminLoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}