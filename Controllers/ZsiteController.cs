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
    public class ZsiteController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZsiteController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zsite
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zsite.ToListAsync());
        }

        // GET: Zsite/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zsite = await _context.Zsite
                .FirstOrDefaultAsync(m => m.ZsiteId == id);
            if (zsite == null)
            {
                return NotFound();
            }

            return View(zsite);
        }

        // GET: Zsite/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zsite/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZsiteId,site,report,active")] Zsite zsite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zsite);
                TempData["Alert"] = String.Format("Added Site: {0}", zsite.site);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zsite);
        }

        // GET: Zsite/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zsite = await _context.Zsite.FindAsync(id);
            if (zsite == null)
            {
                return NotFound();
            }
            return View(zsite);
        }

        // POST: Zsite/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZsiteId,site,report,active")] Zsite zsite)
        {
            if (id != zsite.ZsiteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zsite);
                    TempData["Alert"] = String.Format("Saved Changes to Site: {0}", zsite.site);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZsiteExists(zsite.ZsiteId))
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
            return View(zsite);
        }

        // GET: Zsite/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zsite = await _context.Zsite
                .FirstOrDefaultAsync(m => m.ZsiteId == id);
            if (zsite == null)
            {
                return NotFound();
            }

            return View(zsite);
        }

        // POST: Zsite/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zsite = await _context.Zsite.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Site: {0}", zsite.site);
            _context.Zsite.Remove(zsite);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZsiteExists(int id)
        {
            return _context.Zsite.Any(e => e.ZsiteId == id);
        }
    }
}
