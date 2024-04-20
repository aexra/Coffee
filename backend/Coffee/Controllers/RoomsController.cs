using Coffee.Data;
using Coffee.Dtos.Room;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetAll()
    {
        var rooms = await _context.Rooms.ToListAsync();
        var dtos = rooms.Select(r => r.ToDto());
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var room = await _context.Rooms.FindAsync((ulong)id);

        if (room == null)
        {
            return NotFound();
        }

        return Ok(room.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomRequestDto dto)
    {
        var room = dto.ToEntity();
        await _context.Rooms.AddAsync(room);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] ulong id, [FromBody] UpdateRoomRequestDto dto)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        room.User1 = dto.User1;
        room.User2 = dto.User2;

        await _context.SaveChangesAsync();

        return Ok(room.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] ulong id)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);

        if (room == null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
