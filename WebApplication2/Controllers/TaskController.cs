using Microsoft.AspNetCore.Mvc;
using WebApplication2.Context;
using WebApplication2.DTO;
using WebApplication2.Models;

namespace WebApplication2.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TaskController : ControllerBase
{
    private readonly MasterContext _context;

    public TaskController(MasterContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> getTasks([FromQuery]int? id)
    {
        if (id.HasValue)
        {
            var tasks = await _context.Tasks
                .Where(t => t.ProjectId == id.Value).ToListAsync();
            return Ok(tasks);
        }
        else
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
    {
        var project = await _context.Projects.FindAsync(taskDto.ProjectId);

        if (project == null)
        {
            return NotFound("projekt o takim id nie istnieje");
        }

        var reporter = await _context.Users.FindAsync(taskDto.ReporterId);

        if (reporter == null)
        {
            return NotFound("reporter o takim id nie istnieje");
        }

        var assignee;
        if (taskDto.AssigneeId.HasValue)
        {
             assignee = await _context.Users.FindAsync(taskDto.AssigneeId.Value);
            if (assignee == null)
            {
                return NotFound("asignee o takim id nie istnieje");
            }
        } else
        {
            assignee = await _context.Users.FindAsync(project.IdDefaultAssignee);
        }
        var task = new Task
        {
            Name = taskDto.Name,
            Description = taskDto.Description,
            ProjectId = taskDto.ProjectId,
            ReporterId = taskDto.ReporterId,
            AssigneeId = assignee?.Id,
            CreatedAt = DateTime.UtcNow
        };
        
        _context.Tasks.Add(task);
        
        await _context.SaveChangesAsync();
        return Ok();
    }
}