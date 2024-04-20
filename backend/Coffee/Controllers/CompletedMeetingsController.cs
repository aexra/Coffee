using Coffee.Data;
using Coffee.Dtos.CompletedMeeting;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Controllers;

[Route("api/cms")]
[ApiController]
public class CompletedMeetingsController : ControllerBase
{
    private readonly DataContext _context;

    public CompletedMeetingsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var cms = await _context.CompletedMeetings.ToListAsync();
        var dtos = cms.Select(c => c.ToDto());
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var cm = await _context.CompletedMeetings.FindAsync((ulong)id);

        if (cm == null)
        {
            return NotFound();
        }

        return Ok(cm.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCompletedMeetingRequestDto dto)
    {
        var cm = dto.ToEntity();
        await _context.CompletedMeetings.AddAsync(cm);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = cm.Id }, cm.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] ulong id, [FromBody] UpdateCompletedMeetingRequestDto dto)
    {
        var cm = await _context.CompletedMeetings.FirstOrDefaultAsync(x => x.Id == id);

        if (cm == null)
        {
            return NotFound();
        }

        cm.Date = dto.Date;
        cm.Duration = dto.Duration;
        cm.User1 = dto.User1;
        cm.User2 = dto.User2;
        cm.Success = dto.Success;
        cm.Canceller = dto.Canceller;
        cm.Images = dto.Images;
        cm.ImagesBlobbed = dto.ImagesBlobbed;

        await _context.SaveChangesAsync();

        return Ok(cm.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] ulong id)
    {
        var cm = await _context.CompletedMeetings.FirstOrDefaultAsync(x => x.Id == id);

        if (cm == null)
        {
            return NotFound();
        }

        _context.CompletedMeetings.Remove(cm);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
