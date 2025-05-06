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
    public class Merilna_NapravaAPIController : ControllerBase
    {
        private readonly APKContextTest _context;

        public Merilna_NapravaAPIController(APKContextTest context)
        {
            _context = context;
        }

        // GET: api/Merilna_NapravaAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Merilna_Naprava>>> GetMerilna_Naprava()
        {
            return await _context.Merilna_Naprava.ToListAsync();
        }

        // GET: api/Merilna_NapravaAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Merilna_Naprava>> GetMerilna_Naprava(int id)
        {
            var merilna_Naprava = await _context.Merilna_Naprava.FindAsync(id);

            if (merilna_Naprava == null)
            {
                return NotFound();
            }

            return merilna_Naprava;
        }

        // PUT: api/Merilna_NapravaAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerilna_Naprava(int id, Merilna_Naprava merilna_Naprava)
        {
            if (id != merilna_Naprava.Id)
            {
                return BadRequest();
            }

            _context.Entry(merilna_Naprava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Merilna_NapravaExists(id))
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

        // POST: api/Merilna_NapravaAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Merilna_Naprava>> PostMerilna_Naprava(Merilna_Naprava merilna_Naprava)
        {
            _context.Merilna_Naprava.Add(merilna_Naprava);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerilna_Naprava", new { id = merilna_Naprava.Id }, merilna_Naprava);
        }

        // DELETE: api/Merilna_NapravaAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerilna_Naprava(int id)
        {
            var merilna_Naprava = await _context.Merilna_Naprava.FindAsync(id);
            if (merilna_Naprava == null)
            {
                return NotFound();
            }

            _context.Merilna_Naprava.Remove(merilna_Naprava);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Merilna_NapravaExists(int id)
        {
            return _context.Merilna_Naprava.Any(e => e.Id == id);
        }
    }
}
