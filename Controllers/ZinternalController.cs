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
    public class ZinternalController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZinternalController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zinternal
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zinternal.ToListAsync());
        }

        // GET: Zinternal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinternal = await _context.Zinternal
                .FirstOrDefaultAsync(m => m.ZinternalId == id);
            if (zinternal == null)
            {
                return NotFound();
            }

            return View(zinternal);
        }

        // GET: Zinternal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zinternal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZinternalId,internal_type,report,active,credstatus,temp")] Zinternal zinternal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zinternal);
                TempData["Alert"] = String.Format("Added Internal Type: {0}", zinternal.internal_type);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zinternal);
        }

        // GET: Zinternal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinternal = await _context.Zinternal.FindAsync(id);
            if (zinternal == null)
            {
                return NotFound();
            }
            return View(zinternal);
        }

        // POST: Zinternal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZinternalId,internal_type,report,active,credstatus,temp")] Zinternal zinternal)
        {
            if (id != zinternal.ZinternalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zinternal);
                    TempData["Alert"] = String.Format("Saved Changes to Internal Type: {0}", zinternal.internal_type);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZinternalExists(zinternal.ZinternalId))
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
            return View(zinternal);
        }

        // GET: Zinternal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinternal = await _context.Zinternal
                .FirstOrDefaultAsync(m => m.ZinternalId == id);
            if (zinternal == null)
            {
                return NotFound();
            }

            return View(zinternal);
        }

        // POST: Zinternal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zinternal = await _context.Zinternal.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Internal Type: {0}", zinternal.internal_type);
            _context.Zinternal.Remove(zinternal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZinternalExists(int id)
        {
            return _context.Zinternal.Any(e => e.ZinternalId == id);
        }
    }
}
