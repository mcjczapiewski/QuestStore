using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

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

            var loggedUser = _context.Users
                .Single(i => i.CredentialsId == User.FindFirstValue(ClaimTypes.NameIdentifier));
            var userId = loggedUser.UserId;
            var groupId = loggedUser.GroupId;

            var itemExists = false;

            if (itemToBuy.Category == "Magic")
            {
                if (_context.GroupsInventory.Any(o => o.ItemId == itemToBuy.ItemId && o.GroupId == groupId))
                {
                    if (!_context.GroupsInventory.Single(i => i.ItemId == id).ItemUsed)
                    {
                        TempData["ItemInInventory"] = true;
                        return RedirectToAction("Index");
                    }
                    itemExists = true;
                }
            }
            else
            {
                if (_context.UserInventory.Any(o => o.ItemId == itemToBuy.ItemId && o.UserId == userId))
                {
                    if (!_context.UserInventory.Single(i => i.ItemId == id).ItemUsed)
                    {
                        TempData["ItemInInventory"] = true;
                        return RedirectToAction("Index");
                    }
                    itemExists = true;
                }
            }

            var userBalance = _context.Wallet
                .Single(i => i.UserId == userId);
            var group = _context.Groups
                .Single(i => i.GroupId == groupId);
            var groupBalance = group.GroupBank;
            var itemInStore = _context.Store
                .Single(i => i.ItemId == itemToBuy.ItemId);

            GroupsInventory groupsInventory = new GroupsInventory();
            UserInventory userInventory = new UserInventory();

            if (itemToBuy.Category == "Magic")
            {
                if (groupBalance < itemInStore.Price)
                {
                    TempData["YouArePoor"] = true;
                    return RedirectToAction("Index");
                }
                groupsInventory.GroupId = groupId;
                groupsInventory.ItemId = itemToBuy.ItemId;
            }
            else
            {
                if (userBalance.Balance < itemInStore.Price)
                {
                    TempData["YouArePoor"] = true;
                    return RedirectToAction("Index");
                }
                userInventory.UserId = userId;
                userInventory.ItemId = itemToBuy.ItemId;
            }

            if (ModelState.IsValid)
            {
                if (itemToBuy.Category == "Magic")
                {
                    var updatedBalance = group.GroupBank - itemToBuy.Store.Price;
                    group.GroupBank = updatedBalance;
                    if (!itemExists)
                    {
                        _context.Add(groupsInventory);
                    }
                    else
                    {
                        _context.GroupsInventory
                            .Single(i => i.ItemId == itemToBuy.ItemId && i.GroupId == groupId).ItemUsed = false;
                    }
                }
                else
                {
                    var updatedBalance = userBalance.Balance - itemToBuy.Store.Price;
                    userBalance.Balance = updatedBalance;
                    if (!itemExists)
                    {
                        _context.Add(userInventory);
                    }
                    else
                    {
                        _context.UserInventory
                            .Single(i => i.ItemId == itemToBuy.ItemId && i.UserId == userId).ItemUsed = false;
                    }
                }
                itemInStore.NumberAvailable -= 1;
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
