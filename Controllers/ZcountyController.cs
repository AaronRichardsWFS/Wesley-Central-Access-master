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
    public class ZcountyController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZcountyController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zcounty
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zcounty.ToListAsync());
        }

        // GET: Zcounty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zcounty = await _context.Zcounty
                .FirstOrDefaultAsync(m => m.ZcountyId == id);
            if (zcounty == null)
            {
                return NotFound();
            }

            return View(zcounty);
        }

        // GET: Zcounty/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zcounty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZcountyId,county")] Zcounty zcounty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zcounty);
                TempData["Alert"] = String.Format("Added County: {0}", zcounty.county);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zcounty);
        }

        // GET: Zcounty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zcounty = await _context.Zcounty.FindAsync(id);
            if (zcounty == null)
            {
                return NotFound();
            }
            return View(zcounty);
        }

        // POST: Zcounty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZcountyId,county")] Zcounty zcounty)
        {
            if (id != zcounty.ZcountyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zcounty);
                    TempData["Alert"] = String.Format("Saved Changes to County: {0}", zcounty.county);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZcountyExists(zcounty.ZcountyId))
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
            return View(zcounty);
        }

        // GET: Zcounty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zcounty = await _context.Zcounty
                .FirstOrDefaultAsync(m => m.ZcountyId == id);
            if (zcounty == null)
            {
                return NotFound();
            }

            return View(zcounty);
        }

        // POST: Zcounty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zcounty = await _context.Zcounty.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted County: {0}", zcounty.county);
            _context.Zcounty.Remove(zcounty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZcountyExists(int id)
        {
            return _context.Zcounty.Any(e => e.ZcountyId == id);
        }
    }
}
