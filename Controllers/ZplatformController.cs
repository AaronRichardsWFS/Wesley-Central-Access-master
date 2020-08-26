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
    public class ZplatformController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZplatformController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zplatform
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zplatform.ToListAsync());
        }

        // GET: Zplatform/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zplatform = await _context.Zplatform
                .FirstOrDefaultAsync(m => m.ZplatformId == id);
            if (zplatform == null)
            {
                return NotFound();
            }

            return View(zplatform);
        }

        // GET: Zplatform/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zplatform/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZplatformId,internalId,opplatform")] Zplatform zplatform)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zplatform);
                TempData["Alert"] = String.Format("Added Platform: {0}", zplatform.opplatform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zplatform);
        }

        // GET: Zplatform/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zplatform = await _context.Zplatform.FindAsync(id);
            if (zplatform == null)
            {
                return NotFound();
            }
            return View(zplatform);
        }

        // POST: Zplatform/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZplatformId,internalId,opplatform")] Zplatform zplatform)
        {
            if (id != zplatform.ZplatformId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zplatform);
                    TempData["Alert"] = String.Format("Saved Changes to Platform: {0}", zplatform.opplatform);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZplatformExists(zplatform.ZplatformId))
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
            return View(zplatform);
        }

        // GET: Zplatform/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zplatform = await _context.Zplatform
                .FirstOrDefaultAsync(m => m.ZplatformId == id);
            if (zplatform == null)
            {
                return NotFound();
            }

            return View(zplatform);
        }

        // POST: Zplatform/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zplatform = await _context.Zplatform.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Platform: {0}", zplatform.opplatform);
            _context.Zplatform.Remove(zplatform);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZplatformExists(int id)
        {
            return _context.Zplatform.Any(e => e.ZplatformId == id);
        }
    }
}
