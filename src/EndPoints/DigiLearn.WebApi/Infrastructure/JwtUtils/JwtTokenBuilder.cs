using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UserModule.Core.Queries._DTOs;

namespace DigiLearn.WebApi.Infrastructure.JwtUtils;

public class JwtTokenBuilder
{
    public static string BuildToken(UserDto user, bool RememberMe, IConfiguration configuration)
    {
        var roles = user.Roles.Select(s => s.Title);
        var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
            new Claim(ClaimTypes.Role,string.Join("-",roles))
        };
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]));
        var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
        var expiration =
            RememberMe == true ? DateTime.Now.AddDays(30) 
            : DateTime.Now.AddDays(1);
        var token = new JwtSecurityToken(
            issuer: configuration["JwtConfig:Issuer"],
            audience: configuration["JwtConfig:Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credential);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}