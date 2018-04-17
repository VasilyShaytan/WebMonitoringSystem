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
    public class ParametersController : Controller
    {
        private readonly MonitoringSystemContext _context;

        public ParametersController(MonitoringSystemContext context)
        {
            _context = context;
        }

        // GET: Parameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Parameters.ToListAsync());
        }

        // GET: Parameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameters
                .SingleOrDefaultAsync(m => m.ParameterID == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // GET: Parameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParameterID,VehicleID,BasicParameterID,BasicParameterValue,BasicParameterTimeValue")] Parameter parameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parameter);
        }

        // GET: Parameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameters.SingleOrDefaultAsync(m => m.ParameterID == id);
            if (parameter == null)
            {
                return NotFound();
            }
            return View(parameter);
        }

        // POST: Parameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParameterID,VehicleID,BasicParameterID,BasicParameterValue,BasicParameterTimeValue")] Parameter parameter)
        {
            if (id != parameter.ParameterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParameterExists(parameter.ParameterID))
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
            return View(parameter);
        }

        // GET: Parameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parameter = await _context.Parameters
                .SingleOrDefaultAsync(m => m.ParameterID == id);
            if (parameter == null)
            {
                return NotFound();
            }

            return View(parameter);
        }

        // POST: Parameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parameter = await _context.Parameters.SingleOrDefaultAsync(m => m.ParameterID == id);
            _context.Parameters.Remove(parameter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParameterExists(int id)
        {
            return _context.Parameters.Any(e => e.ParameterID == id);
        }
    }
}
