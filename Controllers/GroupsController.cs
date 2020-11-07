using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;
using System.Linq;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuestStore.Controllers
{
    [Authorize]
    public class GroupsController : ApplicationBaseController
    {
        private readonly horizonp_questcredentialsContext _context;

        public GroupsController(horizonp_questcredentialsContext context)
        {
            _context = context;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("Student"))
            {
                return RedirectToAction("Details",
                    new
                    {
                        id = _context.Users
                            .Single(i => i.CredentialsId == User.FindFirstValue(ClaimTypes.NameIdentifier)).GroupId
                    });
            }

            return View(await _context.Groups.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groupMembers = await _context.Users
                .Where(i => i.GroupId == id)
                .ToListAsync();
            var technologies = await _context.UsersTech.ToListAsync();
            var group = await _context.Groups
                .SingleAsync(i => i.GroupId == id);
            var groupInventory = await _context.GroupsInventory
                .Where(i => i.GroupId == id)
                .ToListAsync();
            var itemsInGroupInventory = await _context.Items
                .Where(i => groupInventory.Select(x => x.ItemId).ToList().Contains(i.ItemId))
                .ToListAsync();
            var tupleModel = new Tuple<List<Users>, List<UsersTech>, List<Technologies>, Groups, List<GroupsInventory>, List<Items>>
                (groupMembers, technologies, _context.Technologies.ToList(), group, groupInventory, itemsInGroupInventory);

            return View(tupleModel);
        }

        // GET: Groups/Create
        [Authorize(Roles = "Admin, Mentor")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Create([Bind("GroupId,Name,NumberOfPpl")] Groups groups)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(groups);
        }

        // GET: Groups/Edit/5
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groups = await _context.Groups.FindAsync(id);
            if (groups == null)
            {
                return NotFound();
            }

            return View(groups);
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,Name,NumberOfPpl")] Groups groups)
        {
            if (id != groups.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupsExists(groups.GroupId))
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

            return View(groups);
        }

        // GET: Groups/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var groups = await _context.Groups
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (groups == null)
            {
                return NotFound();
            }

            return View(groups);
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groups = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(groups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupsExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }

        public async Task<IActionResult> Deposit(int GroupId, decimal AddMoney)
        {
            try
            {
                var userWallet = _context.Wallet
                    .Single(i => i.UserId == _context.Users.Single(i => i.CredentialsId == User.FindFirstValue(ClaimTypes.NameIdentifier)).UserId);
                var groupUpdate = _context.Groups
                    .Single(i => i.GroupId == GroupId);
                userWallet.Balance -= AddMoney;
                groupUpdate.GroupBank += AddMoney;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupsExists(GroupId))
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

        public async Task<IActionResult> UseItem(int? id)
        {
            var item = _context.GroupsInventory
                .Single(i => i.InventoryId == id);
            item.ItemUsed = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}