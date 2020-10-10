using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuestStore.Data;
using QuestStore.Models;

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
            // TODO: just to illustrate, need to be changed to given from user on website
            string userPassword = "abcd";

            // generate salt and hashed password
            var salt = new byte[10];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(userPassword, salt, KeyDerivationPrf.HMACSHA1, 1000, 256 / 8));

            // write the salt and hash to database
            // TODO: need to retrieve data for user by name
            //var userToUpdate = _credentials.UserCredentials
            //    .OrderBy(q => q.Id)
            //    .FirstOrDefault();
            //if (userToUpdate != null)
            //{
            //    userToUpdate.PasswordSalt = salt;
            //    userToUpdate.PasswordHash = hashed;
            //}
            //_credentials.SaveChanges();

            // compare password stored in db with just given
            // TODO: need to retrieve data for user by name
            var userFromDb = _credentials.UserCredentials
                .OrderBy(q => q.Id)
                .FirstOrDefault();
            var saltFromDb = userFromDb.PasswordSalt;
            var hashFromDb = userFromDb.PasswordHash;
            string hashedAgainToCompare = Convert.ToBase64String(KeyDerivation.Pbkdf2(userPassword, saltFromDb, KeyDerivationPrf.HMACSHA1, 1000, 256 / 8));
            if (hashedAgainToCompare == hashFromDb)
            {
                // TODO: user valid for login
            }

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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
