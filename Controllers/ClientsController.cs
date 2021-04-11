using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WCAProject.Data;
using WCAProject.Models;
using Microsoft.AspNetCore.Authorization;
using WCAProject.ViewModels;

namespace WCAProject.Controllers
{
    [Authorize("WFS_Users")]
    public class ClientsController : Controller
    {
        private readonly WCAProjectContext _context;

        public ClientsController(WCAProjectContext context)
        {
            _context = context;
        }

        // GET: Clients
        // [Authorize(Policy = "WFS_Users")]
        public async Task<IActionResult> Index(string sortOrder, string searchby, string searchString, int? pageNumber, string currentFilter)
        {
            ViewData["CurrentSort"] = sortOrder;
            TempData["SearchBy"] = searchby;

            if(searchString != null){
              pageNumber = 1;
            }else{
              searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var clients = from c in _context.Clients
                          select c;
            if (!String.IsNullOrEmpty(searchString)){
              if (searchby == "Name"){
                clients = clients.Where(c => c.clast.Contains(searchString)
                                          || c.cfirst.Contains(searchString));
              }else if (searchby == "Email"){
                clients = clients.Where(c => c.email.Contains(searchString)
                                          || c.email2.Contains(searchString));
                }
                else if (searchby == "Phone"){
                clients = clients.Where(c => c.phone.Contains(searchString)
                                          || c.phone2.Contains(searchString));
                }
                else if (searchby == "Credible Id"){
                clients = clients.Where(c => c.CredibleID.Contains(searchString));
              }else if (searchby == "Client Id"){
                clients = clients.Where(c => c.ClientId.ToString().Contains(searchString));
              }else if (searchby == "Contact Relationship"){
                  clients = clients.Where(c => c.contact.Contains(searchString)
                                          || c.contact2.Contains(searchString));
                }
            }
            int pageSize = 9;
            return View(await PaginatedList<Client>.CreateAsync(clients.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Zcounty)
                .Include(c => c.Zrace)
                .Include(c => c.Zinsurance)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            ClientDetailsViewModel clientDetailsViewModel = new ClientDetailsViewModel()
            {
                Client = client,
                Inquiries = await _context.ClientServices
                    .Where(cs => cs.ClientId == client.ClientId)
                    .Include(cs => cs.Zstatus)
                    .Include(cs => cs.Service)
                    .Include(cs => cs.Zworker)
                    .OrderByDescending(cs => cs.recdate)
                    .ToListAsync()
            };

            return View(clientDetailsViewModel);
        }

        // GET: Clients/Export/5
        public async Task<IActionResult> Export(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Zcounty)
                .Include(c => c.Zrace)
                .Include(c => c.Zinsurance)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            ClientDetailsViewModel clientDetailsViewModel = new ClientDetailsViewModel()
            {
                Client = client,
                Inquiries = await _context.ClientServices
                    .Where(cs => cs.ClientId == client.ClientId)
                    .Include(cs => cs.Zstatus)
                    .Include(cs => cs.Service)
                    .Include(cs => cs.Zworker)
                    .OrderByDescending(cs => cs.recdate)
                    .ToListAsync()
            };

            return View(clientDetailsViewModel);
        }

        public void AddNote()
        {

            return;
        }

        public IActionResult Create()
        {
            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county");
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race");
            ViewData["ZschoolId"] = new SelectList(_context.Zschool.Where(m => m.active).OrderBy(m => m.displayname), "ZschoolId", "displayname");
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(zi => zi.insurance), "ZinsuranceId", "insurance");
            
            ViewData["ClientId"] = new SelectList(_context.Clients.OrderBy(c => c.name), "ClientId", "name");
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
            ViewData["ZsiteId"] = new SelectList(_context.Zsite.Where(m => m.active).OrderBy(m => m.site), "ZsiteId", "site");
            ViewData["ZstatusId"] = new SelectList(_context.Zstatus.Where(m => m.active).OrderBy(m => m.inq_status), "ZstatusId", "inq_status");
            ViewData["ZworkerId"] = new SelectList(_context.Zworker.Where(m => m.active).OrderBy(m => m.worker), "ZworkerId", "worker");
            

            ClientNewViewModel clientNewViewModel = new ClientNewViewModel();
            clientNewViewModel.c = new Client{};
            clientNewViewModel.Inquiry = new ClientService{Client = clientNewViewModel.c};
            clientNewViewModel.Inquiry.recdate = DateTime.Now;
            clientNewViewModel.Note = new Clineitem{ClientServiceId = clientNewViewModel.Inquiry.ClientServiceId};
            clientNewViewModel.Note.ldate = DateTime.Now;

            return View(clientNewViewModel);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClientNewViewModel clientNewViewModel)
        {
            var client = clientNewViewModel.c;
            var cs = clientNewViewModel.Inquiry;

            if(client.dob != null){
              DateTime temp = client.dob ?? DateTime.Now;
              var tod = DateTime.Today;
              var age = tod.Year - temp.Year;
              if (temp.Date > tod.AddYears(-age)){
                client.age = age--;
              }else{
                client.age = age;
              }
            }

            if (ModelState.IsValid)
            {
                _context.Add(client);
                await _context.SaveChangesAsync();
                cs.ClientId = client.ClientId;
                _context.Add(cs);
                await _context.SaveChangesAsync();
                clientNewViewModel.Note.ClientServiceId = cs.ClientServiceId;
                _context.Add(clientNewViewModel.Note);
                await _context.SaveChangesAsync();
                TempData["Alert"] = String.Format("Created Client: {0} {1}", client.cfirst, client.clast);
                return RedirectToAction("Details", "Clients", new {id = client.ClientId});
            }
            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county", client.ZcountyId);
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race", client.ZraceId);
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(m => m.insurance), "ZinsuranceId", "insurance", client.ZinsuranceId);

            return View(clientNewViewModel);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county", client.ZcountyId);
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race", client.ZraceId);
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(m => m.insurance), "ZinsuranceId", "insurance", client.ZinsuranceId);


            ClientEditViewModel clientEditViewModel = new ClientEditViewModel();
            clientEditViewModel.Client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientId == client.ClientId);
            clientEditViewModel.Inquiries = await _context.ClientServices
                    .Where(cs => cs.ClientId == client.ClientId)
                    .Include(cs => cs.Zstatus)
                    .Include(cs => cs.Service)
                    .Include(cs => cs.Zworker)
                    .OrderByDescending(cs => cs.recdate)
                    .ToListAsync();

            return View(clientEditViewModel);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClientEditViewModel clientEditViewModel)
        {
            Client client = clientEditViewModel.Client;

            if(client.dob != null){
              DateTime temp = client.dob ?? DateTime.Now;
              var tod = DateTime.Today;
              var age = tod.Year - temp.Year;
              if (temp.Date > tod.AddYears(-age)){
                client.age = age--;
              }else{
                client.age = age;
              }
            }

            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(client);
                    await _context.SaveChangesAsync();
                    TempData["Alert"] = String.Format("Saved Changes to Client: {0} {1}", client.cfirst, client.clast);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Clients", new {id = client.ClientId});
            }
            ViewData["ZcountyId"] = new SelectList(_context.Zcounty.OrderBy(m => m.county), "ZcountyId", "county", client.ZcountyId);
            ViewData["ZraceId"] = new SelectList(_context.Zrace.OrderBy(m => m.race), "ZraceId", "race", client.ZraceId);
            ViewData["ZinsuranceId"] = new SelectList(_context.Zinsurance.Where(m => m.active).OrderBy(m => m.insurance), "ZinsuranceId", "insurance", client.ZinsuranceId);
            return View(clientEditViewModel);
        }

        // GET: Clients/Delete/5
        [Authorize("WFS_Admins")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .Include(c => c.Zcounty)
                .Include(c => c.Zrace)
                .Include(c => c.Zinsurance)
                .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize("WFS_Admins")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            var inqs = await _context.ClientServices
              .Where(l => l.ClientId == client.ClientId).ToListAsync();
            foreach (ClientService i in inqs){
              var lines = await _context.Clineitems
                .Where(l => l.ClientServiceId == i.ClientServiceId).ToListAsync();
              foreach (Clineitem l in lines){
                _context.Clineitems.Remove(l);
                await _context.SaveChangesAsync();
              }
              var sca = await _context.ScaScreen
                .FirstOrDefaultAsync(m => m.ClientServiceId == i.ClientServiceId);
              if(sca != null){
                _context.ScaScreen.Remove(sca);
                await _context.SaveChangesAsync();
              }
              _context.ClientServices.Remove(i);
              await _context.SaveChangesAsync();
            }
            TempData["Alert"] = String.Format("Deleted Client: {0} {1}", client.cfirst, client.clast);
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
