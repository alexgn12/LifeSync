using LifeSync.Application.DTOs;
using LifeSync.Application.Interfaces;
using LifeSync.Domain.Entities;
using BCrypt.Net;
using LifeSync.Infrastructure.Auth;

namespace LifeSync.Infrastructure.Auth;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly JwtService _jwtService;

    public AuthService(IUserRepository userRepository, JwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<string> RegisterAsync(UserRegisterDto dto)
    {
        var existing = await _userRepository.GetByUsernameAsync(dto.Username);
        if (existing != null)
            throw new Exception("El usuario ya existe");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Username = dto.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
        };

        await _userRepository.CreateAsync(user);
        return _jwtService.GenerateToken(user);
    }

    public async Task<string?> LoginAsync(UserLoginDto dto)
    {
        var user = await _userRepository.GetByUsernameAsync(dto.Username);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            return null;

        return _jwtService.GenerateToken(user);
    }
}
