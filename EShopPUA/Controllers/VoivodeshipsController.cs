using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EShopPUA.Models;

namespace EShopPUA.Controllers
{
    public class VoivodeshipsController : Controller
    {
        private readonly DatabaseEShopContext _context;

        public VoivodeshipsController(DatabaseEShopContext context)
        {
            _context = context;
        }

        // GET: Voivodeships
        public async Task<IActionResult> Index()
        {
              return _context.Voivodeships != null ? 
                          View(await _context.Voivodeships.ToListAsync()) :
                          Problem("Entity set 'DatabaseEShopContext.Voivodeships'  is null.");
        }

        // GET: Voivodeships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Voivodeships == null)
            {
                return NotFound();
            }

            var voivodeship = await _context.Voivodeships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voivodeship == null)
            {
                return NotFound();
            }

            return View(voivodeship);
        }

        // GET: Voivodeships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voivodeships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Voivodeship voivodeship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voivodeship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voivodeship);
        }

        // GET: Voivodeships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Voivodeships == null)
            {
                return NotFound();
            }

            var voivodeship = await _context.Voivodeships.FindAsync(id);
            if (voivodeship == null)
            {
                return NotFound();
            }
            return View(voivodeship);
        }

        // POST: Voivodeships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Voivodeship voivodeship)
        {
            if (id != voivodeship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voivodeship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoivodeshipExists(voivodeship.Id))
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
            return View(voivodeship);
        }

        // GET: Voivodeships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Voivodeships == null)
            {
                return NotFound();
            }

            var voivodeship = await _context.Voivodeships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (voivodeship == null)
            {
                return NotFound();
            }

            return View(voivodeship);
        }

        // POST: Voivodeships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Voivodeships == null)
            {
                return Problem("Entity set 'DatabaseEShopContext.Voivodeships'  is null.");
            }
            var voivodeship = await _context.Voivodeships.FindAsync(id);
            if (voivodeship != null)
            {
                _context.Voivodeships.Remove(voivodeship);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoivodeshipExists(int id)
        {
          return (_context.Voivodeships?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
