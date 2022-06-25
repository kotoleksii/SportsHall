using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SportsHall.Data;
using SportsHall.Models;
using SportsHall.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db;
        private readonly IConfiguration Configuration;

        public HomeController(ApplicationDbContext context, IConfiguration _configuration)
        {
            db = context;
            Configuration = _configuration;
        }

        public IActionResult Index()
        {
            var userInCoachRole = UserService.GetUsersByRole(db, "Coach").Result;
            var userInClientRole = UserService.GetUsersByRole(db, "Client").Result;

            ViewBag.CoachCount = userInCoachRole.Count;
            ViewBag.ClientCount = userInClientRole.Count;
            ViewBag.HallsCount = db.Halls.Count();

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
