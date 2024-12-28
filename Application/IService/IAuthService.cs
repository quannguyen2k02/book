using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace Application.IService;

public interface IAuthService
{
    Task<object> GenerateTokenAsync(LoginModel model);
    Task<IdentityResult> RegisterUserAsync(RegisterModel model, bool isAdmin = false);
    Task<object> RefreshToken(TokenModel tokenModel);
}
