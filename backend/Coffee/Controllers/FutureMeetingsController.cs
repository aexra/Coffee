using Coffee.Data;
using Coffee.Dtos.FutureMeeting;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Controllers;

[Route("api/fms")]
[ApiController]
public class FutureMeetingsController : ControllerBase
{
    private readonly DataContext _context;

    public FutureMeetingsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var fms = await _context.FutureMeetings.ToListAsync();
        var dtos = fms.Select(f => f.ToDto());
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var fm = await _context.FutureMeetings.FindAsync((ulong)id);

        if (fm == null)
        {
            return NotFound();
        }

        return Ok(fm.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFutureMeetingRequestDto dto)
    {
        var fm = dto.ToFutureMeeting();
        await _context.FutureMeetings.AddAsync(fm);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = fm.Id }, fm.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] ulong id, [FromBody] UpdateFutureMeetingRequestDto dto)
    {
        var fm = await _context.FutureMeetings.FirstOrDefaultAsync(x => x.Id == id);

        if (fm == null)
        {
            return NotFound();
        }

        fm.Date = dto.Date;
        fm.Duration = dto.Duration;
        fm.User1 = dto.User1;
        fm.User2 = dto.User2;
        
        await _context.SaveChangesAsync();

        return Ok(fm.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] ulong id)
    {
        var fm = await _context.FutureMeetings.FirstOrDefaultAsync(x => x.Id == id);

        if (fm == null)
        {
            return NotFound();
        }

        _context.FutureMeetings.Remove(fm);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

