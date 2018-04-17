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
    public class UserToRolesController : Controller
    {
        private readonly MonitoringSystemContext _context;

        public UserToRolesController(MonitoringSystemContext context)
        {
            _context = context;
        }

        // GET: UserToRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserToRoles.ToListAsync());
        }

        // GET: UserToRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToRole = await _context.UserToRoles
                .SingleOrDefaultAsync(m => m.UserToRoleID == id);
            if (userToRole == null)
            {
                return NotFound();
            }

            return View(userToRole);
        }

        // GET: UserToRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserToRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserToRoleID,UserID,RoleID")] UserToRole userToRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userToRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userToRole);
        }

        // GET: UserToRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToRole = await _context.UserToRoles.SingleOrDefaultAsync(m => m.UserToRoleID == id);
            if (userToRole == null)
            {
                return NotFound();
            }
            return View(userToRole);
        }

        // POST: UserToRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserToRoleID,UserID,RoleID")] UserToRole userToRole)
        {
            if (id != userToRole.UserToRoleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userToRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserToRoleExists(userToRole.UserToRoleID))
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
            return View(userToRole);
        }

        // GET: UserToRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userToRole = await _context.UserToRoles
                .SingleOrDefaultAsync(m => m.UserToRoleID == id);
            if (userToRole == null)
            {
                return NotFound();
            }

            return View(userToRole);
        }

        // POST: UserToRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userToRole = await _context.UserToRoles.SingleOrDefaultAsync(m => m.UserToRoleID == id);
            _context.UserToRoles.Remove(userToRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserToRoleExists(int id)
        {
            return _context.UserToRoles.Any(e => e.UserToRoleID == id);
        }
    }
}
