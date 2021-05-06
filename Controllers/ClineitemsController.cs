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
            ViewData["ClientId"] = new SelectList(_context.Clients.OrderBy(m => m.name), "ClientId", "name");
            ViewData["ServiceId"] = new SelectList(_context.Services.OrderBy(m => m.service_desc), "ServiceId", "service_desc");
            ViewData["ZcaresreasonId"] = new SelectList(_context.Zcaresreason.OrderBy(m => m.caresreason), "ZcaresreasonId", "caresreason");
            ViewData["ZhearaboutId"] = new SelectList(_context.Zhearabout.OrderBy(m => m.hearabout), "ZhearaboutId", "hearabout");
            ViewData["ZinternalId"] = new SelectList(_context.Zinternal.Where(m => m.active).OrderBy(m => m.internal_type), "ZinternalId", "internal_type");
            ViewData["ZinternalcategoryId"] = new SelectList(_context.Zinternalcategory.OrderBy(m => m.internalsubcat), "ZinternalcategoryId", "internalsubcat");
            ViewData["ZlocationId"] = new SelectList(_context.Zlocation.OrderBy(m => m.location), "ZlocationId", "location");
            ViewData["ZopotherId"] = new SelectList(_context.Zopother.OrderBy(m => m.opother), "ZopotherId", "opother");
            ViewData["ZplatformId"] = new SelectList(_context.Zplatform.OrderBy(m => m.opplatform), "ZplatformId", "opplatform");
            ViewData["ZprogramsId"] = new SelectList(_context.Zprograms.Where(m => m.active).OrderBy(m => m.program_desc), "ZprogramsId", "program_desc");
            ViewData["ZreasonId"] = new SelectList(_context.Zreason.Where(m => m.active).OrderBy(m => m.final_reason), "ZreasonId", "final_reason");
            ViewData["ZresourcereasonId"] = new SelectList(_context.Zresourcereason.OrderBy(m => m.resourceresult), "ZresourcereasonId", "resourceresult");
            ViewData["ZschoolId"] = new SelectList(_context.Zschool.Where(m => m.active).OrderBy(m => m.displayname), "ZschoolId", "displayname");
            ViewData["ZsiteId"] = new SelectList(_context.Zsite.Where(m => m.active).OrderBy(m => m.site), "ZsiteId", "site");
            ViewData["ZstatusId"] = new SelectList(_context.Zstatus.Where(m => m.active).OrderBy(m => m.inq_status), "ZstatusId", "inq_status");
            ViewData["ZactionId"] = new SelectList(_context.Zaction.OrderBy(m => m.action), "ZactionId", "action");

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
            Client client = inquiryFormViewModel.Client;

            if (ModelState.IsValid)
            {
                _context.Update(cs);
                await _context.SaveChangesAsync();
                int clientId = (int)cs.ClientId;
                client.ClientId = clientId;
                _context.Update(client);
                await _context.SaveChangesAsync();

                ci.ClientServiceId = cs.ClientServiceId;
                _context.Add(ci);
                await _context.SaveChangesAsync();
                TempData["Alert"] = "Created Note";
                return RedirectToAction("Edit", "ClientServices", new {id = cs.ClientServiceId});
            }
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", ci.ClientServiceId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.OrderBy(m => m.worker), "ZworkerId", "worker", ci.ZworkerId);
            ViewData["ClientId"] = new SelectList(_context.Clients.OrderBy(m => m.name), "ClientId", "name", cs.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services.OrderBy(m => m.service_desc), "ServiceId", "service_desc", cs.ServiceId);
            ViewData["ZcaresreasonId"] = new SelectList(_context.Zcaresreason.OrderBy(m => m.caresreason), "ZcaresreasonId", "caresreason", cs.ZcaresreasonId);
            ViewData["ZhearaboutId"] = new SelectList(_context.Zhearabout.OrderBy(m => m.hearabout), "ZhearaboutId", "hearabout", cs.ZhearaboutId);
            ViewData["ZinternalId"] = new SelectList(_context.Zinternal.Where(m => m.active).OrderBy(m => m.internal_type), "ZinternalId", "internal_type", cs.ZinternalId);
            ViewData["ZinternalcategoryId"] = new SelectList(_context.Zinternalcategory.OrderBy(m => m.internalsubcat), "ZinternalcategoryId", "internalsubcat", cs.ZinternalcategoryId);
            ViewData["ZlocationId"] = new SelectList(_context.Zlocation.OrderBy(m => m.location), "ZlocationId", "location", cs.ZlocationId);
            ViewData["ZopotherId"] = new SelectList(_context.Zopother.OrderBy(m => m.opother), "ZopotherId", "opother", cs.ZopotherId);
            ViewData["ZplatformId"] = new SelectList(_context.Zplatform.OrderBy(m => m.opplatform), "ZplatformId", "opplatform", cs.ZplatformId);
            ViewData["ZprogramsId"] = new SelectList(_context.Zprograms.Where(m => m.active).OrderBy(m => m.program_desc), "ZprogramsId", "program_desc", cs.ZprogramsId);
            ViewData["ZreasonId"] = new SelectList(_context.Zreason.Where(m => m.active).OrderBy(m => m.final_reason), "ZreasonId", "final_reason", cs.ZreasonId);
            ViewData["ZresourcereasonId"] = new SelectList(_context.Zresourcereason.OrderBy(m => m.resourceresult), "ZresourcereasonId", "resourceresult", cs.ZresourcereasonId);
            ViewData["ZschoolId"] = new SelectList(_context.Zschool.Where(m => m.active).OrderBy(m => m.displayname), "ZschoolId", "displayname", cs.ZschoolId);
            ViewData["ZsiteId"] = new SelectList(_context.Zsite.Where(m => m.active).OrderBy(m => m.site), "ZsiteId", "site", cs.ZsiteId);
            ViewData["ZstatusId"] = new SelectList(_context.Zstatus.Where(m => m.active).OrderBy(m => m.inq_status), "ZstatusId", "inq_status", cs.ZstatusId);
            ViewData["ZactionId"] = new SelectList(_context.Zaction.OrderBy(m => m.action), "ZactionId", "action", ci.ZactionId);

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
            ViewData["ZactionId"] = new SelectList(_context.Zaction.OrderBy(m => m.action), "ZactionId", "action", clineitem.ZactionId);

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
                return RedirectToAction("Edit", "ClientServices", new { id = ci.ClientServiceId });
            }
            ViewData["ClientServiceId"] = new SelectList(_context.ClientServices, "ClientServiceId", "ClientServiceId", ci.ClientServiceId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.OrderBy(m => m.worker), "ZworkerId", "worker", ci.ZworkerId);
            ViewData["ZactionId"] = new SelectList(_context.Zaction.OrderBy(m => m.action), "ZactionId", "action", ci.ZactionId);
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
