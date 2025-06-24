using LifeSync.Application.DTOs;

namespace LifeSync.Application.Interfaces;

public interface IProfileService
{
    Task<UserPreferencesDto> GetPreferencesAsync(string username);
    Task UpdatePreferencesAsync(string username, UserPreferencesDto preferences);
}
