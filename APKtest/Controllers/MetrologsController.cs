using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APKtest.Data;
using APKtest.Models;

namespace APKtest.Controllers
{
    public class MetrologsController : Controller
    {
        private readonly APKContextTest _context;

        public MetrologsController(APKContextTest context)
        {
            _context = context;
        }

        // GET: Metrologs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Metrolog.ToListAsync());
        }

        // GET: Metrologs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrolog = await _context.Metrolog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrolog == null)
            {
                return NotFound();
            }

            return View(metrolog);
        }

        // GET: Metrologs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Metrologs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Priimek,Datum_Zaposlitve")] Metrolog metrolog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(metrolog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(metrolog);
        }

        // GET: Metrologs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrolog = await _context.Metrolog.FindAsync(id);
            if (metrolog == null)
            {
                return NotFound();
            }
            return View(metrolog);
        }

        // POST: Metrologs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Priimek,Datum_Zaposlitve")] Metrolog metrolog)
        {
            if (id != metrolog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(metrolog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MetrologExists(metrolog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(metrolog);
        }

        // GET: Metrologs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var metrolog = await _context.Metrolog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (metrolog == null)
            {
                return NotFound();
            }

            return View(metrolog);
        }

        // POST: Metrologs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var metrolog = await _context.Metrolog.FindAsync(id);
            if (metrolog != null)
            {
                _context.Metrolog.Remove(metrolog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MetrologExists(int id)
        {
            return _context.Metrolog.Any(e => e.Id == id);
        }
    }
}
