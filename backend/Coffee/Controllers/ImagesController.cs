using Coffee.Data;
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
}
