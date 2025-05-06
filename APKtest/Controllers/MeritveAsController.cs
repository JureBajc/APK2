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
    public class MeritveAsController : Controller
    {
        private readonly APKContextTest _context;

        public MeritveAsController(APKContextTest context)
        {
            _context = context;
        }

        // GET: MeritveAs
        public async Task<IActionResult> Index()
        {
            var aPKContextTest = _context.Meritve.Include(m => m.Merilna_Naprava).Include(m => m.Metrolog);
            return View(await aPKContextTest.ToListAsync());
        }

        // GET: MeritveAs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meritveA = await _context.Meritve
                .Include(m => m.Merilna_Naprava)
                .Include(m => m.Metrolog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meritveA == null)
            {
                return NotFound();
            }

            return View(meritveA);
        }

        // GET: MeritveAs/Create
        public IActionResult Create()
        {
            ViewData["Merilna_NapravaId"] = new SelectList(_context.Merilna_Naprava, "Id", "Id");
            ViewData["MetrologId"] = new SelectList(_context.Metrolog, "Id", "Id");
            return View();
        }

        // POST: MeritveAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum_Meritve,Temperatura,Vlažnost,Okvara,Merilna_NapravaId,MetrologId")] MeritveA meritveA)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meritveA);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Merilna_NapravaId"] = new SelectList(_context.Merilna_Naprava, "Id", "Id", meritveA.Merilna_NapravaId);
            ViewData["MetrologId"] = new SelectList(_context.Metrolog, "Id", "Id", meritveA.MetrologId);
            return View(meritveA);
        }

        // GET: MeritveAs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meritveA = await _context.Meritve.FindAsync(id);
            if (meritveA == null)
            {
                return NotFound();
            }
            ViewData["Merilna_NapravaId"] = new SelectList(_context.Merilna_Naprava, "Id", "Id", meritveA.Merilna_NapravaId);
            ViewData["MetrologId"] = new SelectList(_context.Metrolog, "Id", "Id", meritveA.MetrologId);
            return View(meritveA);
        }

        // POST: MeritveAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum_Meritve,Temperatura,Vlažnost,Okvara,Merilna_NapravaId,MetrologId")] MeritveA meritveA)
        {
            if (id != meritveA.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meritveA);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeritveAExists(meritveA.Id))
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
            ViewData["Merilna_NapravaId"] = new SelectList(_context.Merilna_Naprava, "Id", "Id", meritveA.Merilna_NapravaId);
            ViewData["MetrologId"] = new SelectList(_context.Metrolog, "Id", "Id", meritveA.MetrologId);
            return View(meritveA);
        }

        // GET: MeritveAs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meritveA = await _context.Meritve
                .Include(m => m.Merilna_Naprava)
                .Include(m => m.Metrolog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meritveA == null)
            {
                return NotFound();
            }

            return View(meritveA);
        }

        // POST: MeritveAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meritveA = await _context.Meritve.FindAsync(id);
            if (meritveA != null)
            {
                _context.Meritve.Remove(meritveA);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeritveAExists(int id)
        {
            return _context.Meritve.Any(e => e.Id == id);
        }
    }
}
