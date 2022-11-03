using System.ComponentModel.DataAnnotations;

namespace _11._02._2022___WebApi.Models;

public class UserDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(20)]
    public string Password { get; set; }
}