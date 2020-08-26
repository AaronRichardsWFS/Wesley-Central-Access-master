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
    public class ZopotherController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZopotherController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zopother
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zopother.ToListAsync());
        }

        // GET: Zopother/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zopother = await _context.Zopother
                .FirstOrDefaultAsync(m => m.ZopotherId == id);
            if (zopother == null)
            {
                return NotFound();
            }

            return View(zopother);
        }

        // GET: Zopother/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zopother/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZopotherId,opother")] Zopother zopother)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zopother);
                TempData["Alert"] = String.Format("Added OP Other: {0}", zopother.opother);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zopother);
        }

        // GET: Zopother/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zopother = await _context.Zopother.FindAsync(id);
            if (zopother == null)
            {
                return NotFound();
            }
            return View(zopother);
        }

        // POST: Zopother/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZopotherId,opother")] Zopother zopother)
        {
            if (id != zopother.ZopotherId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zopother);
                    TempData["Alert"] = String.Format("Saved Changes to OP Other: {0}", zopother.opother);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZopotherExists(zopother.ZopotherId))
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
            return View(zopother);
        }

        // GET: Zopother/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zopother = await _context.Zopother
                .FirstOrDefaultAsync(m => m.ZopotherId == id);
            if (zopother == null)
            {
                return NotFound();
            }

            return View(zopother);
        }

        // POST: Zopother/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zopother = await _context.Zopother.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted OP Other: {0}", zopother.opother);
            _context.Zopother.Remove(zopother);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZopotherExists(int id)
        {
            return _context.Zopother.Any(e => e.ZopotherId == id);
        }
    }
}
