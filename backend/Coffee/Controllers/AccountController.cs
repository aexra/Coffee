using Coffee.Dtos.Account;
using Coffee.Interfaces;
using Coffee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto)
    {
        try
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                HiredSince = dto.HiredSince,
                Name = dto.Name,
                Surname = dto.Surname,
                Patronymic = dto.Patronymic,
                Position = dto.Position,
                Hobbies = dto.Hobbies,
                Pets = dto.Pets,
                Coffee = dto.Coffee,
                Telegram = dto.Telegram,
                Vk = dto.Vk,
            };

            var createdUser = await _userManager.CreateAsync(user, dto.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, "User");
                if (roleResult.Succeeded)
                {
                    return Ok(new NewUserDto 
                    { 
                        UserName = user.UserName,
                        Email = user.Email,
                        Token = _tokenService.CreateToken(user)
                    });
                }
                else
                {
                    return StatusCode(500, roleResult.Errors);
                }
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}
