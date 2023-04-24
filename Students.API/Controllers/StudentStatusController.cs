using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Students.API.Models;

namespace Students.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentStatusController : ControllerBase
    {
        private readonly StudentsDbContext _context;

        public StudentStatusController(StudentsDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentStatus>>> GetStudentStatuses()
        {
          if (_context.StudentStatuses == null)
          {
              return NotFound();
          }
            return await _context.StudentStatuses.ToListAsync();
        }

        // GET: api/StudentStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentStatus>> GetStudentStatus(long id)
        {
          if (_context.StudentStatuses == null)
          {
              return NotFound();
          }
            var studentStatus = await _context.StudentStatuses.FindAsync(id);

            if (studentStatus == null)
            {
                return NotFound();
            }

            return studentStatus;
        }

        // PUT: api/StudentStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentStatus(long id, StudentStatus studentStatus)
        {
            if (id != studentStatus.StatusId)
            {
                return BadRequest();
            }

            _context.Entry(studentStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentStatusExists(id))
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

        // POST: api/StudentStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentStatus>> PostStudentStatus(StudentStatus studentStatus)
        {
          if (_context.StudentStatuses == null)
          {
              return Problem("Entity set 'StudentsDbContext.StudentStatuses'  is null.");
          }
            _context.StudentStatuses.Add(studentStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentStatus", new { id = studentStatus.StatusId }, studentStatus);
        }

        // DELETE: api/StudentStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentStatus(long id)
        {
            if (_context.StudentStatuses == null)
            {
                return NotFound();
            }
            var studentStatus = await _context.StudentStatuses.FindAsync(id);
            if (studentStatus == null)
            {
                return NotFound();
            }

            _context.StudentStatuses.Remove(studentStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentStatusExists(long id)
        {
            return (_context.StudentStatuses?.Any(e => e.StatusId == id)).GetValueOrDefault();
        }
    }
}
