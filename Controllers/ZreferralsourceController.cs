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
    public class ZreferralsourceController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZreferralsourceController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zreferralsource
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zreferralsource.ToListAsync());
        }

        // GET: Zreferralsource/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zreferralsource = await _context.Zreferralsource
                .FirstOrDefaultAsync(m => m.ZreferralsourceId == id);
            if (zreferralsource == null)
            {
                return NotFound();
            }

            return View(zreferralsource);
        }

        // GET: Zreferralsource/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zreferralsource/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZreferralsourceId,referralsource")] Zreferralsource zreferralsource)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zreferralsource);
                TempData["Alert"] = String.Format("Added Referral Source: {0}", zreferralsource.referralsource);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zreferralsource);
        }

        // GET: Zreferralsource/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zreferralsource = await _context.Zreferralsource.FindAsync(id);
            if (zreferralsource == null)
            {
                return NotFound();
            }
            return View(zreferralsource);
        }

        // POST: Zreferralsource/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZreferralsourceId,referralsource")] Zreferralsource zreferralsource)
        {
            if (id != zreferralsource.ZreferralsourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zreferralsource);
                    TempData["Alert"] = String.Format("Saved Changes to Referral Source: {0}", zreferralsource.referralsource);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZreferralsourceExists(zreferralsource.ZreferralsourceId))
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
            return View(zreferralsource);
        }

        // GET: Zreferralsource/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zreferralsource = await _context.Zreferralsource
                .FirstOrDefaultAsync(m => m.ZreferralsourceId == id);
            if (zreferralsource == null)
            {
                return NotFound();
            }

            return View(zreferralsource);
        }

        // POST: Zreferralsource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zreferralsource = await _context.Zreferralsource.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Referral Source: {0}", zreferralsource.referralsource);
            _context.Zreferralsource.Remove(zreferralsource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZreferralsourceExists(int id)
        {
            return _context.Zreferralsource.Any(e => e.ZreferralsourceId == id);
        }
    }
}
