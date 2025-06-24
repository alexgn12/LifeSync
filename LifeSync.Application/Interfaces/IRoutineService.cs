using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LifeSync.Application.DTOs;

namespace LifeSync.Application.Interfaces;

public interface IRoutineService
{
    Task<Guid> CreateRoutineAsync(string username, CreateRoutineDto dto);
    Task<List<RoutineDto>> GetDailyRoutineAsync(string username, DateTime day);
    Task AddTaskToRoutine(Guid routineId, CreateTaskItemDto dto);
}
