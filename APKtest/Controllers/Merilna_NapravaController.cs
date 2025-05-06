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
    public class Merilna_NapravaController : Controller
    {
        private readonly APKContextTest _context;

        public Merilna_NapravaController(APKContextTest context)
        {
            _context = context;
        }

        // GET: Merilna_Naprava
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merilna_Naprava.ToListAsync());
        }

        // GET: Merilna_Naprava/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merilna_Naprava = await _context.Merilna_Naprava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merilna_Naprava == null)
            {
                return NotFound();
            }

            return View(merilna_Naprava);
        }

        // GET: Merilna_Naprava/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merilna_Naprava/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Zemljepisna_Dolzina,Zempljepisna_Sirina")] Merilna_Naprava merilna_Naprava)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merilna_Naprava);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(merilna_Naprava);
        }

        // GET: Merilna_Naprava/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merilna_Naprava = await _context.Merilna_Naprava.FindAsync(id);
            if (merilna_Naprava == null)
            {
                return NotFound();
            }
            return View(merilna_Naprava);
        }

        // POST: Merilna_Naprava/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Zemljepisna_Dolzina,Zempljepisna_Sirina")] Merilna_Naprava merilna_Naprava)
        {
            if (id != merilna_Naprava.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merilna_Naprava);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Merilna_NapravaExists(merilna_Naprava.Id))
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
            return View(merilna_Naprava);
        }

        // GET: Merilna_Naprava/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merilna_Naprava = await _context.Merilna_Naprava
                .FirstOrDefaultAsync(m => m.Id == id);
            if (merilna_Naprava == null)
            {
                return NotFound();
            }

            return View(merilna_Naprava);
        }

        // POST: Merilna_Naprava/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merilna_Naprava = await _context.Merilna_Naprava.FindAsync(id);
            if (merilna_Naprava != null)
            {
                _context.Merilna_Naprava.Remove(merilna_Naprava);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Merilna_NapravaExists(int id)
        {
            return _context.Merilna_Naprava.Any(e => e.Id == id);
        }
    }
}
