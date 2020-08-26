using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WCAProject.Data;
using WCAProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using System.Security.Claims;



namespace WCAProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WCAProjectContext _context;

        public HomeController(ILogger<HomeController> logger, WCAProjectContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            var clientservices = from c in _context.ClientServices
                                 select c;
            clientservices = _context.ClientServices
              .Include(c => c.Client)
              .Include(c => c.Zstatus)
              .Include(c => c.Zworker)
              .Include(c => c.Service);

            // var workerfilter = 2;
           

            //clientservices = clientservices.Where(cs => cs.Zworker.Username == workerfilter);
            clientservices = clientservices.Where(cs => cs.Zstatus.inq_status == "In Process");
            clientservices = clientservices.OrderByDescending(c => c.recdate);

            // var wCAProjectContext = _context.ClientServices.Include(c => c.Client).Include(c => c.Service).Include(c => c.Zcaresreason).Include(c => c.Zhearabout).Include(c => c.Zinternal).Include(c => c.Zinternalcategory).Include(c => c.Zlocation).Include(c => c.Zopother).Include(c => c.Zplatform).Include(c => c.Zprograms).Include(c => c.Zreason).Include(c => c.Zresourcereason).Include(c => c.Zsite).Include(c => c.Zstatus).Include(c => c.Zworker);
            int pageSize = 5;

            return View(await PaginatedList<ClientService>.CreateAsync(clientservices.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize("WFS_Admins")]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Debug()
        {
            return View();
        }

        public IActionResult Changelog()
        {
            return View();
        }
        public IActionResult Help()
        {
            return View();
        }
        public IActionResult ClientSearch()
        {
            return View();
        }
        public IActionResult SSite()
        {
            return View();
        }
        public IActionResult Reports()
        {
            return View();
        }


        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error(int statusCode)
        {
            var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ViewBag.StatusCode = statusCode;
            ViewBag.OriginalPath = feature?.OriginalPath;
            ViewBag.OriginalQueryString = feature?.OriginalQueryString;
            return View();
        }
        [AllowAnonymous]
        public IActionResult Exception()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
