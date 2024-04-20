using Coffee.Data;
using Coffee.Dtos.Image;
using Coffee.Mappers;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var images = _context.Images.ToList();

        return Ok(images);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var image = _context.Images.Find((ulong)id);

        if (image == null)
        {
            return NotFound();
        }

        return Ok(image);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateImageRequestDto dto)
    {
        var image = dto.ToImage();
        _context.Images.Add(image);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = image.Id }, image.ToDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] ulong id, [FromBody] UpdateImageRequestDto dto)
    {
        var image = _context.Images.FirstOrDefault(x => x.Id == id);

        if (image == null)
        {
            return NotFound();
        }

        image.BytesString = dto.BytesString;

        _context.SaveChanges();

        return Ok(image.ToDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] ulong id)
    {
        var image = _context.Images.FirstOrDefault(x => x.Id == id);

        if (image == null)
        {
            return NotFound();
        }

        _context.Images.Remove(image);
        _context.SaveChanges();

        return NoContent();
    }
}
