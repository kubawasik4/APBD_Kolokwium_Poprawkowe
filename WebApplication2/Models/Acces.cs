namespace WebApplication2.Models;

public class Acces
{
    public int IdUser { get; set; }
    public int IdProject { get; set; }
    public User user { get; set; }
    public Project project { get; set; }
}