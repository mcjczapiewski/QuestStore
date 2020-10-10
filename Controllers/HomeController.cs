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

namespace QuestStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuestDBContext _context;
        private readonly ApplicationDbContext _credentials;

        public HomeController(ILogger<HomeController> logger, QuestDBContext context, ApplicationDbContext credentials)
        {
            _logger = logger;
            _context = context;
            _credentials = credentials;
        }


        public IActionResult Index()
        {
            // TODO: name and password from registration
            string loggingUserName = "regularUser";
            string loggingUserPwd = "password;";

            // save new user to DB
            LoginCredentials newCredentials = new LoginCredentials();
            newCredentials.UserName = loggingUserName;
            (newCredentials.PasswordSalt, newCredentials.PasswordHash) = Password.HashPassword(loggingUserPwd);
            _credentials.UserCredentials.Add(newCredentials);
            _credentials.SaveChanges();

            // password compare
            var userFromDb = _credentials.UserCredentials
                .FirstOrDefault(x => x.UserName == loggingUserName);
            bool validForLogin = Password.IfPasswordsMatch(userFromDb, loggingUserPwd);

            ViewData["valid"] = validForLogin;
            ViewData["allUsers"] = _context.Users.ToList();
            ViewData["accUser"] = _credentials.UserCredentials
                .OrderBy(q => q.Id)
                .FirstOrDefault()?.UserName;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}