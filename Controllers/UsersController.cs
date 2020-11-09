using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;
using QuestStore.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


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
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name_Desc" : "";
            ViewBag.MentorSortParm = String.IsNullOrEmpty(sortOrder) ? "Title_Desc" : "";

            var horizonp_questcredentialsContext = from h in _context.Users.Include(u => u.Group)
                                                   select h;
            if (!String.IsNullOrEmpty(searchString))
            {
                horizonp_questcredentialsContext = horizonp_questcredentialsContext
                                .Where(s => s.Surname.Contains(searchString) || s.Name
                                .Contains(searchString) || (s.Name + " " + s.Surname)
                                .Contains(searchString));
            }

            horizonp_questcredentialsContext = sortOrder switch
            {
                "Name_Desc" => horizonp_questcredentialsContext.OrderByDescending(h => h.Name),
                "Title_Desc" => horizonp_questcredentialsContext.OrderByDescending(h => h.Mentor),
                _ => horizonp_questcredentialsContext.OrderBy(h => h.Mentor)
            };
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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userQuests = _context.UsersQuests
                .Where(i => i.UserId == users.UserId)
                .ToList();
            var quests = await _context.Quests
                .Where(i => userQuests
                    .Select(i => i.QuestId).Contains(i.QuestId))
                .ToListAsync();

            var technologies = await _context.UsersTech.ToListAsync();
            var userDetailsModel = new UserDetails
            {
                Users = users,
                UsersTechs = technologies,
                Technologies = _context.Technologies.ToList(),
                Quests = quests,
                UsersQuests = userQuests
            };

            return View(userDetailsModel);
        }

        // GET: Users/Edit/5
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
                    if (User.IsInRole("Admin"))
                    {
                        updateUser.Name = users.Name;
                        updateUser.Surname = users.Surname;
                        updateUser.Gender = users.Gender;
                        updateUser.Mentor = users.Mentor;
                        updateUser.Age = users.Age;
                    };
                    updateUser.GroupId = users.GroupId;
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

        public async Task<IActionResult> Reward(int? id, int? userId)
        {
            var userWallet = _context.Wallet
                .Single(i => i.UserId == userId);
            var questReward = _context.Quests
                .Single(i => i.QuestId == id).Reward;
            userWallet.Balance += questReward;
            var thisUserQuest = _context.UsersQuests
                .Single(i => i.QuestId == id && i.UserId == userId);
            thisUserQuest.Status = "Rewarded";
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = userId });
        }
    }
}
