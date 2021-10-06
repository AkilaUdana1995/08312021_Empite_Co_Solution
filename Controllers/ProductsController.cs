using _08312021_Empite_Co_Solution.Data;
using _08312021_Empite_Co_Solution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
            return View(await _context.MProducts.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productDTOs = await _context.MProducts
                .FirstOrDefaultAsync(m => m.ItemCode == id);
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
        public async Task<IActionResult> Create([Bind("ItemCode,ItemName,UnitofMeasure,UnitPrice,SupplierCode")] ProductDTOs productDTOs)
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

            var productDTOs = await _context.MProducts.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("ItemCode,ItemName,UnitofMeasure,UnitPrice,SupplierCode")] ProductDTOs productDTOs)
        {
            if (id != productDTOs.ItemCode)
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
                    if (!ProductDTOsExists(productDTOs.ItemCode))
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

            var productDTOs = await _context.MProducts
                .FirstOrDefaultAsync(m => m.ItemCode == id);
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
            var productDTOs = await _context.MProducts.FindAsync(id);
            _context.MProducts.Remove(productDTOs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductDTOsExists(int id)
        {
            return _context.MProducts.Any(e => e.ItemCode == id);
        }
    }
}
