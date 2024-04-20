using Coffee.Data;
using Coffee.Dtos.User;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var users = _context.Users.ToList();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var user = _context.Users.Find((ulong)id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserRequestDto dto)
    {
        var user = dto.ToUser();
        _context.Users.Add(user);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] ulong id, [FromBody] UpdateUserRequestDto dto)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

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

        _context.SaveChanges();

        return Ok(user.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] ulong id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user == null)
        {
            return NotFound();
        }

        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}
