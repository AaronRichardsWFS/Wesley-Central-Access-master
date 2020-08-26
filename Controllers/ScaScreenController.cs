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
    public class ScaScreenController : Controller
    {
        private readonly WCAProjectContext _context;

        public ScaScreenController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: ScaScreen
        public async Task<IActionResult> Index()
        {
            var wCAProjectContext = _context.ScaScreen.Include(s => s.ClientService);
            return View(await wCAProjectContext.ToListAsync());
        }

        // GET: ScaScreen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scaScreen = await _context.ScaScreen
                .Include(s => s.ClientService)
                .FirstOrDefaultAsync(m => m.ScaScreenId == id);
            if (scaScreen == null)
            {
                return NotFound();
            }

            return View(scaScreen);
        }

        // GET: ScaScreen/Create
        public IActionResult Create()
        {
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId");
            return View();
        }

        // POST: ScaScreen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScaScreenId,ClientServiceId,wsclinic,referralsource,whyfamilyseen,treatmenthistory,asddiagnosis,halfwayshelter,recentlymove,outsidevbh,meetcriteria,referraldetails,shelterdetails,wasstatenotified,gennote,privateinsurer,privateinsurance,managedcaretype,requestedlocation,servicerequested,currentcounty")] ScaScreen scaScreen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(scaScreen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", scaScreen.ClientServiceId);
            return View(scaScreen);
        }

        // GET: ScaScreen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scaScreen = await _context.ScaScreen.FindAsync(id);
            if (scaScreen == null)
            {
                return NotFound();
            }
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", scaScreen.ClientServiceId);
            return View(scaScreen);
        }

        // POST: ScaScreen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScaScreenId,ClientServiceId,wsclinic,referralsource,whyfamilyseen,treatmenthistory,asddiagnosis,halfwayshelter,recentlymove,outsidevbh,meetcriteria,referraldetails,shelterdetails,wasstatenotified,gennote,privateinsurer,privateinsurance,managedcaretype,requestedlocation,servicerequested,currentcounty")] ScaScreen scaScreen)
        {
            if (id != scaScreen.ScaScreenId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(scaScreen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ScaScreenExists(scaScreen.ScaScreenId))
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
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", scaScreen.ClientServiceId);
            return View(scaScreen);
        }

        // GET: ScaScreen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var scaScreen = await _context.ScaScreen
                .Include(s => s.ClientService)
                .FirstOrDefaultAsync(m => m.ScaScreenId == id);
            if (scaScreen == null)
            {
                return NotFound();
            }

            return View(scaScreen);
        }

        // POST: ScaScreen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var scaScreen = await _context.ScaScreen.FindAsync(id);
            _context.ScaScreen.Remove(scaScreen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScaScreenExists(int id)
        {
            return _context.ScaScreen.Any(e => e.ScaScreenId == id);
        }
    }
}
