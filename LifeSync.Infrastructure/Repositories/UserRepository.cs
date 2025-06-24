using LifeSync.Application.Interfaces;
using LifeSync.Domain.Entities;
using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LifeSyncDbContext _context;

    public UserRepository(LifeSyncDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task CreateAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}
