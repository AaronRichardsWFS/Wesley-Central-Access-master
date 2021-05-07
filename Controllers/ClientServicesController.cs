using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCAProject.Data;
using Microsoft.AspNetCore.Authorization;
using WCAProject.Models;
using WCAProject.ViewModels;
using System.Globalization;

namespace WCAProject.Controllers
{
    [Authorize("WFS_Users")]
    public class ClientServicesController : Controller
    {
        private readonly WCAProjectContext _context;

        public ClientServicesController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: ClientServices
        public async Task<IActionResult> Index(string sortOrder, string workerfilter, string statusfilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["ZstatusId"] = new SelectList(_context.Zstatus.Where(m => m.active), "inq_status", "inq_status");
                
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.OrderBy(m => m.worker), "worker", "worker");

            var clientservices = from c in _context.ClientServices
                                 select c;
            clientservices = _context.ClientServices
              .Include(c => c.Client)
              .Include(c => c.Zstatus)
              .Include(c => c.Zworker)
              .Include(c => c.Service);

            if (!String.IsNullOrEmpty(workerfilter) && workerfilter != "All Workers"){
                clientservices = clientservices.Where(cs => cs.Zworker.worker == workerfilter);
            }
            if (!String.IsNullOrEmpty(statusfilter) && statusfilter != "All Statuses"){
                clientservices = clientservices.Where(cs => cs.Zstatus.inq_status == statusfilter);
            }
            switch (sortOrder){
              case "Date":
                clientservices = clientservices.OrderBy(c => c.recdate);
                break;
              case "date_desc":
                clientservices = clientservices.OrderByDescending(c => c.recdate);
                break;
              default:
                clientservices = clientservices.OrderByDescending(c => c.recdate);
                break;
            }
            // var wCAProjectContext = _context.ClientServices.Include(c => c.Client).Include(c => c.Service).Include(c => c.Zcaresreason).Include(c => c.Zhearabout).Include(c => c.Zinternal).Include(c => c.Zinternalcategory).Include(c => c.Zlocation).Include(c => c.Zopother).Include(c => c.Zplatform).Include(c => c.Zprograms).Include(c => c.Zreason).Include(c => c.Zresourcereason).Include(c => c.Zsite).Include(c => c.Zstatus).Include(c => c.Zworker);
            int pageSize = 9;

            return View(await PaginatedList<ClientService>.CreateAsync(clientservices.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: ClientServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices
                .Include(c => c.Client)
                .Include(c => c.Service)
                .Include(c => c.Zcaresreason)
                .Include(c => c.Zhearabout)
                .Include(c => c.Zinternal)
                .Include(c => c.Zinternalcategory)
                .Include(c => c.Zlocation)
                .Include(c => c.Zopother)
                .Include(c => c.Zplatform)
                .Include(c => c.Zprograms)
                .Include(c => c.Zreason)
                .Include(c => c.Zresourcereason)
                .Include(c => c.Zschool)
                .Include(c => c.Zsite)
                .Include(c => c.Zstatus)
                .Include(c => c.Zworker)
                .FirstOrDefaultAsync(m => m.ClientServiceId == id);
            if (clientService == null)
            {
                return NotFound();
            }

            InquiryDetailsViewModel inquiryDetailsViewModel = new InquiryDetailsViewModel();
            inquiryDetailsViewModel.Client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == clientService.ClientId);
            inquiryDetailsViewModel.Inquiry = clientService;
            inquiryDetailsViewModel.Notes = await _context.Clineitems.Where(ci => ci.ClientServiceId == inquiryDetailsViewModel.Inquiry.ClientServiceId).OrderByDescending(ci => ci.ldate).ToListAsync();
            inquiryDetailsViewModel.ScaScreen = await _context.ScaScreen.FirstOrDefaultAsync(sca => sca.ClientServiceId == clientService.ClientServiceId);

            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county", inquiryDetailsViewModel.Client.ZcountyId);
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race", inquiryDetailsViewModel.Client.ZraceId);
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(m => m.insurance), "ZinsuranceId", "insurance", inquiryDetailsViewModel.Client.ZinsuranceId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.Where(m => m.active).OrderBy(m => m.worker), "ZworkerId", "worker");

            return View(inquiryDetailsViewModel);
        }

        // GET: ClientServices/Create
        public async Task<IActionResult> Create(int clientid)
        {

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

            InquiryFormViewModel inquiryFormViewModel = new InquiryFormViewModel();
            inquiryFormViewModel.Client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == clientid);
            inquiryFormViewModel.Inquiry = new ClientService{Client = inquiryFormViewModel.Client};
            inquiryFormViewModel.Inquiry.ClientId = inquiryFormViewModel.Client.ClientId;
            inquiryFormViewModel.Inquiry.recdate = DateTime.Now;
            inquiryFormViewModel.Note = new Clineitem{ClientServiceId = inquiryFormViewModel.Inquiry.ClientServiceId};
            inquiryFormViewModel.Note.ldate = DateTime.Now;
            inquiryFormViewModel.Notes = await _context.Clineitems.Where(ci => ci.ClientServiceId == inquiryFormViewModel.Inquiry.ClientServiceId).OrderByDescending(ci => ci.ldate).ToListAsync();
            inquiryFormViewModel.ScaScreen = new ScaScreen{ClientService = inquiryFormViewModel.Inquiry};
            inquiryFormViewModel.ScaScreen.ClientServiceId = inquiryFormViewModel.Inquiry.ClientServiceId;

            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county", inquiryFormViewModel.Client.ZcountyId);
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race", inquiryFormViewModel.Client.ZraceId);
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(m => m.insurance), "ZinsuranceId", "insurance", inquiryFormViewModel.Client.ZinsuranceId);
            ViewData["ZactionId"] = new SelectList(_context.Zaction.OrderBy(m => m.action), "ZactionId", "action", inquiryFormViewModel.Note.ZactionId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.Where(m => m.active).OrderBy(m => m.worker), "ZworkerId", "worker", inquiryFormViewModel.Note.ZworkerId);

            return View(inquiryFormViewModel);
        }

        // POST: ClientServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InquiryFormViewModel inquiryFormViewModel)
        {
            ClientService cs = inquiryFormViewModel.Inquiry;
            Clineitem ci = inquiryFormViewModel.Note;
            ScaScreen sca = inquiryFormViewModel.ScaScreen;
            Client client = inquiryFormViewModel.Client;
            
            if (ModelState.IsValid)
            {
                int clientId = (int)cs.ClientId;
                client.ClientId = clientId;
                _context.Update(client);
                await _context.SaveChangesAsync();
                _context.Add(cs);
                await _context.SaveChangesAsync();
                ci.ClientServiceId = cs.ClientServiceId;
                _context.Add(ci);
                await _context.SaveChangesAsync();
                sca.ClientServiceId = cs.ClientServiceId;
                _context.Update(sca);
                await _context.SaveChangesAsync();
                TempData["Alert"] = "Created Inquiry";
                return RedirectToAction("Edit", "ClientServices", new {id = cs.ClientServiceId});
            }
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
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.Where(m => m.active).OrderBy(m => m.worker), "ZworkerId", "worker", cs.ZworkerId);

            return View(inquiryFormViewModel);
        }

        // GET: ClientServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices.FindAsync(id);
            var client = await _context.Clients.FindAsync(clientService.ClientId);
            if (clientService == null)
            {
                return NotFound();
            }

            InquiryDetailsViewModel inquiryDetailsViewModel = new InquiryDetailsViewModel();
            inquiryDetailsViewModel.Client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == clientService.ClientId);
            inquiryDetailsViewModel.Inquiry = clientService;
            inquiryDetailsViewModel.Notes = await _context.Clineitems.Where(ci => ci.ClientServiceId == clientService.ClientServiceId).OrderByDescending(ci => ci.ldate).ToListAsync();
            inquiryDetailsViewModel.ScaScreen = await _context.ScaScreen.FirstOrDefaultAsync(m => m.ClientServiceId == clientService.ClientServiceId);

            ViewData["ClientId"] = new SelectList(_context.Clients.OrderBy(m => m.name), "ClientId", "name", clientService.ClientId);
            ViewData["ServiceId"] = new SelectList(_context.Services.OrderBy(m => m.service_desc), "ServiceId", "service_desc", clientService.ServiceId);
            ViewData["ZcaresreasonId"] = new SelectList(_context.Zcaresreason.OrderBy(m => m.caresreason), "ZcaresreasonId", "caresreason", clientService.ZcaresreasonId);
            ViewData["ZhearaboutId"] = new SelectList(_context.Zhearabout.OrderBy(m => m.hearabout), "ZhearaboutId", "hearabout", clientService.ZhearaboutId);
            ViewData["ZinternalId"] = new SelectList(_context.Zinternal.Where(m => m.active).OrderBy(m => m.internal_type), "ZinternalId", "internal_type", clientService.ZinternalId);
            ViewData["ZinternalcategoryId"] = new SelectList(_context.Zinternalcategory.OrderBy(m => m.internalsubcat), "ZinternalcategoryId", "internalsubcat", clientService.ZinternalcategoryId);
            ViewData["ZlocationId"] = new SelectList(_context.Zlocation.OrderBy(m => m.location), "ZlocationId", "location", clientService.ZlocationId);
            ViewData["ZopotherId"] = new SelectList(_context.Zopother.OrderBy(m => m.opother), "ZopotherId", "opother", clientService.ZopotherId);
            ViewData["ZplatformId"] = new SelectList(_context.Zplatform.OrderBy(m => m.opplatform), "ZplatformId", "opplatform", clientService.ZplatformId);
            ViewData["ZprogramsId"] = new SelectList(_context.Zprograms.Where(m => m.active).OrderBy(m => m.program_desc), "ZprogramsId", "program_desc", clientService.ZprogramsId);
            ViewData["ZreasonId"] = new SelectList(_context.Zreason.Where(m => m.active).OrderBy(m => m.final_reason), "ZreasonId", "final_reason", clientService.ZreasonId);
            ViewData["ZresourcereasonId"] = new SelectList(_context.Zresourcereason.OrderBy(m => m.resourceresult), "ZresourcereasonId", "resourceresult", clientService.ZresourcereasonId);
            ViewData["ZschoolId"] = new SelectList(_context.Zschool.Where(m => m.active).OrderBy(m => m.displayname), "ZschoolId", "displayname", clientService.ZschoolId);
            ViewData["ZsiteId"] = new SelectList(_context.Zsite.Where(m => m.active).OrderBy(m => m.site), "ZsiteId", "site", clientService.ZsiteId);
            ViewData["ZstatusId"] = new SelectList(_context.Zstatus.Where(m => m.active).OrderBy(m => m.inq_status), "ZstatusId", "inq_status", clientService.ZstatusId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.Where(m => m.active).OrderBy(m => m.worker), "ZworkerId", "worker", inquiryDetailsViewModel.Notes[0].ZworkerId);
            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county", client.ZcountyId);
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race", client.ZraceId);
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(m => m.insurance), "ZinsuranceId", "insurance", client.ZinsuranceId);

            if (inquiryDetailsViewModel.ScaScreen == null)
            {
                inquiryDetailsViewModel.ScaId = 0;
            } 
            else
            {
                inquiryDetailsViewModel.ScaId = inquiryDetailsViewModel.ScaScreen.ScaScreenId;
            }
            
            ViewData["ZactionId"] = new SelectList(_context.Zaction.OrderBy(m => m.action), "ZactionId", "action", inquiryDetailsViewModel.Notes[0].ZactionId);
            ViewData["WorkerNames"] = new SelectList(_context.Zworker.OrderBy(m => m.ZworkerId), "ZworkerId", "worker", clientService.ZworkerId).ToList();

            return View(inquiryDetailsViewModel);
        }

        // POST: ClientServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, InquiryDetailsViewModel inquiryDetailsViewModel)
        {
            ClientService cs = inquiryDetailsViewModel.Inquiry;
            ScaScreen sca = inquiryDetailsViewModel.ScaScreen;
            Client client = inquiryDetailsViewModel.Client;
            int scaId = inquiryDetailsViewModel.ScaId;

            if (id != cs.ClientServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    client.ClientId = (int)cs.ClientId;
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    _context.Update(cs);
                    await _context.SaveChangesAsync();
                    sca.ClientServiceId = cs.ClientServiceId;
                    if (scaId == 0)
                    {
                        _context.Add(sca);
                    }
                    else
                    {
                        sca.ScaScreenId = scaId;
                        _context.Update(sca);
                    }
                    TempData["Alert"] = "Saved Changes to Inquiry";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientServiceExists(cs.ClientServiceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                /*modified following line from Details to Edit*/
                return RedirectToAction("Edit", "ClientServices", new {id = cs.ClientServiceId});
            }
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
            ViewData["ZreasonId"] = new SelectList(_context.Zreason.OrderBy(m => m.final_reason), "ZreasonId", "final_reason", cs.ZreasonId);
            ViewData["ZresourcereasonId"] = new SelectList(_context.Zresourcereason.OrderBy(m => m.resourceresult), "ZresourcereasonId", "resourceresult", cs.ZresourcereasonId);
            ViewData["ZschoolId"] = new SelectList(_context.Zschool.Where(m => m.active).OrderBy(m => m.displayname), "ZschoolId", "displayname", cs.ZschoolId);
            ViewData["ZsiteId"] = new SelectList(_context.Zsite.Where(m => m.active).OrderBy(m => m.site), "ZsiteId", "site", cs.ZsiteId);
            ViewData["ZstatusId"] = new SelectList(_context.Zstatus.Where(m => m.active).OrderBy(m => m.inq_status), "ZstatusId", "inq_status", cs.ZstatusId);
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.Where(m => m.active).OrderBy(m => m.worker), "ZworkerId", "worker", cs.ZworkerId);
            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county", client.ZcountyId);
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race", client.ZraceId);
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(m => m.insurance), "ZinsuranceId", "insurance", client.ZinsuranceId);

            return View(inquiryDetailsViewModel);
        }

        // GET: ClientServices/Delete/5
        [Authorize("WFS_Admins")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientService = await _context.ClientServices
                .Include(c => c.Client)
                .Include(c => c.Service)
                .Include(c => c.Zcaresreason)
                .Include(c => c.Zhearabout)
                .Include(c => c.Zinternal)
                .Include(c => c.Zinternalcategory)
                .Include(c => c.Zlocation)
                .Include(c => c.Zopother)
                .Include(c => c.Zplatform)
                .Include(c => c.Zprograms)
                .Include(c => c.Zreason)
                .Include(c => c.Zresourcereason)
                .Include(c => c.Zschool)
                .Include(c => c.Zsite)
                .Include(c => c.Zstatus)
                .Include(c => c.Zworker)
                .FirstOrDefaultAsync(m => m.ClientServiceId == id);
            if (clientService == null)
            {
                return NotFound();
            }

            return View(clientService);
        }

        // POST: ClientServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("WFS_Admins")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientService = await _context.ClientServices.FindAsync(id);
            var lines = await _context.Clineitems
              .Where(l => l.ClientServiceId == clientService.ClientServiceId).ToListAsync();
            foreach (Clineitem l in lines){
              _context.Clineitems.Remove(l);
              _context.SaveChanges();
            }
            var sca = await _context.ScaScreen
              .FirstOrDefaultAsync(m => m.ClientServiceId == clientService.ClientServiceId);
            if(sca != null){
              _context.ScaScreen.Remove(sca);
              _context.SaveChanges();
            }
            _context.ClientServices.Remove(clientService);
            _context.SaveChanges();

            TempData["Alert"] = "Deleted Inquiry";
            return RedirectToAction(nameof(Index));
        }

        private bool ClientServiceExists(int id)
        {
            return _context.ClientServices.Any(e => e.ClientServiceId == id);
        }
    }
}
