using Coffee.Data;
using Coffee.Dtos.Image;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Controllers;

[Route("api/images")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly DataContext _context;

    public ImagesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var images = await _context.Images.ToListAsync();
        var dtos = images.Select(i => i.ToDto());
        return Ok(dtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var image = await _context.Images.FindAsync((ulong)id);

        if (image == null)
        {
            return NotFound();
        }

        return Ok(image.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateImageRequestDto dto)
    {
        var image = dto.ToImage();
        await _context.Images.AddAsync(image);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = image.Id }, image.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] ulong id, [FromBody] UpdateImageRequestDto dto)
    {
        var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);

        if (image == null)
        {
            return NotFound();
        }

        image.BytesString = dto.BytesString;

        await _context.SaveChangesAsync();

        return Ok(image.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] ulong id)
    {
        var image = await _context.Images.FirstOrDefaultAsync(x => x.Id == id);

        if (image == null)
        {
            return NotFound();
        }

        _context.Images.Remove(image);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
