using Coffee.Dtos.Account;
using Coffee.Interfaces;
using Coffee.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static SQLite.SQLite3;

namespace Coffee.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<User> _signInManager;
    private readonly ITokenService _tokenService;

    public AccountController(UserManager<User> userManager, ITokenService tokenService, RoleManager<IdentityRole> roleManager, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
        _roleManager = roleManager;
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _userManager.Users.ToListAsync());
    }

    [HttpGet]
    [Route("{username}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetByName([FromRoute] string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == dto.UserName);

        if (user == null)
        {
            return Unauthorized("Invalid username");
        }

        var result = _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.IsCompletedSuccessfully) return Unauthorized("Username not found and/or password incorrect");

        return Ok(new NewUserDto() { 
            UserName = user.UserName,
            Email = user.Email,
            Token = await _tokenService.CreateToken(user)
        });
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
                        Token = await _tokenService.CreateToken(user)
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

    [HttpDelete]
    public async Task<IActionResult> DeleteAll()
    {
        foreach (var user in await _userManager.Users.ToListAsync())
        {
            await _userManager.DeleteAsync(user);
        }

        return NoContent();
    }

    [HttpDelete]
    [Route("{username}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromRoute] string username)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

        if (user == null)
        {
            return NotFound();
        }

        await _userManager.DeleteAsync(user);

        return NoContent();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    [Route("roles/{username}")]
    public async Task<IActionResult> GetRoles([FromRoute] string username)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

        //var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == HttpContext.User.Identity.Name);

        //return Ok(user.UserName);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(_userManager.GetRolesAsync(user).Result);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    [Route("roles/username={username}&role={roleName}")]
    public async Task<IActionResult> SetRole([FromRoute] string username, [FromRoute] string roleName)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

        if (user == null)
        {
            return NotFound($"User \"{username}\" not found");
        }

        var role = await _roleManager.FindByNameAsync(roleName);

        if (role == null)
        {
            return NotFound($"Role \"{roleName}\" not found");
        }

        var result = await _userManager.AddToRoleAsync(user, role.Name);

        if (!result.Succeeded)
        {
            return StatusCode(500, result.Errors);
        }

        return Ok(new string[] { username, role.Name });
    }

    [HttpDelete]
    [Authorize(Roles = "Admin")]
    [Route("roles/username={username}&role={roleName}")]
    public async Task<IActionResult> DeleteRole([FromRoute] string username, [FromRoute] string roleName)
    {
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);

        if (user == null)
        {
            return NotFound($"User \"{username}\" not found");
        }

        var role = await _roleManager.FindByNameAsync(roleName);

        if (role == null)
        {
            return NotFound($"Role \"{roleName}\" not found");
        }

        var result = await _userManager.RemoveFromRoleAsync(user, role.Name);

        if (!result.Succeeded)
        {
            return StatusCode(500, result.Errors);
        }

        return Ok(new string[] { username, role.Name });
    }
}
