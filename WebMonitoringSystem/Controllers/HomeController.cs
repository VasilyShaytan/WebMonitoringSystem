using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMonitoringSystem.Data;
using WebMonitoringSystem.ViewModels;
using WebMonitoringSystem.Models;

namespace WebMonitoringSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly MonitoringSystemContext _context;

        public HomeController(MonitoringSystemContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Map()
        {
            var data = new SelectExampleViewModels();
            data.ViewModels1 = _context.BasicParameters.Select(p => new SelectExampleViewModel1() { Id = p.BasicParameterID, Name = p.SPNName }).ToList();
            data.ViewModels2 = _context.BasicParameters.Select(p => new SelectExampleViewModel2() { Id = p.BasicParameterID, Name = p.SPNNameRu }).ToList();
            return View(data);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
