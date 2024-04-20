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
}
