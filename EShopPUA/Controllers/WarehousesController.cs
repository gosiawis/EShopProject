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
    public class WarehousesController : Controller
    {
        private readonly DatabaseEShopContext _context;

        public WarehousesController(DatabaseEShopContext context)
        {
            _context = context;
        }

        // GET: Warehouses
        public async Task<IActionResult> Index()
        {
            var databaseEShopContext = _context.Warehouses.Include(w => w.District);
            return View(await databaseEShopContext.ToListAsync());
        }

        // GET: Warehouses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Warehouses == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses
                .Include(w => w.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // GET: Warehouses/Create
        public IActionResult Create()
        {
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id");
            return View();
        }

        // POST: Warehouses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DistrictId,City,Street,HouseNumber,ApartmentNumber,ZipCode")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(warehouse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", warehouse.DistrictId);
            return View(warehouse);
        }

        // GET: Warehouses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Warehouses == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse == null)
            {
                return NotFound();
            }
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", warehouse.DistrictId);
            return View(warehouse);
        }

        // POST: Warehouses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DistrictId,City,Street,HouseNumber,ApartmentNumber,ZipCode")] Warehouse warehouse)
        {
            if (id != warehouse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(warehouse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WarehouseExists(warehouse.Id))
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
            ViewData["DistrictId"] = new SelectList(_context.Districts, "Id", "Id", warehouse.DistrictId);
            return View(warehouse);
        }

        // GET: Warehouses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Warehouses == null)
            {
                return NotFound();
            }

            var warehouse = await _context.Warehouses
                .Include(w => w.District)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (warehouse == null)
            {
                return NotFound();
            }

            return View(warehouse);
        }

        // POST: Warehouses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Warehouses == null)
            {
                return Problem("Entity set 'DatabaseEShopContext.Warehouses'  is null.");
            }
            var warehouse = await _context.Warehouses.FindAsync(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WarehouseExists(int id)
        {
          return (_context.Warehouses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
