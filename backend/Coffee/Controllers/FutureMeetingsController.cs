using Coffee.Data;
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
}

