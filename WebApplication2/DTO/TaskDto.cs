namespace WebApplication2.DTO;

public class TaskDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int ProjectId { get; set; }
    public int ReporterId { get; set; }
    public int? AssigneeId { get; set; }
}