using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCAProject.Data;
using WCAProject.Models;

namespace WCAProject.Controllers
{
    public class ZinternalcategoryController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZinternalcategoryController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zinternalcategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zinternalcategory.ToListAsync());
        }

        // GET: Zinternalcategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinternalcategory = await _context.Zinternalcategory
                .FirstOrDefaultAsync(m => m.ZinternalcategoryId == id);
            if (zinternalcategory == null)
            {
                return NotFound();
            }

            return View(zinternalcategory);
        }

        // GET: Zinternalcategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zinternalcategory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZinternalcategoryId,internalsubcat")] Zinternalcategory zinternalcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zinternalcategory);
                TempData["Alert"] = String.Format("Added Internal Category: {0}", zinternalcategory.internalsubcat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zinternalcategory);
        }

        // GET: Zinternalcategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinternalcategory = await _context.Zinternalcategory.FindAsync(id);
            if (zinternalcategory == null)
            {
                return NotFound();
            }
            return View(zinternalcategory);
        }

        // POST: Zinternalcategory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZinternalcategoryId,internalsubcat")] Zinternalcategory zinternalcategory)
        {
            if (id != zinternalcategory.ZinternalcategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zinternalcategory);
                    TempData["Alert"] = String.Format("Saved Changes to Internal Category: {0}", zinternalcategory.internalsubcat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZinternalcategoryExists(zinternalcategory.ZinternalcategoryId))
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
            return View(zinternalcategory);
        }

        // GET: Zinternalcategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinternalcategory = await _context.Zinternalcategory
                .FirstOrDefaultAsync(m => m.ZinternalcategoryId == id);
            if (zinternalcategory == null)
            {
                return NotFound();
            }

            return View(zinternalcategory);
        }

        // POST: Zinternalcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zinternalcategory = await _context.Zinternalcategory.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Internal Category: {0}", zinternalcategory.internalsubcat);
            _context.Zinternalcategory.Remove(zinternalcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZinternalcategoryExists(int id)
        {
            return _context.Zinternalcategory.Any(e => e.ZinternalcategoryId == id);
        }
    }
}
