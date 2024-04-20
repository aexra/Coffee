using Coffee.Data;
using Coffee.Dtos.Room;
using Coffee.Mappers;
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

    [HttpPost]
    public IActionResult Create([FromBody] CreateRoomRequestDto dto)
    {
        var room = dto.ToRoom();
        _context.Rooms.Add(room);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] ulong id, [FromBody] UpdateRoomRequestDto dto)
    {
        var room = _context.Rooms.FirstOrDefault(x => x.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        room.User1 = dto.User1;
        room.User2 = dto.User2;

        _context.SaveChanges();

        return Ok(room.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] ulong id)
    {
        var room = _context.Rooms.FirstOrDefault(x => x.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        _context.SaveChanges();

        return NoContent();
    }
}
