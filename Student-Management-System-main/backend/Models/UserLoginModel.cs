using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class UserLoginModel
    {
        [Required]
        public string userName { get; set; }

        [Required]
        public string password { get; set; }
    }
}