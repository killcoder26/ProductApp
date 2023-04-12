using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    public class CProductInfoesController : Controller
    {
        private readonly ProductAppContext _context;

        public CProductInfoesController(ProductAppContext context)
        {
            _context = context;
        }

        // GET: CProductInfoes
        public async Task<IActionResult> Index()
        {
              return _context.CProductInfo != null ? 
                          View(await _context.CProductInfo.ToListAsync()) :
                          Problem("Entity set 'ProductAppContext.CProductInfo'  is null.");
        }

        // GET: CProductInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CProductInfo == null)
            {
                return NotFound();
            }

            var cProductInfo = await _context.CProductInfo
                .FirstOrDefaultAsync(m => m.productId == id);
            if (cProductInfo == null)
            {
                return NotFound();
            }

            return View(cProductInfo);
        }

        // GET: CProductInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CProductInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productId,productName,productDescription,productCategory,productSubCategory,productStockQty,productAvailQty,productPrice,productImage")] CProductInfo cProductInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cProductInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cProductInfo);
        }

        // GET: CProductInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CProductInfo == null)
            {
                return NotFound();
            }

            var cProductInfo = await _context.CProductInfo.FindAsync(id);
            if (cProductInfo == null)
            {
                return NotFound();
            }
            return View(cProductInfo);
        }

        // POST: CProductInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productId,productName,productDescription,productCategory,productSubCategory,productStockQty,productAvailQty,productPrice,productImage")] CProductInfo cProductInfo)
        {
            if (id != cProductInfo.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cProductInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CProductInfoExists(cProductInfo.productId))
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
            return View(cProductInfo);
        }

        // GET: CProductInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CProductInfo == null)
            {
                return NotFound();
            }

            var cProductInfo = await _context.CProductInfo
                .FirstOrDefaultAsync(m => m.productId == id);
            if (cProductInfo == null)
            {
                return NotFound();
            }

            return View(cProductInfo);
        }

        // POST: CProductInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CProductInfo == null)
            {
                return Problem("Entity set 'ProductAppContext.CProductInfo'  is null.");
            }
            var cProductInfo = await _context.CProductInfo.FindAsync(id);
            if (cProductInfo != null)
            {
                _context.CProductInfo.Remove(cProductInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> AddCart(int? id)
        {
            if(id==null || _context.CProductInfo == null)
            {
                return NotFound();
            }
            var CProductInfo = await _context.CProductInfo.FindAsync(id);
            if (CProductInfo != null)
            {
                return NotFound();
            }
            return View(CProductInfo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult AddCart(int id, [Bind("productId,productName,productPrice")] CCartInfo cCartInfo)
        {
            CCartInfo cart=new CCartInfo();
            if(cCartInfo!=null) {
                cart.productId = id;
                cart.productName=cCartInfo.productName;
                cart.productPrice=cCartInfo.productPrice;
                cart.productQty = 1;  
            }
            Debug.Write("AddtoCart"+cart.productPrice);
            CRepository.CreateCInterface(cart);
            return RedirectToAction(nameof(Index));
        }

       


        private bool CProductInfoExists(int id)
        {
          return (_context.CProductInfo?.Any(e => e.productId == id)).GetValueOrDefault();
        }
    }
}
