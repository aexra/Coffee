using Coffee.Data;
using Microsoft.AspNetCore.Mvc;

namespace Coffee.Controllers;

[Route("api/themes")]
[ApiController]
public class ThemesController : ControllerBase
{
    private readonly DataContext _context;

    public ThemesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var themes = _context.Themes.ToList();

        return Ok(themes);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var theme = _context.Themes.Find((ulong)id);

        if (theme == null)
        {
            return NotFound();
        }

        return Ok(theme);
    }
}

