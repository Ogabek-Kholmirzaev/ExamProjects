using System.ComponentModel.DataAnnotations;

namespace _11._02._2022___WebApi.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Password { get; set; }
    public string Key { get; set; }
}