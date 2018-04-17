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
    public class BasicParametersController : Controller
    {
        private readonly MonitoringSystemContext _context;

        public BasicParametersController(MonitoringSystemContext context)
        {
            _context = context;
        }

        // GET: BasicParameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.BasicParameters.ToListAsync());
        }

        // GET: BasicParameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicParameter = await _context.BasicParameters
                .SingleOrDefaultAsync(m => m.BasicParameterID == id);
            if (basicParameter == null)
            {
                return NotFound();
            }

            return View(basicParameter);
        }

        // GET: BasicParameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BasicParameters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasicParameterID,PGN,PGL,Acronym,SPNName,SPNNameRu,DataRange,DataSource")] BasicParameter basicParameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basicParameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(basicParameter);
        }

        // GET: BasicParameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicParameter = await _context.BasicParameters.SingleOrDefaultAsync(m => m.BasicParameterID == id);
            if (basicParameter == null)
            {
                return NotFound();
            }
            return View(basicParameter);
        }

        // POST: BasicParameters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BasicParameterID,PGN,PGL,Acronym,SPNName,SPNNameRu,DataRange,DataSource")] BasicParameter basicParameter)
        {
            if (id != basicParameter.BasicParameterID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basicParameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicParameterExists(basicParameter.BasicParameterID))
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
            return View(basicParameter);
        }

        // GET: BasicParameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicParameter = await _context.BasicParameters
                .SingleOrDefaultAsync(m => m.BasicParameterID == id);
            if (basicParameter == null)
            {
                return NotFound();
            }

            return View(basicParameter);
        }

        // POST: BasicParameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basicParameter = await _context.BasicParameters.SingleOrDefaultAsync(m => m.BasicParameterID == id);
            _context.BasicParameters.Remove(basicParameter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicParameterExists(int id)
        {
            return _context.BasicParameters.Any(e => e.BasicParameterID == id);
        }
    }
}
