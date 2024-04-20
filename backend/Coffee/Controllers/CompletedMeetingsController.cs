using Coffee.Data;
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
}
