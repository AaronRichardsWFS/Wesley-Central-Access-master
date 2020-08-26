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
    public class ZreasonController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZreasonController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zreason
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zreason.ToListAsync());
        }

        // GET: Zreason/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zreason = await _context.Zreason
                .FirstOrDefaultAsync(m => m.ZreasonId == id);
            if (zreason == null)
            {
                return NotFound();
            }

            return View(zreason);
        }

        // GET: Zreason/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zreason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZreasonId,final_reason,report,active,status_match")] Zreason zreason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zreason);
                TempData["Alert"] = String.Format("Added Reason: {0}", zreason.final_reason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zreason);
        }

        // GET: Zreason/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zreason = await _context.Zreason.FindAsync(id);
            if (zreason == null)
            {
                return NotFound();
            }
            return View(zreason);
        }

        // POST: Zreason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZreasonId,final_reason,report,active,status_match")] Zreason zreason)
        {
            if (id != zreason.ZreasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zreason);
                    TempData["Alert"] = String.Format("Saved Changes to Reason: {0}", zreason.final_reason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZreasonExists(zreason.ZreasonId))
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
            return View(zreason);
        }

        // GET: Zreason/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zreason = await _context.Zreason
                .FirstOrDefaultAsync(m => m.ZreasonId == id);
            if (zreason == null)
            {
                return NotFound();
            }

            return View(zreason);
        }

        // POST: Zreason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zreason = await _context.Zreason.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Reason: {0}", zreason.final_reason);
            _context.Zreason.Remove(zreason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZreasonExists(int id)
        {
            return _context.Zreason.Any(e => e.ZreasonId == id);
        }
    }
}
