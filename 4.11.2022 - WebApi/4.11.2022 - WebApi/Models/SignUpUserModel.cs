using System.ComponentModel.DataAnnotations;

namespace _4._11._2022___WebApi.Models
{
    public class SignUpUserModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
