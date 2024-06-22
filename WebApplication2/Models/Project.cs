namespace WebApplication2.Models;

public class Project
{
    public int IdProject { get; set; }
    public string Name { get; set; }
    public int IdDefaultAssignee { get; set; }
    public User user { get; set; }
    public Task task { get; set; }
    public ICollection<Acces> AccesList { get; set; }
    public ICollection<Task> TaskList { get; set; }
}