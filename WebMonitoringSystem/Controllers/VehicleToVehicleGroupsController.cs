using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebMonitoringSystem.Data;
using WebMonitoringSystem.Models;

namespace WebMonitoringSystem.Controllers
{
    public class VehicleToVehicleGroupsController : Controller
    {
        private readonly MonitoringSystemContext _context;

        public VehicleToVehicleGroupsController(MonitoringSystemContext context)
        {
            _context = context;
        }

        // GET: VehicleToVehicleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleToVehicleGroups.ToListAsync());
        }

        // GET: VehicleToVehicleGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleToVehicleGroup = await _context.VehicleToVehicleGroups
                .SingleOrDefaultAsync(m => m.VehicleToVehicleGroupID == id);
            if (vehicleToVehicleGroup == null)
            {
                return NotFound();
            }

            return View(vehicleToVehicleGroup);
        }

        // GET: VehicleToVehicleGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleToVehicleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleToVehicleGroupID,VehicleGroupID,VehicleID")] VehicleToVehicleGroup vehicleToVehicleGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleToVehicleGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleToVehicleGroup);
        }

        // GET: VehicleToVehicleGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleToVehicleGroup = await _context.VehicleToVehicleGroups.SingleOrDefaultAsync(m => m.VehicleToVehicleGroupID == id);
            if (vehicleToVehicleGroup == null)
            {
                return NotFound();
            }
            return View(vehicleToVehicleGroup);
        }

        // POST: VehicleToVehicleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleToVehicleGroupID,VehicleGroupID,VehicleID")] VehicleToVehicleGroup vehicleToVehicleGroup)
        {
            if (id != vehicleToVehicleGroup.VehicleToVehicleGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleToVehicleGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleToVehicleGroupExists(vehicleToVehicleGroup.VehicleToVehicleGroupID))
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
            return View(vehicleToVehicleGroup);
        }

        // GET: VehicleToVehicleGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleToVehicleGroup = await _context.VehicleToVehicleGroups
                .SingleOrDefaultAsync(m => m.VehicleToVehicleGroupID == id);
            if (vehicleToVehicleGroup == null)
            {
                return NotFound();
            }

            return View(vehicleToVehicleGroup);
        }

        // POST: VehicleToVehicleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleToVehicleGroup = await _context.VehicleToVehicleGroups.SingleOrDefaultAsync(m => m.VehicleToVehicleGroupID == id);
            _context.VehicleToVehicleGroups.Remove(vehicleToVehicleGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleToVehicleGroupExists(int id)
        {
            return _context.VehicleToVehicleGroups.Any(e => e.VehicleToVehicleGroupID == id);
        }
    }
}
