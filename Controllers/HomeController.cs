﻿using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
    public class HomeController : ApplicationBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly horizonp_ccqueststoreContext _context;
        private readonly ApplicationDbContext _credentials;

        public HomeController(ILogger<HomeController> logger, horizonp_ccqueststoreContext context, ApplicationDbContext credentials)
        {
            _logger = logger;
            _context = context;
            _credentials = credentials;
        }


        public IActionResult Index()
        {
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