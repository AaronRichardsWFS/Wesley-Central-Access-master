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
    public class ZworkerController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZworkerController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zworker
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zworker.ToListAsync());
        }

        // GET: Zworker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zworker = await _context.Zworker
                .FirstOrDefaultAsync(m => m.ZworkerId == id);
            if (zworker == null)
            {
                return NotFound();
            }

            return View(zworker);
        }

        // GET: Zworker/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zworker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZworkerId,worker,report,active,UserName")] Zworker zworker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zworker);
                TempData["Alert"] = String.Format("Added Worker: {0}", zworker.worker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zworker);
        }

        // GET: Zworker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zworker = await _context.Zworker.FindAsync(id);
            if (zworker == null)
            {
                return NotFound();
            }
            return View(zworker);
        }

        // POST: Zworker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZworkerId,worker,report,active,UserName")] Zworker zworker)
        {
            if (id != zworker.ZworkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zworker);
                    TempData["Alert"] = String.Format("Saved Changes to Worker: {0}", zworker.worker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZworkerExists(zworker.ZworkerId))
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
            return View(zworker);
        }

        // GET: Zworker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zworker = await _context.Zworker
                .FirstOrDefaultAsync(m => m.ZworkerId == id);
            if (zworker == null)
            {
                return NotFound();
            }

            return View(zworker);
        }

        // POST: Zworker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zworker = await _context.Zworker.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Worker: {0}", zworker.worker);
            _context.Zworker.Remove(zworker);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZworkerExists(int id)
        {
            return _context.Zworker.Any(e => e.ZworkerId == id);
        }
    }
}
