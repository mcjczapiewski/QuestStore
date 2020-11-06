using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;

namespace QuestStore.Controllers
{
    [Authorize]
    public class StoresController : ApplicationBaseController
    {
        private readonly horizonp_questcredentialsContext _context;

        public StoresController(horizonp_questcredentialsContext context)
        {
            _context = context;
        }

        // GET: Stores
        public async Task<IActionResult> Index()
        {
            var horizonp_questcredentialsContext = _context.Store.Include(s => s.Item);
            return View(await horizonp_questcredentialsContext.ToListAsync());
        }

        [Authorize(Roles = "Student")]
        public async Task<IActionResult> BuyItem(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemToBuy = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (itemToBuy == null)
            {
                return NotFound();
            }

            TempData["ItemInInventory"] = false;
            TempData["YouArePoor"] = false;

            var userId = _context.Users
                .Where(i => i.CredentialsId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                .Select(uid => uid.UserId)
                .Single();
            var itemExists = false;

            if (_context.UserInventory.Any(o => o.ItemId == itemToBuy.ItemId && o.UserId == userId))
            {
                if (!_context.UserInventory.Single(i => i.ItemId == id).ItemUsed)
                {
                    TempData["ItemInInventory"] = true;
                    return RedirectToAction("Index");
                }
                itemExists = true;
            }
            var userBalance = _context.Wallet
                .Single(i => i.UserId == userId);
            var itemInStore = _context.Store
                .Single(i => i.ItemId == itemToBuy.ItemId);
            if (userBalance.Balance < itemInStore.Price)
            {
                TempData["YouArePoor"] = true;
                return RedirectToAction("Index");
            }

            UserInventory userInventory = new UserInventory();
            userInventory.UserId = userId;
            userInventory.ItemId = itemToBuy.ItemId;

            if (ModelState.IsValid)
            {
                var updatedBalance = userBalance.Balance - itemToBuy.Store.Price;
                userBalance.Balance = updatedBalance;
                itemInStore.NumberAvailable -= 1;
                if (!itemExists)
                {
                    _context.Add(userInventory);
                }
                else
                {
                    _context.UserInventory
                        .Single(i => i.ItemId == itemToBuy.ItemId && i.UserId == userId).ItemUsed = false;
                }
                await _context.SaveChangesAsync();
            }
            TempData["ItemAdded"] = true;
            return RedirectToAction("Index");
        }

        // GET: Stores/Edit/5
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Store.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Extra", store.ItemId);
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Mentor")]
        public async Task<IActionResult> Edit(int id, [Bind("StoreItemId,NumberAvailable,Price")] Store store)
        {
            if (id != store.StoreItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ItemToUpdate = _context.Store.FirstOrDefault(i => i.StoreItemId == id);
                    ItemToUpdate.Price = store.Price;
                    ItemToUpdate.NumberAvailable = store.NumberAvailable;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreExists(store.StoreItemId))
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
            return View(store);
        }

        private bool StoreExists(int id)
        {
            return _context.Store.Any(e => e.StoreItemId == id);
        }
    }
}
