
namespace LifeSync.Application.DTOs;

public class RoutineDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<TaskItemDto> Tasks { get; set; } = new();
}
