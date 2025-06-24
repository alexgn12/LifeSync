using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LifeSync.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Persistence;

public class LifeSyncDbContext : DbContext
{
    public LifeSyncDbContext(DbContextOptions<LifeSyncDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<UserAllergy> UserAllergies => Set<UserAllergy>();
    public DbSet<UserSkill> UserSkills => Set<UserSkill>();
    public DbSet<Routine> Routines => Set<Routine>();
    public DbSet<TaskItem> TaskItems => Set<TaskItem>();

}
