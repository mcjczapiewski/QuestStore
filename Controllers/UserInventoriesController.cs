using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuestStore.Models;

namespace QuestStore.Controllers
{
    public class UserInventoriesController : ApplicationBaseController
    {
        private readonly horizonp_questcredentialsContext _context;

        public UserInventoriesController(horizonp_questcredentialsContext context)
        {
            _context = context;
        }

        // GET: UserInventories
        public async Task<IActionResult> Index()
        {
            var horizonp_questcredentialsContext = _context.UserInventory
                .Include(u => u.Item)
                .Where(u => u.User.Credentials.UserName == User.Identity.Name);
            return View(await horizonp_questcredentialsContext.ToListAsync());
        }
    }
}
