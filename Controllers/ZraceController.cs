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
    public class ZraceController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZraceController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zrace
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zrace.ToListAsync());
        }

        // GET: Zrace/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zrace = await _context.Zrace
                .FirstOrDefaultAsync(m => m.ZraceId == id);
            if (zrace == null)
            {
                return NotFound();
            }

            return View(zrace);
        }

        // GET: Zrace/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zrace/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZraceId,race,active")] Zrace zrace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zrace);
                TempData["Alert"] = String.Format("Added Race: {0}", zrace.race);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zrace);
        }

        // GET: Zrace/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zrace = await _context.Zrace.FindAsync(id);
            if (zrace == null)
            {
                return NotFound();
            }
            return View(zrace);
        }

        // POST: Zrace/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZraceId,race,active")] Zrace zrace)
        {
            if (id != zrace.ZraceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zrace);
                    TempData["Alert"] = String.Format("Saved Changes to Race: {0}", zrace.race);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZraceExists(zrace.ZraceId))
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
            return View(zrace);
        }

        // GET: Zrace/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zrace = await _context.Zrace
                .FirstOrDefaultAsync(m => m.ZraceId == id);
            if (zrace == null)
            {
                return NotFound();
            }

            return View(zrace);
        }

        // POST: Zrace/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zrace = await _context.Zrace.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Race: {0}", zrace.race);
            _context.Zrace.Remove(zrace);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZraceExists(int id)
        {
            return _context.Zrace.Any(e => e.ZraceId == id);
        }
    }
}
