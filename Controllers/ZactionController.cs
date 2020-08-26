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
    public class ZactionController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZactionController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zaction
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zaction.ToListAsync());
        }

        // GET: Zaction/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaction = await _context.Zaction
                .FirstOrDefaultAsync(m => m.ZactionId == id);
            if (zaction == null)
            {
                return NotFound();
            }

            return View(zaction);
        }

        // GET: Zaction/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZactionId,action,report,active")] Zaction zaction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zaction);
                TempData["Alert"] = String.Format("Added Action: {0}", zaction.action);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zaction);
        }

        // GET: Zaction/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaction = await _context.Zaction.FindAsync(id);
            if (zaction == null)
            {
                return NotFound();
            }
            return View(zaction);
        }

        // POST: Zaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZactionId,action,report,active")] Zaction zaction)
        {
            if (id != zaction.ZactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zaction);
                    TempData["Alert"] = String.Format("Saved Changes to Action: {0}", zaction.action);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZactionExists(zaction.ZactionId))
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
            return View(zaction);
        }

        // GET: Zaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zaction = await _context.Zaction
                .FirstOrDefaultAsync(m => m.ZactionId == id);
            if (zaction == null)
            {
                return NotFound();
            }

            return View(zaction);
        }

        // POST: Zaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zaction = await _context.Zaction.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Action: {0}", zaction.action);
            _context.Zaction.Remove(zaction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZactionExists(int id)
        {
            return _context.Zaction.Any(e => e.ZactionId == id);
        }
    }
}
