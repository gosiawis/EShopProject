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
    public class ClientsAddressesController : Controller
    {
        private readonly DatabaseEShopContext _context;

        public ClientsAddressesController(DatabaseEShopContext context)
        {
            _context = context;
        }

        // GET: ClientsAddresses
        public async Task<IActionResult> Index()
        {
            var databaseEShopContext = _context.ClientsAddresses.Include(c => c.Address).Include(c => c.Client);
            return View(await databaseEShopContext.ToListAsync());
        }

        // GET: ClientsAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ClientsAddresses == null)
            {
                return NotFound();
            }

            var clientsAddress = await _context.ClientsAddresses
                .Include(c => c.Address)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientsAddress == null)
            {
                return NotFound();
            }

            return View(clientsAddress);
        }

        // GET: ClientsAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id");
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            return View();
        }

        // POST: ClientsAddresses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,AddressId")] ClientsAddress clientsAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clientsAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", clientsAddress.AddressId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientsAddress.ClientId);
            return View(clientsAddress);
        }

        // GET: ClientsAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ClientsAddresses == null)
            {
                return NotFound();
            }

            var clientsAddress = await _context.ClientsAddresses.FindAsync(id);
            if (clientsAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", clientsAddress.AddressId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientsAddress.ClientId);
            return View(clientsAddress);
        }

        // POST: ClientsAddresses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,AddressId")] ClientsAddress clientsAddress)
        {
            if (id != clientsAddress.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientsAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientsAddressExists(clientsAddress.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Addresses, "Id", "Id", clientsAddress.AddressId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", clientsAddress.ClientId);
            return View(clientsAddress);
        }

        // GET: ClientsAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ClientsAddresses == null)
            {
                return NotFound();
            }

            var clientsAddress = await _context.ClientsAddresses
                .Include(c => c.Address)
                .Include(c => c.Client)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clientsAddress == null)
            {
                return NotFound();
            }

            return View(clientsAddress);
        }

        // POST: ClientsAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ClientsAddresses == null)
            {
                return Problem("Entity set 'DatabaseEShopContext.ClientsAddresses'  is null.");
            }
            var clientsAddress = await _context.ClientsAddresses.FindAsync(id);
            if (clientsAddress != null)
            {
                _context.ClientsAddresses.Remove(clientsAddress);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientsAddressExists(int id)
        {
          return (_context.ClientsAddresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
