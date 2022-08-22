using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BikersPortal.Data;
using BikersPortal.Models;
using Microsoft.AspNetCore.Authorization;

namespace BikersPortal.Areas.Biker.Controllers
{
    [Authorize]
    [Area("Biker")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Biker/Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Customer).Include(o => o.PaymentMethods).Include(o => o.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Biker/Orders/For user
        public async Task<IActionResult> Index1()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Customer).Include(o => o.PaymentMethods).Include(o => o.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Biker/Orders/Order details
        public async Task<IActionResult> Index2()
        {
            var applicationDbContext = _context.Orders.Include(o => o.Customer).Include(o => o.PaymentMethods).Include(o => o.Product);
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Biker/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.PaymentMethods)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Biker/Orders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentMethodName");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");

            return View();
        }

         // GET: Biker/Orders/Create/for user
        public IActionResult Create1()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentMethodName");
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName");

            return View();
        }

        // POST: Biker/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Date,ProductId,NumberOfProduct,CustomerId,PaymentMethodId,Price,Description,OrderPlaced")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index1));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentMethodName", order.PaymentMethodId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", order.ProductId);
            return View(order);
        }

        // GET: Biker/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentMethodName", order.PaymentMethodId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", order.ProductId);
            return View(order);
        }

        // POST: Biker/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,Date,ProductId,NumberOfProduct,CustomerId,PaymentMethodId,Price,Description,OrderPlaced")] Order order)
        {
            if (id != order.OrderId)
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
                    if (!OrderExists(order.OrderId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerName", order.CustomerId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethod, "PaymentMethodId", "PaymentMethodName", order.PaymentMethodId);
            ViewData["ProductId"] = new SelectList(_context.Products, "ProductId", "ProductName", order.ProductId);
            return View(order);
        }

        // GET: Biker/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.PaymentMethods)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Biker/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
