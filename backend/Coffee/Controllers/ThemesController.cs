using Coffee.Data;
using Coffee.Dtos.Theme;
using Coffee.Mappers;
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

    [HttpPost]
    public IActionResult Create([FromBody] CreateThemeRequestDto dto)
    {
        var theme = dto.ToTheme();
        _context.Themes.Add(theme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = theme.Id }, theme.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] ulong id, [FromBody] UpdateThemeRequestDto dto)
    {
        var theme = _context.Themes.FirstOrDefault(x => x.Id == id);

        if (theme == null)
        {
            return NotFound();
        }

        theme.Description = dto.Description;

        _context.SaveChanges();

        return Ok(theme.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] ulong id)
    {
        var theme = _context.Themes.FirstOrDefault(x => x.Id == id);

        if (theme == null)
        {
            return NotFound();
        }

        _context.Themes.Remove(theme);
        _context.SaveChanges();

        return NoContent();
    }
}

