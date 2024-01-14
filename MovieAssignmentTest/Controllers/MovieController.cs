// Controllers/MovieController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieAssignmentTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _context;

    public MovieController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MovieModel>>> Get()
    {
        return await _context.MovieModels.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MovieModel>> Get(int id)
    {
        var item = await _context.MovieModels.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        return item;
    }

    [HttpPost]
    public async Task<ActionResult<MovieModel>> Post([FromBody] MovieModel item)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        item.CreatedAt = DateTime.UtcNow;
        item.UpdatedAt = DateTime.UtcNow;

        _context.MovieModels.Add(item);
        await _context.SaveChangesAsync();

        var formattedItem = new
        {
            item.Id,
            item.Title,
            item.Description,
            item.Rating,
            item.Image,
            created_at = item.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss"),
            updated_at = item.UpdatedAt.ToString("yyyy-MM-dd HH:mm:ss")
        };

        return CreatedAtAction(nameof(Get), new { id = item.Id }, formattedItem);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, MovieModel item)
    {
        if (id != item.Id)
        {
            return BadRequest();
        }

        item.UpdatedAt = DateTime.UtcNow;

        _context.Entry(item).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MovieModels.Any(e => e.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.MovieModels.FindAsync(id);

        if (item == null)
        {
            return NotFound();
        }

        _context.MovieModels.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
