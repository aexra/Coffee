using Coffee.Data;
using Coffee.Dtos.User;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DataContext _context;

    public UsersController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _context.Users.ToListAsync();
        var dtos = users.Select(u => u.ToDto());
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _context.Users.FindAsync((ulong)id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserRequestDto dto)
    {
        var user = dto.ToUser();
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] ulong id, [FromBody] UpdateUserRequestDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        user.HiredSince = dto.HiredSince;
        user.MeetingsCount = dto.MeetingsCount;
        user.Name = dto.Name;
        user.Surname = dto.Surname;
        user.Patronymic = dto.Patronymic;
        user.Position = dto.Position;
        user.Hobbies = dto.Hobbies;
        user.Pets = dto.Pets;
        user.Coffee = dto.Coffee;
        user.Telegram = dto.Telegram;
        user.Vk = dto.Vk;
        user.PhoneNumber = dto.PhoneNumber;

        await _context.SaveChangesAsync();

        return Ok(user.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] ulong id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
