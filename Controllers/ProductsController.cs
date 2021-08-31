using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _08312021_Empite_Co_Solution.Data;
using _08312021_Empite_Co_Solution.Models;

namespace _08312021_Empite_Co_Solution.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.iProducts.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDTOs = await _context.iProducts
                .FirstOrDefaultAsync(m => m.PID == id);
            if (productDTOs == null)
            {
                return NotFound();
            }

            return View(productDTOs);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PID,SKU,Barcode,Name,QTY,status")] ProductDTOs productDTOs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productDTOs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productDTOs);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDTOs = await _context.iProducts.FindAsync(id);
            if (productDTOs == null)
            {
                return NotFound();
            }
            return View(productDTOs);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PID,SKU,Barcode,Name,QTY,status")] ProductDTOs productDTOs)
        {
            if (id != productDTOs.PID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productDTOs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductDTOsExists(productDTOs.PID))
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
            return View(productDTOs);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDTOs = await _context.iProducts
                .FirstOrDefaultAsync(m => m.PID == id);
            if (productDTOs == null)
            {
                return NotFound();
            }

            return View(productDTOs);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productDTOs = await _context.iProducts.FindAsync(id);
            _context.iProducts.Remove(productDTOs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDTOsExists(int id)
        {
            return _context.iProducts.Any(e => e.PID == id);
        }
    }
}
