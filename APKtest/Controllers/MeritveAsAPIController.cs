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
    public class MeritveAsAPIController : ControllerBase
    {
        private readonly APKContextTest _context;

        public MeritveAsAPIController(APKContextTest context)
        {
            _context = context;
        }

        // GET: api/MeritveAsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeritveA>>> GetMeritve()
        {
            return await _context.Meritve.ToListAsync();
        }

        // GET: api/MeritveAsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MeritveA>> GetMeritveA(int id)
        {
            var meritveA = await _context.Meritve.FindAsync(id);

            if (meritveA == null)
            {
                return NotFound();
            }

            return meritveA;
        }

        // PUT: api/MeritveAsAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeritveA(int id, MeritveA meritveA)
        {
            if (id != meritveA.Id)
            {
                return BadRequest();
            }

            _context.Entry(meritveA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeritveAExists(id))
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

        // POST: api/MeritveAsAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MeritveA>> PostMeritveA(MeritveA meritveA)
        {
            _context.Meritve.Add(meritveA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMeritveA", new { id = meritveA.Id }, meritveA);
        }

        // DELETE: api/MeritveAsAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeritveA(int id)
        {
            var meritveA = await _context.Meritve.FindAsync(id);
            if (meritveA == null)
            {
                return NotFound();
            }

            _context.Meritve.Remove(meritveA);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MeritveAExists(int id)
        {
            return _context.Meritve.Any(e => e.Id == id);
        }
    }
}
