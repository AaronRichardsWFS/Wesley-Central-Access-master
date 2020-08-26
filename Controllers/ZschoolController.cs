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
    public class ZschoolController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZschoolController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zschool
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zschool.ToListAsync());
        }

        // GET: Zschool/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zschool = await _context.Zschool
                .FirstOrDefaultAsync(m => m.ZschoolId == id);
            if (zschool == null)
            {
                return NotFound();
            }

            return View(zschool);
        }

        // GET: Zschool/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zschool/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZschoolId,site,schooldistrict,displayname,therapist,ServiceOffered,Supervisor,active")] Zschool zschool)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zschool);
                TempData["Alert"] = String.Format("Added School: {0}", zschool.displayname);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zschool);
        }

        // GET: Zschool/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zschool = await _context.Zschool.FindAsync(id);
            if (zschool == null)
            {
                return NotFound();
            }
            return View(zschool);
        }

        // POST: Zschool/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZschoolId,site,schooldistrict,displayname,therapist,ServiceOffered,Supervisor,active")] Zschool zschool)
        {
            if (id != zschool.ZschoolId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zschool);
                    TempData["Alert"] = String.Format("Saved Changes to School: {0}", zschool.displayname);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZschoolExists(zschool.ZschoolId))
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
            return View(zschool);
        }

        // GET: Zschool/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zschool = await _context.Zschool
                .FirstOrDefaultAsync(m => m.ZschoolId == id);
            if (zschool == null)
            {
                return NotFound();
            }

            return View(zschool);
        }

        // POST: Zschool/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zschool = await _context.Zschool.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted School: {0}", zschool.displayname);
            _context.Zschool.Remove(zschool);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZschoolExists(int id)
        {
            return _context.Zschool.Any(e => e.ZschoolId == id);
        }
    }
}
