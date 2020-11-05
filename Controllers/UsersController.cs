using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;


namespace QuestStore.Controllers
{
    [Authorize(Roles = "Admin, Mentor")]
    public class UsersController : ApplicationBaseController
    {
        private readonly horizonp_questcredentialsContext _context;

        public UsersController(horizonp_questcredentialsContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchString)
        {
            var horizonp_questcredentialsContext = from h in _context.Users.Include(u => u.Group)
                                                   select h;
            if (!String.IsNullOrEmpty(searchString))
            {
                horizonp_questcredentialsContext = horizonp_questcredentialsContext.Where(s => s.Surname.Contains(searchString) || s.Name.Contains(searchString));
            }
            return View(await horizonp_questcredentialsContext.ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Group)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", users.GroupId);
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Gender,Age,Mentor,GroupId,Name,Surname")] Users users)
        {
            if (id != users.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var updateUser = _context.Users.Single(u => u.UserId == id);
                    updateUser.Name = users.Name;
                    updateUser.Surname = users.Surname;
                    updateUser.Gender = users.Gender;
                    updateUser.Mentor = users.Mentor;
                    updateUser.GroupId = users.GroupId;
                    updateUser.Age = users.Age;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(users.UserId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "Name", users.GroupId);
            return View(users);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = await _context.Users
                .Include(u => u.Group)
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var users = await _context.Users.FindAsync(id);
            _context.Users.Remove(users);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}
