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
    }
}
