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
    public class ZcaresreasonController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZcaresreasonController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zcaresreason
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zcaresreason.ToListAsync());
        }

        // GET: Zcaresreason/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zcaresreason = await _context.Zcaresreason
                .FirstOrDefaultAsync(m => m.ZcaresreasonId == id);
            if (zcaresreason == null)
            {
                return NotFound();
            }

            return View(zcaresreason);
        }

        // GET: Zcaresreason/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zcaresreason/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZcaresreasonId,caresreason")] Zcaresreason zcaresreason)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zcaresreason);
                TempData["Alert"] = String.Format("Added Cares Reason: {0}", zcaresreason.caresreason);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zcaresreason);
        }

        // GET: Zcaresreason/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zcaresreason = await _context.Zcaresreason.FindAsync(id);
            if (zcaresreason == null)
            {
                return NotFound();
            }
            return View(zcaresreason);
        }

        // POST: Zcaresreason/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZcaresreasonId,caresreason")] Zcaresreason zcaresreason)
        {
            if (id != zcaresreason.ZcaresreasonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zcaresreason);
                    TempData["Alert"] = String.Format("Saved Changes to Cares Reason: {0}", zcaresreason.caresreason);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZcaresreasonExists(zcaresreason.ZcaresreasonId))
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
            return View(zcaresreason);
        }

        // GET: Zcaresreason/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zcaresreason = await _context.Zcaresreason
                .FirstOrDefaultAsync(m => m.ZcaresreasonId == id);
            if (zcaresreason == null)
            {
                return NotFound();
            }

            return View(zcaresreason);
        }

        // POST: Zcaresreason/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zcaresreason = await _context.Zcaresreason.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Cares Reason: {0}", zcaresreason.caresreason);
            _context.Zcaresreason.Remove(zcaresreason);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZcaresreasonExists(int id)
        {
            return _context.Zcaresreason.Any(e => e.ZcaresreasonId == id);
        }
    }
}
