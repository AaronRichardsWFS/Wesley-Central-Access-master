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
    public class ZprogramsController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZprogramsController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zprograms
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zprograms.ToListAsync());
        }

        // GET: Zprograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zprograms = await _context.Zprograms
                .FirstOrDefaultAsync(m => m.ZprogramsId == id);
            if (zprograms == null)
            {
                return NotFound();
            }

            return View(zprograms);
        }

        // GET: Zprograms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zprograms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZprogramsId,programs_id,program_desc,active")] Zprograms zprograms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zprograms);
                TempData["Alert"] = String.Format("Added Program: {0}", zprograms.programs_id);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zprograms);
        }

        // GET: Zprograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zprograms = await _context.Zprograms.FindAsync(id);
            if (zprograms == null)
            {
                return NotFound();
            }
            return View(zprograms);
        }

        // POST: Zprograms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZprogramsId,programs_id,program_desc,active")] Zprograms zprograms)
        {
            if (id != zprograms.ZprogramsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zprograms);
                    TempData["Alert"] = String.Format("Saved Changes to Program: {0}", zprograms.programs_id);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZprogramsExists(zprograms.ZprogramsId))
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
            return View(zprograms);
        }

        // GET: Zprograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zprograms = await _context.Zprograms
                .FirstOrDefaultAsync(m => m.ZprogramsId == id);
            if (zprograms == null)
            {
                return NotFound();
            }

            return View(zprograms);
        }

        // POST: Zprograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zprograms = await _context.Zprograms.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Program: {0}", zprograms.programs_id);
            _context.Zprograms.Remove(zprograms);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZprogramsExists(int id)
        {
            return _context.Zprograms.Any(e => e.ZprogramsId == id);
        }
    }
}
