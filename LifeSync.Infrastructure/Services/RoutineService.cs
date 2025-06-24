using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSync.Application.DTOs;
using LifeSync.Application.Interfaces;
using LifeSync.Domain.Entities;
using LifeSync.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LifeSync.Infrastructure.Services
{
    public class RoutineService : IRoutineService
    {
        private readonly LifeSyncDbContext _context;

        public RoutineService(LifeSyncDbContext context)
        {
            _context = context;
        }

        public async Task AddTaskToRoutine(Guid routineId, CreateTaskItemDto dto)
        {
            var routine = await _context.Routines
                .Include(r => r.Tasks) // Muy importante incluir las tareas si usas Add a la colección
                .FirstOrDefaultAsync(r => r.Id == routineId)
                ?? throw new Exception("Rutina no encontrada");

            var task = new TaskItem
            {
                Title = dto.Title,
                EndTime = dto.EndTime,
                StartTime = dto.StartTime,
                IsCompleted = false,
                RoutineId = routine.Id
            };

            routine.Tasks.Add(task); // O bien: _context.TaskItems.Add(task);

            await _context.SaveChangesAsync();

        }

        // Crea una nueva rutina para el usuario con tareas opcionales
        // y devuelve el ID generado
        public async Task<Guid> CreateRoutineAsync(string username, CreateRoutineDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == username)
                ?? throw new Exception("Usuario no encontrado");

            var routine = new Routine
            {
                UserId = user.Id,
                Date = dto.Date,
                Title = dto.Title,
                Tasks = dto.Tasks.Select(taskDto => new TaskItem
                {
                    Title = taskDto.Title,
                    StartTime = taskDto.StartTime,
                    EndTime = taskDto.EndTime,
                    IsCompleted = false
                }).ToList()
            };
            var exists = await _context.Routines.AnyAsync(r =>
                r.UserId == user.Id && r.Date.Date == dto.Date.Date);

            if (exists)
                throw new InvalidOperationException("Ya existe una rutina para ese día");

            _context.Routines.Add(routine);
            await _context.SaveChangesAsync();

            return routine.Id;
        }

        public async Task<List<RoutineDto>> GetDailyRoutineAsync(string username, DateTime day)
        {
            var user = await _context.Users
                .Include(u => u.Routines)
                .ThenInclude(r => r.Tasks)
                .FirstOrDefaultAsync(u => u.Username == username)
                ?? throw new Exception("Usuario no encontrado");

            var routines = user.Routines
                .Where(r => r.Date.Date == day.Date)
                .Select(r => new RoutineDto
                {
                    Id = r.Id,
                    Date = r.Date,
                    Title = r.Title,
                    Tasks = r.Tasks.Select(t => new TaskItemDto
                    {
                        Title = t.Title,
                        StartTime = t.StartTime,
                        EndTime = t.EndTime,
                        IsCompleted = t.IsCompleted
                    }).ToList()
                })
                .ToList();

            return routines;
        }
    }
}
