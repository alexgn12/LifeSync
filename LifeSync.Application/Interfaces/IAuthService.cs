using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LifeSync.Application.DTOs;

namespace LifeSync.Application.Interfaces;

public interface IAuthService
{
    Task<string> RegisterAsync(UserRegisterDto dto);
    Task<string?> LoginAsync(UserLoginDto dto);
}
