using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SportsHall.Data;
using SportsHall.Models;
using SportsHall.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Controllers
{
    public class TrainingController : Controller
    {
        ApplicationDbContext db;

        public TrainingController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Trainings.ToList());
        }

        [Authorize(Roles = "Admin, Coach")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Training training = await db.Trainings.FirstOrDefaultAsync(p => p.TrainingId == id);
                if (training != null)
                    return View(training);
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin, Coach")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Training training = await db.Trainings.FirstOrDefaultAsync(p => p.TrainingId == id);
                if (training != null)
                {
                    db.Trainings.Remove(training);
                    await db.SaveChangesAsync();


                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
