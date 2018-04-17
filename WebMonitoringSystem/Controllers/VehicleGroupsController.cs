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
    public class VehicleGroupsController : Controller
    {
        private readonly MonitoringSystemContext _context;

        public VehicleGroupsController(MonitoringSystemContext context)
        {
            _context = context;
        }

        // GET: VehicleGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.VehicleGroups.ToListAsync());
        }

        // GET: VehicleGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleGroup = await _context.VehicleGroups
                .SingleOrDefaultAsync(m => m.VehicleGroupID == id);
            if (vehicleGroup == null)
            {
                return NotFound();
            }

            return View(vehicleGroup);
        }

        // GET: VehicleGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleGroupID,VehicleGroupName")] VehicleGroup vehicleGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleGroup);
        }

        // GET: VehicleGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleGroup = await _context.VehicleGroups.SingleOrDefaultAsync(m => m.VehicleGroupID == id);
            if (vehicleGroup == null)
            {
                return NotFound();
            }
            return View(vehicleGroup);
        }

        // POST: VehicleGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleGroupID,VehicleGroupName")] VehicleGroup vehicleGroup)
        {
            if (id != vehicleGroup.VehicleGroupID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleGroupExists(vehicleGroup.VehicleGroupID))
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
            return View(vehicleGroup);
        }

        // GET: VehicleGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleGroup = await _context.VehicleGroups
                .SingleOrDefaultAsync(m => m.VehicleGroupID == id);
            if (vehicleGroup == null)
            {
                return NotFound();
            }

            return View(vehicleGroup);
        }

        // POST: VehicleGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleGroup = await _context.VehicleGroups.SingleOrDefaultAsync(m => m.VehicleGroupID == id);
            _context.VehicleGroups.Remove(vehicleGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleGroupExists(int id)
        {
            return _context.VehicleGroups.Any(e => e.VehicleGroupID == id);
        }
    }
}
