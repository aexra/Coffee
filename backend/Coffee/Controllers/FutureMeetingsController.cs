using Coffee.Data;
using Coffee.Dtos.FutureMeeting;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var fms = _context.FutureMeetings.ToList();

        return Ok(fms);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var fm = _context.FutureMeetings.Find((ulong)id);

        if (fm == null)
        {
            return NotFound();
        }

        return Ok(fm);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateFutureMeetingRequestDto dto)
    {
        var fm = dto.ToFutureMeeting();
        _context.FutureMeetings.Add(fm);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = fm.Id }, fm.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] ulong id, [FromBody] UpdateFutureMeetingRequestDto dto)
    {
        var fm = _context.FutureMeetings.FirstOrDefault(x => x.Id == id);

        if (fm == null)
        {
            return NotFound();
        }

        fm.Date = dto.Date;
        fm.Duration = dto.Duration;
        fm.User1 = dto.User1;
        fm.User2 = dto.User2;
        
        _context.SaveChanges();

        return Ok(fm.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] ulong id)
    {
        var fm = _context.FutureMeetings.FirstOrDefault(x => x.Id == id);

        if (fm == null)
        {
            return NotFound();
        }

        _context.FutureMeetings.Remove(fm);
        _context.SaveChanges();

        return NoContent();
    }
}

