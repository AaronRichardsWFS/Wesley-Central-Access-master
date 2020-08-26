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
    public class ZyesnoController : Controller
    {
        private readonly WCAProjectContext _context;

        public ZyesnoController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Zyesno
        public async Task<IActionResult> Index()
        {
            return View(await _context.Zyesno.ToListAsync());
        }

        // GET: Zyesno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zyesno = await _context.Zyesno
                .FirstOrDefaultAsync(m => m.ZyesnoId == id);
            if (zyesno == null)
            {
                return NotFound();
            }

            return View(zyesno);
        }

        // GET: Zyesno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zyesno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ZyesnoId,yesno")] Zyesno zyesno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zyesno);
                TempData["Alert"] = String.Format("Added Yes/No: {0}", zyesno.yesno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zyesno);
        }

        // GET: Zyesno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zyesno = await _context.Zyesno.FindAsync(id);
            if (zyesno == null)
            {
                return NotFound();
            }
            return View(zyesno);
        }

        // POST: Zyesno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ZyesnoId,yesno")] Zyesno zyesno)
        {
            if (id != zyesno.ZyesnoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zyesno);
                    TempData["Alert"] = String.Format("Added Yes/No: {0}", zyesno.yesno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZyesnoExists(zyesno.ZyesnoId))
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
            return View(zyesno);
        }

        // GET: Zyesno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var zyesno = await _context.Zyesno
                .FirstOrDefaultAsync(m => m.ZyesnoId == id);
            if (zyesno == null)
            {
                return NotFound();
            }

            return View(zyesno);
        }

        // POST: Zyesno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var zyesno = await _context.Zyesno.FindAsync(id);
            TempData["Alert"] = String.Format("Deleted Yes/No: {0}", zyesno.yesno);
            _context.Zyesno.Remove(zyesno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZyesnoExists(int id)
        {
            return _context.Zyesno.Any(e => e.ZyesnoId == id);
        }
    }
}
