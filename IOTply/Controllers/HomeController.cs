using IOTply.Data;
using IOTply.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IOTply.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db, IConfiguration configuration)
        {
            _logger = logger;
            _db = db;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            IEnumerable<LogDetails> _logList = _db.LogDetails;
            return View(_logList);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public class ModelCollection
        {
            public LogDetails LogModel { get; set; }
            public IEnumerable<LogDetails> list { get; set; }
            public IEnumerable<EmployeeReg> emplist { get; set; }
            public string maxtemp { get; set; }
            public DateTime date { get; set; }

        }

        public class getFID
        {
            public string fid { get; set; }
        }
        public IActionResult Statics()
        {
            ModelCollection collection = new ModelCollection();
            collection.list = _db.LogDetails;

            return View(collection);
        }

        [HttpPost]
        public IActionResult IndiStatics(string fingerprint)
        {
            ModelCollection collection = new();
            collection.list = _db.LogDetails.Where(l => l.FingerPrintID == fingerprint);

            collection.emplist = _db.Employee.Where(e => e.FingerPrintID == fingerprint);

            string maxtemperature = _db.LogDetails.Where(l => l.FingerPrintID == fingerprint).Max(p => p.Temperature);
            DateTime maxDate = _db.LogDetails.Where(l => l.FingerPrintID == fingerprint && l.Temperature == maxtemperature).Select(l => l.Time).Single();

            collection.maxtemp = maxtemperature;
            collection.date = maxDate;

            return View(collection);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
