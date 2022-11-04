using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace _3_11_2022_WebAPI.Models
{
    public class CreateUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
