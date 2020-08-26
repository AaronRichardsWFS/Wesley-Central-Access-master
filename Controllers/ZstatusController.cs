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
    public class ZstatusController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZstatusController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zstatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zstatus.ToListAsync());
        }

        // GET: Zstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zstatus = await _context.Zstatus
                .FirstOrDefaultAsync(m => m.ZstatusId == id);
            if (zstatus == null)
            {
                return NotFound();
            }

            return View(zstatus);
        }

        // GET: Zstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zstatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZstatusId,inq_status,report,active,credstatus,temp")] Zstatus zstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zstatus);
                TempData["Alert"] = String.Format("Added Status: {0}", zstatus.inq_status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zstatus);
        }

        // GET: Zstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zstatus = await _context.Zstatus.FindAsync(id);
            if (zstatus == null)
            {
                return NotFound();
            }
            return View(zstatus);
        }

        // POST: Zstatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZstatusId,inq_status,report,active,credstatus,temp")] Zstatus zstatus)
        {
            if (id != zstatus.ZstatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zstatus);
                    TempData["Alert"] = String.Format("Saved Changes to Status: {0}", zstatus.inq_status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZstatusExists(zstatus.ZstatusId))
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
            return View(zstatus);
        }

        // GET: Zstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zstatus = await _context.Zstatus
                .FirstOrDefaultAsync(m => m.ZstatusId == id);
            if (zstatus == null)
            {
                return NotFound();
            }

            return View(zstatus);
        }

        // POST: Zstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zstatus = await _context.Zstatus.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Status: {0}", zstatus.inq_status);
            _context.Zstatus.Remove(zstatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZstatusExists(int id)
        {
            return _context.Zstatus.Any(e => e.ZstatusId == id);
        }
    }
}
