﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;
using QuestStore.ViewModels;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuestStore.Controllers
{
    [Authorize]
    public class QuestsController : ApplicationBaseController
    {
        private readonly horizonp_questcredentialsContext _context;

        public QuestsController(horizonp_questcredentialsContext context)
        {
            _context = context;
        }

        // GET: Quests
        public async Task<IActionResult> Index()
        {
            return View(await _context.Quests.ToListAsync());
        }

        // GET: Quests/MyQuests
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> MyQuests()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var quests = await _context.Users
                .Where(i => i.CredentialsId == userId)
                .SelectMany(q => q.UsersQuests)
                .Select(qs => qs.Quest)
                .ToListAsync();
            var questsStatus = await _context.UsersQuests
                .Where(i => i.UserId == _context.Users.First(x => x.CredentialsId == userId).UserId)
                .ToListAsync();
            ViewData["userQuests"] = questsStatus;
            return View(quests);
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> SignOn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quests = await _context.Quests
                .FirstOrDefaultAsync(m => m.QuestId == id);
            if (quests == null)
            {
                return NotFound();
            }

            var userId = _context.Users
                .Where(i => i.CredentialsId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .Select(uid => uid.UserId)
                .Single();
            ViewData["QuestTitle"] = quests.Title;
            if (_context.UsersQuests.Any(o => o.QuestId == quests.QuestId && o.UserId == userId))
            {
                ViewData["Exists"] = true;
                return View();
            }

            UsersQuests usersQuests = new UsersQuests
            {
                UserId = userId,
                QuestId = quests.QuestId,
                Status = "In progress"
            };
            if (ModelState.IsValid)
            {
                _context.Add(usersQuests);
                await _context.SaveChangesAsync();
            }
            return View();
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GroupSignOn(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quests = await _context.Quests
                .FirstOrDefaultAsync(m => m.QuestId == id);
            if (quests == null)
            {
                return NotFound();
            }

            var groupId = _context.Groups
                .Where(i => i.GroupId == _context.Users
                    .Single(x => x.CredentialsId == User.FindFirstValue(ClaimTypes.NameIdentifier)).GroupId)
                .Select(uid => uid.GroupId)
                .Single();
            ViewData["QuestTitle"] = quests.Title;
            if (_context.GroupsQuests.Any(o => o.QuestId == quests.QuestId && o.GroupId == groupId))
            {
                ViewData["Exists"] = true;
                return View(nameof(SignOn));
            }

            GroupsQuests groupsQuests = new GroupsQuests
            {
                GroupId = groupId,
                QuestId = quests.QuestId,
                Status = "In progress"
            };
            if (ModelState.IsValid)
            {
                _context.Add(groupsQuests);
                await _context.SaveChangesAsync();
            }
            return View(nameof(SignOn));
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GiveUp(int? id, string name)
        {
            var abandonedQuest = _context.UsersQuests
                .Single(i => i.QuestId == id && i.UserId == _context.Users.Single(x => x.CredentialsId == _context.AspNetUsers.Single(w => w.UserName == name).Id).UserId);
            _context.UsersQuests.Remove(abandonedQuest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyQuests));
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> MarkCompleted(int? id, string name)
        {
            var completeQuest = _context.UsersQuests
                .Single(i => i.QuestId == id && i.UserId == _context.Users.Single(x => x.CredentialsId == _context.AspNetUsers.Single(w => w.UserName == name).Id).UserId);
            completeQuest.Status = "Completed";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyQuests));
        }

        // GET: Quests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quests = await _context.Quests
                .FirstOrDefaultAsync(m => m.QuestId == id);
            if (quests == null)
            {
                return NotFound();
            }

            return View(quests);
        }

        // GET: Quests/Create
        [Authorize(Roles = "Admin, Mentor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quests/Create

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Create([Bind("QuestId,Title,Reward,Description,Extra")] Quests quests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quests);
        }

        // GET: Quests/Edit/5
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quests = await _context.Quests.FindAsync(id);
            if (quests == null)
            {
                return NotFound();
            }
            return View(quests);
        }

        // POST: Quests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int id, [Bind("QuestId,Title,Reward,Description,Extra")] Quests quests)
        {
            if (id != quests.QuestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestsExists(quests.QuestId))
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
            return View(quests);
        }

        // GET: Quests/Delete/5
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserNameOnQuest userNameOnQuest = new UserNameOnQuest
            {
                Quests = await _context.Quests
                    .FirstOrDefaultAsync(m => m.QuestId == id)
            };
            if (userNameOnQuest.Quests == null)
            {
                return NotFound();
            }
            var usersIdOnThisQuest = _context.UsersQuests
                .Where(i => i.QuestId == id)
                .Select(i => i.UserId)
                .ToList();
            var aspUsersOnThatQuest = _context.Users
                .Where(i => usersIdOnThisQuest.Contains(i.UserId))
                .Select(i => i.CredentialsId)
                .ToList();
            userNameOnQuest.UsersNameList = _context.AspNetUsers
                .Where(i => aspUsersOnThatQuest.Contains(i.Id))
                .Select(i => i.UserName)
                .ToList();

            return View(userNameOnQuest);
        }

        // POST: Quests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var quests = await _context.Quests.FindAsync(id);
            _context.Quests.Remove(quests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestsExists(int id)
        {
            return _context.Quests.Any(e => e.QuestId == id);
        }
    }
}
