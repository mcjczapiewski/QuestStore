﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuestStore.Controllers
{
    [Authorize(Roles = "Admin, Mentor")]
    public class ItemsController : ApplicationBaseController
    {
        private readonly horizonp_questcredentialsContext _context;

        public ItemsController(horizonp_questcredentialsContext context)
        {
            _context = context;
        }

        // GET: Items
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.CategorySortParm = String.IsNullOrEmpty(sortOrder) ? "Cat_Desc" : "";
            ViewBag.ExtraSortParm = String.IsNullOrEmpty(sortOrder) ? "Ex_Desc" : "";

            var horizonp_questcredentialsContext = from h in _context.Items select h;

            switch (sortOrder)
            {
                case "Cat_Desc":
                    horizonp_questcredentialsContext = horizonp_questcredentialsContext.OrderByDescending(h => h.Category);
                    break;
                case "Ex_Desc":
                    horizonp_questcredentialsContext = horizonp_questcredentialsContext.OrderByDescending(h => h.Extra);
                    break;
                default:
                    horizonp_questcredentialsContext = horizonp_questcredentialsContext.OrderBy(h => h.Extra);
                    break;
            }
            return View(await horizonp_questcredentialsContext.ToListAsync());
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,Name,Category,Extra")] Items items)
        {
            if (ModelState.IsValid)
            {
                _context.Add(items);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(items);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items.FindAsync(id);
            if (items == null)
            {
                return NotFound();
            }
            return View(items);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,Name,Category,Extra")] Items items)
        {
            if (id != items.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(items);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemsExists(items.ItemId))
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
            return View(items);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var items = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (items == null)
            {
                return NotFound();
            }

            return View(items);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var items = await _context.Items.FindAsync(id);
            _context.Items.Remove(items);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemsExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
