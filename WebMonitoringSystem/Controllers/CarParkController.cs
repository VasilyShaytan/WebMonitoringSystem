using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using WebMonitoringSystem.Data;
using WebMonitoringSystem.Models;
using WebMonitoringSystem.ViewModels;
using static WebMonitoringSystem.ViewModels.VehicleGroupViewModels;

namespace WebMonitoringSystem.Controllers
{
    public class CarParkController : Controller
    {
        private readonly MonitoringSystemContext _context;

        public CarParkController(MonitoringSystemContext context)
        {
            _context = context;
        }


        // GET: Vehicles
        public async Task<IActionResult> RegistrationVehicleIndex()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> RegistrationVehicleDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .SingleOrDefaultAsync(m => m.VehicleID == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult RegistrationVehicleCreate()
        {
            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationVehicleCreate([Bind("VehicleID,Mark,ModelType,СarryingСapacity,YearIssue,UsefulVolume,VehicleType,OverallDimensions")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(RegistrationVehicleIndex));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> RegistrationVehicleEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(m => m.VehicleID == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationVehicleEdit(int id, [Bind("VehicleID,Mark,ModelType,СarryingСapacity,YearIssue,UsefulVolume,VehicleType,OverallDimensions")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleID))
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
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> RegistrationVehicleDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .SingleOrDefaultAsync(m => m.VehicleID == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("RegistrationVehicleDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrationVehicleDeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.SingleOrDefaultAsync(m => m.VehicleID == id);
            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleID == id);
        }

        // *********************************************************
        // *********************************************************
        // *********************************************************

        public IActionResult VehicleGroupIndex()
        {
            var data = new VehicleViewModels();
            data.VehicleViewModelList = _context.Vehicles.Select(p => new VehicleModel() { Id = p.VehicleID, Mark = p.Mark + " " + p.ModelType}).ToList();
            return View(data); 
        }




        public IActionResult VehicleGroup()
        {
            var data = new VehicleGroupViewModels();
            data.VehicleGroupViewModelList = _context.VehicleGroups.Select(p => new VehicleGroupModel() { Id = p.VehicleGroupID, Name = p.VehicleGroupName }).ToList();
            return View(data);
        }






        // GET: /<controller>/
        public IActionResult Index()
        {
            //var data = new SelectExampleViewModels();
            //data.ViewModels = _context.BasicParameters.Select(p => new SelectExampleViewModel() { Id = p.BasicParameterID, Name = p.SPNName }).ToList();
            //data.ViewModels2 = _context.BasicParameters.Select(p => new SelectExampleViewModel2() { Id = p.BasicParameterID, Name = p.SPNNameRu }).ToList();
            return View();
        }

        public IActionResult Registration()
        {
            var qwerty = "";
            var roles = _context.Roles.ToList();
            foreach (var role in roles)
            {
                qwerty = qwerty + role.RoleName;
            }
            ViewData["qwerty"] = qwerty;

            //string query = @"SELECT * FROM ""public"".""Role"";";

            // Connect to a PostgreSQL database
            //NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;User Id=vasily; " +
            //   "Password=222222;Database=dbmonitoringsystem;");
            //conn.Open();

            // Define a query returning a single row result set
            //NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.'Role' ORDER BY 'RoleID' ASC ", conn);

            // Execute the query and obtain the value of the first column of the first row
            //int count = (int)command.ExecuteScalar();

            //Console.Write("{0}\n", count);
            //conn.Close();
            //var data = new SelectExampleViewModels();
            //data.ViewModels = _context.BasicParameters.Select(p => new SelectExampleViewModel() { Id = p.BasicParameterID, Name = p.SPNName }).ToList();
            //data.ViewModels2 = _context.BasicParameters.Select(p => new SelectExampleViewModel2() { Id = p.BasicParameterID, Name = p.SPNNameRu }).ToList();
            return View();
        }
    }
}
