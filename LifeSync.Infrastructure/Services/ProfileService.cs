using LifeSync.Application.DTOs;
using LifeSync.Application.Interfaces;
using LifeSync.Domain.Entities;
using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Services;

public class ProfileService : IProfileService
{
    private readonly LifeSyncDbContext _context;

    public ProfileService(LifeSyncDbContext context)
    {
        _context = context;
    }

    public async Task<UserPreferencesDto> GetPreferencesAsync(string username)
    {
        var user = await _context.Users
            .Include(u => u.Allergies)
            .Include(u => u.Skills)
            .FirstOrDefaultAsync(u => u.Username == username)
            ?? throw new Exception("Usuario no encontrado");

        return new UserPreferencesDto
        {
            Allergies = user.Allergies.Select(a => a.Name).ToList(),
            Skills = user.Skills.Select(s => s.Name).ToList()
        };
    }

    public async Task UpdatePreferencesAsync(string username, UserPreferencesDto preferences)
    {
        var user = await _context.Users
            .Include(u => u.Allergies)
            .Include(u => u.Skills)
            .FirstOrDefaultAsync(u => u.Username == username)
            ?? throw new Exception("Usuario no encontrado");

        if (preferences.Allergies?.Any() == true)
        {
            var newAllergies = preferences.Allergies
                .Where(a => !user.Allergies.Any(existing => existing.Name == a))
                .Select(name => new UserAllergy { Name = name, UserId = user.Id });

            foreach (var allergy in newAllergies)
                user.Allergies.Add(allergy);
        }

        if (preferences.Skills?.Any() == true)
        {
            var newSkills = preferences.Skills
                .Where(s => !user.Skills.Any(existing => existing.Name == s))
                .Select(name => new UserSkill { Name = name, UserId = user.Id });

            foreach (var skill in newSkills)
                user.Skills.Add(skill);
        }
        await _context.SaveChangesAsync();
    }
}
