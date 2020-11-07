using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestStore.Data;
using QuestStore.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace QuestStore.Controllers
{
    public class HomeController : ApplicationBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly horizonp_questcredentialsContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, horizonp_questcredentialsContext context,SignInManager<IdentityUser> signInManager)
        {
            _logger = logger;
            _context = context;
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userId = _context.Users
                    .Where(i => i.CredentialsId == User.FindFirstValue(ClaimTypes.NameIdentifier))
                    .Select(uid => uid.UserId)
                    .Single();

                TempData["FillData"] = false;

                var nameCheck = _context.Users.Where(n => n.UserId == userId)
                    .Select(name => name.Name)
                    .Single();
                var surnameCheck = _context.Users.Where(s => s.UserId == userId)
                    .Select(surname => surname.Surname)
                    .Single();

                if (nameCheck == null || surnameCheck == null)
                {
                    TempData["FillData"] = true;
                    return LocalRedirect("/Identity/Account/Manage/Index");
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}