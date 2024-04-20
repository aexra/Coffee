using Coffee.Data;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DataContext _context;

    public UserController(DataContext context)
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
}
