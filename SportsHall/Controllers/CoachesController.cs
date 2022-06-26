using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SportsHall.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SportsHall.Models;
using SportsHall.Services;

namespace SportsHall.Controllers
{
    public class CoachesController : Controller
    {
        ApplicationDbContext db;
        private readonly IConfiguration Configuration;

        public CoachesController(ApplicationDbContext context, IConfiguration _configuration)
        {
            db = context;
            Configuration = _configuration;
        }
        public IActionResult Index()
        {
            var userInCoachRole = UserService.GetUsersByRole(db, "Coach").Result;

            return View(userInCoachRole);
        }

        private string GetCoachFirstNameByID(string id)
        {
            return db.Users.Find(id).FirstName;
        }

        [HttpGet]
        public IActionResult SignUp(string id)
        {
            if (id == null) return RedirectToAction("Index");

            ViewData["ClientId"] = id;
            ViewBag.CoachName = GetCoachFirstNameByID(id);

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(Training training)
        {
            db.Trainings.Add(training);

            db.SaveChanges();

            return RedirectToAction("Index", "Training");
        }
    }
}
