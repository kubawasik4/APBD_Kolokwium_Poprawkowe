namespace WebApplication2.Models;

public class User
{
    public int IdUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<Task> TaskList { get; set; }
    public ICollection<Project> ProjectList { get; set; }
    public ICollection<Acces> AccessList { get; set; }
}