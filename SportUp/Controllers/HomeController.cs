﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SportUp.Data;
using SportUp.Data.Models;
using SportUp.Managers;
using SportUp.Models;
using SportUp.Models.ViewModels;

namespace SportUp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly SportUpUserManager _userManager;
        private readonly SignInManager<SportUpUser> _signInManager;
        private readonly SportManager _sportManager;

        public HomeController(
            ILogger<HomeController> logger, 
            ApplicationDbContext context,
            SportUpUserManager userManager,
            SignInManager<SportUpUser> signInManager,
            SportManager sportManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _sportManager = sportManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var viewModel = new IndexViewModel()
            {
                AvailableSports = await _sportManager.GetSportsAsync(),
            };

            var user = await _userManager.GetUserAsync(User);
            if (_signInManager.IsSignedIn(User))
                viewModel.SportsUserIsEnrolledIn = _userManager.GetEnrolledSports(user);

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddSportAsync(IndexViewModel viewModel)
        {
            var user = await _userManager.GetUserAsync(User);
            await _userManager.AddSportToUserAsync(user, new Sport());

            return RedirectToAction("Index");
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
