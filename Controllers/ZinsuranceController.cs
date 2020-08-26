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
    public class ZinsuranceController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZinsuranceController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zinsurance
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zinsurance.ToListAsync());
        }

        // GET: Zinsurance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinsurance = await _context.Zinsurance
                .FirstOrDefaultAsync(m => m.ZinsuranceId == id);
            if (zinsurance == null)
            {
                return NotFound();
            }

            return View(zinsurance);
        }

        // GET: Zinsurance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zinsurance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZinsuranceId,insurance,report,active")] Zinsurance zinsurance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zinsurance);
                TempData["Alert"] = String.Format("Added Insurance: {0}", zinsurance.insurance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zinsurance);
        }

        // GET: Zinsurance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinsurance = await _context.Zinsurance.FindAsync(id);
            if (zinsurance == null)
            {
                return NotFound();
            }
            return View(zinsurance);
        }

        // POST: Zinsurance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZinsuranceId,insurance,report,active")] Zinsurance zinsurance)
        {
            if (id != zinsurance.ZinsuranceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zinsurance);
                    TempData["Alert"] = String.Format("Saved Changes to Insurance: {0}", zinsurance.insurance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZinsuranceExists(zinsurance.ZinsuranceId))
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
            return View(zinsurance);
        }

        // GET: Zinsurance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zinsurance = await _context.Zinsurance
                .FirstOrDefaultAsync(m => m.ZinsuranceId == id);
            if (zinsurance == null)
            {
                return NotFound();
            }

            return View(zinsurance);
        }

        // POST: Zinsurance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zinsurance = await _context.Zinsurance.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Insurance: {0}", zinsurance.insurance);
            _context.Zinsurance.Remove(zinsurance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZinsuranceExists(int id)
        {
            return _context.Zinsurance.Any(e => e.ZinsuranceId == id);
        }
    }
}
