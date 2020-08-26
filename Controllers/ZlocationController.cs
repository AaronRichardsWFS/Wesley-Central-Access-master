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
    public class ZlocationController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZlocationController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zlocation
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zlocation.ToListAsync());
        }

        // GET: Zlocation/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlocation = await _context.Zlocation
                .FirstOrDefaultAsync(m => m.ZlocationId == id);
            if (zlocation == null)
            {
                return NotFound();
            }

            return View(zlocation);
        }

        // GET: Zlocation/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zlocation/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZlocationId,location,report,active,credstatus,temp")] Zlocation zlocation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zlocation);
                TempData["Alert"] = String.Format("Added Location: {0}", zlocation.location);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zlocation);
        }

        // GET: Zlocation/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlocation = await _context.Zlocation.FindAsync(id);
            if (zlocation == null)
            {
                return NotFound();
            }
            return View(zlocation);
        }

        // POST: Zlocation/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZlocationId,location,report,active,credstatus,temp")] Zlocation zlocation)
        {
            if (id != zlocation.ZlocationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zlocation);
                    TempData["Alert"] = String.Format("Saved Changes to Location: {0}", zlocation.location);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZlocationExists(zlocation.ZlocationId))
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
            return View(zlocation);
        }

        // GET: Zlocation/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zlocation = await _context.Zlocation
                .FirstOrDefaultAsync(m => m.ZlocationId == id);
            if (zlocation == null)
            {
                return NotFound();
            }

            return View(zlocation);
        }

        // POST: Zlocation/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zlocation = await _context.Zlocation.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Location: {0}", zlocation.location);
            _context.Zlocation.Remove(zlocation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZlocationExists(int id)
        {
            return _context.Zlocation.Any(e => e.ZlocationId == id);
        }
    }
}
