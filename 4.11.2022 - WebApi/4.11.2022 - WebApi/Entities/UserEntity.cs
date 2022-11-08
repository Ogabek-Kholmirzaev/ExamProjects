using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using _4._11._2022___WebApi.Models;

namespace _4._11._2022___WebApi.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
