using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APKtest.Data;
using APKtest.Models;

namespace APKtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetrologsAPIController : ControllerBase
    {
        private readonly APKContextTest _context;

        public MetrologsAPIController(APKContextTest context)
        {
            _context = context;
        }

        // GET: api/MetrologsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metrolog>>> GetMetrolog()
        {
            return await _context.Metrolog.ToListAsync();
        }

        // GET: api/MetrologsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Metrolog>> GetMetrolog(int id)
        {
            var metrolog = await _context.Metrolog.FindAsync(id);

            if (metrolog == null)
            {
                return NotFound();
            }

            return metrolog;
        }

        // PUT: api/MetrologsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetrolog(int id, Metrolog metrolog)
        {
            if (id != metrolog.Id)
            {
                return BadRequest();
            }

            _context.Entry(metrolog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MetrologExists(id))
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

        // POST: api/MetrologsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Metrolog>> PostMetrolog(Metrolog metrolog)
        {
            _context.Metrolog.Add(metrolog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMetrolog", new { id = metrolog.Id }, metrolog);
        }

        // DELETE: api/MetrologsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetrolog(int id)
        {
            var metrolog = await _context.Metrolog.FindAsync(id);
            if (metrolog == null)
            {
                return NotFound();
            }

            _context.Metrolog.Remove(metrolog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MetrologExists(int id)
        {
            return _context.Metrolog.Any(e => e.Id == id);
        }
    }
}
