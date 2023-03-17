using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class CCartInfoesController : Controller
    {
        private readonly ProductAppContext _context;

        public CCartInfoesController(ProductAppContext context)
        {
            _context = context;
        }

        // GET: CCartInfoes
        public async Task<IActionResult> Index()
        {
            try
            {
                var cartData = TempData["Cart"];
                return _context.CCartInfo != null ? View(await _context.CCartInfo.ToListAsync()) : View(cartData);
                 
                
            }
            catch (Exception ex)
            {
                return NoContent();
            }
              
        }

        // GET: CCartInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CCartInfo == null)
            {
                return NotFound();
            }

            var cCartInfo = await _context.CCartInfo
                .FirstOrDefaultAsync(m => m.productId == id);
            if (cCartInfo == null)
            {
                return NotFound();
            }

            return View(cCartInfo);
        }

        // GET: CCartInfoes/Create
        public IActionResult Create(int id)
        {
            var prodData = _context.CProductInfo.FirstOrDefaultAsync(m => m.productId == id);
            ViewBag.CProduct = prodData;
            return View();
        }

        // POST: CCartInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productId,productName,productQty,productPrice")] CCartInfo cCartInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cCartInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cCartInfo);
        }

        // GET: CCartInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CCartInfo == null)
            {
                return NotFound();
            }

            var cCartInfo = await _context.CCartInfo.FindAsync(id);
            if (cCartInfo == null)
            {
                return NotFound();
            }
            return View(cCartInfo);
        }

        // POST: CCartInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productId,productName,productQty,productPrice")] CCartInfo cCartInfo)
        {
            if (id != cCartInfo.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cCartInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CCartInfoExists(cCartInfo.productId))
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
            return View(cCartInfo);
        }

        // GET: CCartInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CCartInfo == null)
            {
                return NotFound();
            }

            var cCartInfo = await _context.CCartInfo
                .FirstOrDefaultAsync(m => m.productId == id);
            if (cCartInfo == null)
            {
                return NotFound();
            }

            return View(cCartInfo);
        }

        // POST: CCartInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CCartInfo == null)
            {
                return Problem("Entity set 'ProductAppContext.CCartInfo'  is null.");
            }
            var cCartInfo = await _context.CCartInfo.FindAsync(id);
            if (cCartInfo != null)
            {
                _context.CCartInfo.Remove(cCartInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        
        private bool CCartInfoExists(int id)
        {
          return (_context.CCartInfo?.Any(e => e.productId == id)).GetValueOrDefault();
        }
    }
}
