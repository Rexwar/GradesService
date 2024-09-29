using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradesService.Models;
using GradesService.Data;
using System;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class GradesController : ControllerBase
{
    private readonly GradesContext _context;

    public GradesController(GradesContext context)
    {
        _context = context;
    }

    // POST: api/Grades
    [HttpPost]
    public async Task<ActionResult<Grade>> PostGrade(Grade grade)
    {
        grade.Id = Guid.NewGuid();
        _context.Grades.Add(grade);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetGrade", new { id = grade.Id }, grade);
    }

    // GET: api/Grades/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Grade>> GetGrade(Guid id)
    {
        var grade = await _context.Grades.FindAsync(id);
        if (grade == null)
        {
            return NotFound();
        }
        return grade;
    }

    // PUT: api/Grades/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGrade(Guid id, Grade grade)
    {
        if (id != grade.Id)
        {
            return BadRequest();
        }

        _context.Entry(grade).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Grades.Any(e => e.Id == id))
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
}
