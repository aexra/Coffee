using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Coffee.Interfaces;
using Coffee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Coffee.Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;
    private readonly UserManager<User> _userManager;

    public TokenService(IConfiguration config, UserManager<User> userManager)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        _userManager = userManager;
    }

    public async Task<string> CreateToken(User user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>()
        {
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.GivenName, user.UserName),
        };
        var claimsIdentity = new ClaimsIdentity(claims, "Token");
        claimsIdentity.AddClaims(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"],
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        Console.WriteLine(tokenHandler.WriteToken(token));

        return tokenHandler.WriteToken(token);
    }
}
