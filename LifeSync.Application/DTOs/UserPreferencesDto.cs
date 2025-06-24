namespace LifeSync.Application.DTOs;

public class UserPreferencesDto
{
    public List<string> Allergies { get; set; } = new();
    public List<string> Skills { get; set; } = new();
}
