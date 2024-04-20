using Coffee.Data;
using Coffee.Dtos.Theme;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetAll()
    {
        var themes = await _context.Themes.ToListAsync();
        var dtos = themes.Select(t => t.ToDto());
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var theme = await _context.Themes.FindAsync((ulong)id);

        if (theme == null)
        {
            return NotFound();
        }

        return Ok(theme.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateThemeRequestDto dto)
    {
        var theme = dto.ToEntity();
        await _context.Themes.AddAsync(theme);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = theme.Id }, theme.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] ulong id, [FromBody] UpdateThemeRequestDto dto)
    {
        var theme = await _context.Themes.FirstOrDefaultAsync(x => x.Id == id);

        if (theme == null)
        {
            return NotFound();
        }

        theme.Description = dto.Description;

        await _context.SaveChangesAsync();

        return Ok(theme.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] ulong id)
    {
        var theme = await _context.Themes.FirstOrDefaultAsync(x => x.Id == id);

        if (theme == null)
        {
            return NotFound();
        }

        _context.Themes.Remove(theme);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

