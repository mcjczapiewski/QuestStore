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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quests/Create
        [Authorize(Roles = "Admin")]
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Quests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
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
