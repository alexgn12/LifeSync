using LifeSync.Application.DTOs;
using LifeSync.Application.Interfaces;
using LifeSync.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeSync.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineService _routineService;

        public RoutineController(IRoutineService routineService)
        {
            _routineService = routineService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoutineAsync([FromBody] CreateRoutineDto dto)
        {
            var username = User.Identity?.Name ?? throw new Exception("Usuario no autenticado");
            await _routineService.CreateRoutineAsync(username, dto);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetDailyRoutineAsync([FromQuery] DateTime day)
        {
            var username = User.Identity?.Name ?? throw new Exception("Usuario no autenticado");
            var result = await _routineService.GetDailyRoutineAsync(username, day);
            return Ok(result);
        }
        [HttpPost("{id}/tasks")]
        public async Task<IActionResult> AddTaskToRoutine(Guid id, [FromBody] CreateTaskItemDto dto)
        {
            var username = User.Identity?.Name ?? throw new Exception("Usuario no autenticado");

            // (Opcional en futuro) Verificar que esa rutina pertenece al usuario

            await _routineService.AddTaskToRoutine(id, dto);

            return NoContent();
        }
    }
}
