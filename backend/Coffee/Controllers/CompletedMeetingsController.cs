using Coffee.Data;
using Coffee.Dtos.CompletedMeeting;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var cms = _context.CompletedMeetings.ToList();

        return Ok(cms);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var cm = _context.CompletedMeetings.Find((ulong)id);

        if (cm == null)
        {
            return NotFound();
        }

        return Ok(cm);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateCompletedMeetingRequestDto dto)
    {
        var cm = dto.ToCompletedMeeting();
        _context.CompletedMeetings.Add(cm);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = cm.Id }, cm.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] ulong id, [FromBody] UpdateCompletedMeetingRequestDto dto)
    {
        var cm = _context.CompletedMeetings.FirstOrDefault(x => x.Id == id);

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

        _context.SaveChanges();

        return Ok(cm.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] ulong id)
    {
        var cm = _context.CompletedMeetings.FirstOrDefault(x => x.Id == id);

        if (cm == null)
        {
            return NotFound();
        }

        _context.CompletedMeetings.Remove(cm);
        _context.SaveChanges();

        return NoContent();
    }
}
