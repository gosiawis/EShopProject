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
    public class OrdersController : Controller
    {
        private readonly DatabaseEShopContext _context;

        public OrdersController(DatabaseEShopContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var databaseEShopContext = _context.Orders.Include(o => o.Client).Include(o => o.OrderStatus).Include(o => o.PaymentMethod).Include(o => o.PaymentStatus);
            return View(await databaseEShopContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.OrderStatus)
                .Include(o => o.PaymentMethod)
                .Include(o => o.PaymentStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Id");
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,OrderStatusId,PaymentStatusId,PaymentMethodId,StartDate,EndDate,Price")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", order.ClientId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", order.OrderStatusId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Id", order.PaymentMethodId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "Id", "Id", order.PaymentStatusId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", order.ClientId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", order.OrderStatusId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Id", order.PaymentMethodId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "Id", "Id", order.PaymentStatusId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,OrderStatusId,PaymentStatusId,PaymentMethodId,StartDate,EndDate,Price")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", order.ClientId);
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id", order.OrderStatusId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "Id", "Id", order.PaymentMethodId);
            ViewData["PaymentStatusId"] = new SelectList(_context.PaymentStatuses, "Id", "Id", order.PaymentStatusId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.OrderStatus)
                .Include(o => o.PaymentMethod)
                .Include(o => o.PaymentStatus)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Orders == null)
            {
                return Problem("Entity set 'DatabaseEShopContext.Orders'  is null.");
            }
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
          return (_context.Orders?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
