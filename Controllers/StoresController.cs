using System;
using System.Collections.Generic;
using System.Linq;
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
