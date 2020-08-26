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
    public class ZhearaboutController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZhearaboutController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zhearabout
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zhearabout.ToListAsync());
        }

        // GET: Zhearabout/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zhearabout = await _context.Zhearabout
                .FirstOrDefaultAsync(m => m.ZhearaboutId == id);
            if (zhearabout == null)
            {
                return NotFound();
            }

            return View(zhearabout);
        }

        // GET: Zhearabout/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zhearabout/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZhearaboutId,hearabout")] Zhearabout zhearabout)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zhearabout);
                TempData["Alert"] = String.Format("Added Hear About: {0}", zhearabout.hearabout);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zhearabout);
        }

        // GET: Zhearabout/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zhearabout = await _context.Zhearabout.FindAsync(id);
            if (zhearabout == null)
            {
                return NotFound();
            }
            return View(zhearabout);
        }

        // POST: Zhearabout/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZhearaboutId,hearabout")] Zhearabout zhearabout)
        {
            if (id != zhearabout.ZhearaboutId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zhearabout);
                    TempData["Alert"] = String.Format("Saved Changes to Hear About: {0}", zhearabout.hearabout);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZhearaboutExists(zhearabout.ZhearaboutId))
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
            return View(zhearabout);
        }

        // GET: Zhearabout/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zhearabout = await _context.Zhearabout
                .FirstOrDefaultAsync(m => m.ZhearaboutId == id);
            if (zhearabout == null)
            {
                return NotFound();
            }

            return View(zhearabout);
        }

        // POST: Zhearabout/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zhearabout = await _context.Zhearabout.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Hear About: {0}", zhearabout.hearabout);
            _context.Zhearabout.Remove(zhearabout);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZhearaboutExists(int id)
        {
            return _context.Zhearabout.Any(e => e.ZhearaboutId == id);
        }
    }
}
