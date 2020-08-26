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
    public class ZresourcereasonController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZresourcereasonController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zresourcereason
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zresourcereason.ToListAsync());
        }

        // GET: Zresourcereason/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zresourcereason = await _context.Zresourcereason
                .FirstOrDefaultAsync(m => m.ZresourcereasonId == id);
            if (zresourcereason == null)
            {
                return NotFound();
            }

            return View(zresourcereason);
        }

        // GET: Zresourcereason/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zresourcereason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZresourcereasonId,resourceresult")] Zresourcereason zresourcereason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zresourcereason);
                TempData["Alert"] = String.Format("Added Resource Reason: {0}", zresourcereason.resourceresult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zresourcereason);
        }

        // GET: Zresourcereason/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zresourcereason = await _context.Zresourcereason.FindAsync(id);
            if (zresourcereason == null)
            {
                return NotFound();
            }
            return View(zresourcereason);
        }

        // POST: Zresourcereason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZresourcereasonId,resourceresult")] Zresourcereason zresourcereason)
        {
            if (id != zresourcereason.ZresourcereasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zresourcereason);
                    TempData["Alert"] = String.Format("Saved Changes to Resource Reason: {0}", zresourcereason.resourceresult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZresourcereasonExists(zresourcereason.ZresourcereasonId))
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
            return View(zresourcereason);
        }

        // GET: Zresourcereason/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zresourcereason = await _context.Zresourcereason
                .FirstOrDefaultAsync(m => m.ZresourcereasonId == id);
            if (zresourcereason == null)
            {
                return NotFound();
            }

            return View(zresourcereason);
        }

        // POST: Zresourcereason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zresourcereason = await _context.Zresourcereason.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Resource Reason: {0}", zresourcereason.resourceresult);
            _context.Zresourcereason.Remove(zresourcereason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZresourcereasonExists(int id)
        {
            return _context.Zresourcereason.Any(e => e.ZresourcereasonId == id);
        }
    }
}
