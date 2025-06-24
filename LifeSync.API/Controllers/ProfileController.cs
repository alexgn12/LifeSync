using LifeSync.Application.DTOs;
using LifeSync.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeSync.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet("preferences")]
    public async Task<IActionResult> GetPreferences()
    {
        var username = User.Identity?.Name ?? throw new Exception("Usuario no autenticado");
        var prefs = await _profileService.GetPreferencesAsync(username);
        return Ok(prefs);
    }

    [HttpPost("preferences")]
    public async Task<IActionResult> UpdatePreferences([FromBody] UserPreferencesDto dto)
    {
        var username = User.Identity?.Name ?? throw new Exception("Usuario no autenticado");
        await _profileService.UpdatePreferencesAsync(username, dto);
        return NoContent();
    }
}
