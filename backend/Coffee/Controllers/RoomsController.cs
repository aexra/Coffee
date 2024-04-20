using Coffee.Data;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers;

[Route("api/rooms")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly DataContext _context;

    public RoomsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var rooms = _context.Rooms.ToList();

        return Ok(rooms);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var room = _context.Rooms.Find((ulong)id);

        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }
}
