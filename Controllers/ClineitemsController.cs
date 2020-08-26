using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCAProject.Data;
using WCAProject.Models;
using WCAProject.ViewModels;

namespace WCAProject.Controllers
{
    public class ClineitemsController : Controller
    {
        private readonly WCAProjectContext _context;

        public ClineitemsController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Clineitems
        public async Task<IActionResult> Index()
        {
            var wCAProjectContext = _context.Clineitems.Include(c => c.ClientService).Include(c => c.Zworker);
            return View(await wCAProjectContext.ToListAsync());
        }

        // GET: Clineitems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clineitem = await _context.Clineitems
                .Include(c => c.ClientService)
                .Include(c => c.Zworker)
                .FirstOrDefaultAsync(m => m.ClineitemId == id);
            if (clineitem == null)
            {
                return NotFound();
            }

            return View(clineitem);
        }

        // GET: Clineitems/Create
        public async Task<IActionResult> Create(int csid)
        {

            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId");
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.OrderBy(m => m.worker), "ZworkerId", "worker");

            InquiryFormViewModel inquiryFormViewModel = new InquiryFormViewModel();
            inquiryFormViewModel.Inquiry = await _context.ClientServices.FirstOrDefaultAsync(cs => cs.ClientServiceId == csid);
            inquiryFormViewModel.Client = await _context.Clients.FirstOrDefaultAsync(c => c.ClientId == inquiryFormViewModel.Inquiry.ClientId);
            inquiryFormViewModel.Note = new Clineitem{ClientServiceId = inquiryFormViewModel.Inquiry.ClientServiceId};
            inquiryFormViewModel.Note.ldate = DateTime.Now;
            inquiryFormViewModel.Notes = await _context.Clineitems.Where(ci => ci.ClientServiceId == inquiryFormViewModel.Inquiry.ClientServiceId).OrderByDescending(ci => ci.ldate).ToListAsync();
            return View(inquiryFormViewModel);
        }

        // POST: Clineitems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InquiryFormViewModel inquiryFormViewModel)
        {
            ClientService cs = inquiryFormViewModel.Inquiry;
            Clineitem ci = inquiryFormViewModel.Note;
            if (ModelState.IsValid)
            {
                ci.ClientServiceId = cs.ClientServiceId;
                _context.Add(ci);
                await _context.SaveChangesAsync();
                TempData["Alert"] = "Created Note";
                return RedirectToAction("Details", "ClientServices", new {id = cs.ClientServiceId});
            }
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", ci.ClientServiceId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.OrderBy(m => m.worker), "ZworkerId", "worker", ci.ZworkerId);
            return View(inquiryFormViewModel);
        }

        // GET: Clineitems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clineitem = await _context.Clineitems.FindAsync(id);
            if (clineitem == null)
            {
                return NotFound();
            }
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", clineitem.ClientServiceId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.OrderBy(m => m.worker), "ZworkerId", "worker", clineitem.ZworkerId);

            InquiryFormViewModel inquiryFormViewModel = new InquiryFormViewModel();
            inquiryFormViewModel.Inquiry = await _context.ClientServices.FirstOrDefaultAsync(cs => cs.ClientServiceId == clineitem.ClientServiceId);
            inquiryFormViewModel.Note = clineitem;

            return View(inquiryFormViewModel);
        }

        // POST: Clineitems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InquiryFormViewModel inquiryFormViewModel)
        {
            Clineitem ci = inquiryFormViewModel.Note;
            if (id != ci.ClineitemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ci);
                    TempData["Alert"] = "Saved Changes to Note";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClineitemExists(ci.ClineitemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "ClientServices", new {id = ci.ClientServiceId});
            }
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", ci.ClientServiceId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.OrderBy(m => m.worker), "ZworkerId", "worker", ci.ZworkerId);
            return View(inquiryFormViewModel);
        }

        // GET: Clineitems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clineitem = await _context.Clineitems
                .Include(c => c.ClientService)
                .Include(c => c.Zworker)
                .FirstOrDefaultAsync(m => m.ClineitemId == id);
            if (clineitem == null)
            {
                return NotFound();
            }

            return View(clineitem);
        }

        // POST: Clineitems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clineitem = await _context.Clineitems.FindAsync(id);
            _context.Clineitems.Remove(clineitem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClineitemExists(int id)
        {
            return _context.Clineitems.Any(e => e.ClineitemId == id);
        }
    }
}
