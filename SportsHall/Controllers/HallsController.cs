using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SportsHall.Data;
using SportsHall.Enums;
using SportsHall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Controllers
{
    public class HallsController : Controller
    {
        ApplicationDbContext db;
        private readonly IConfiguration Configuration;

        public HallsController(ApplicationDbContext context, IConfiguration _configuration)
        {
            db = context;
            Configuration = _configuration;
        }

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "Id" : "";
            ViewBag.TitleSortParm = sortOrder == "Title" ? "title_desc" : "Title";

            int pageSize = 2;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var halls = from i in db.Halls
                        select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                halls = halls.Where(i => i.Title.Contains(searchString)
                            || i.Description.Contains(searchString)
                        || i.Id.ToString().Contains(searchString)
                    );
            }

            switch (sortOrder)
            {
                case "Id":
                    halls = halls.OrderBy(s => s.Id);
                    break;
                case "Title":
                    halls = halls.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    halls = halls.OrderByDescending(s => s.Title);
                    break;
                default:
                    halls = halls.OrderByDescending(s => s.Id);
                    break;
            }

            return View(await PaginatedList<Hall>.CreateAsync(halls.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) RedirectToAction("Index");

            Hall hall = null;

            try
            {
                hall = await db.Halls.FindAsync(id);
            }
            catch { }

            return View("Details", hall);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Hall hall)
        {
            db.Halls.Add(hall);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Hall hall = await db.Halls.FirstOrDefaultAsync(p => p.Id == id);
                if (hall != null)
                    return View(hall);
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(Hall hall)
        {
            db.Halls.Update(hall);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Hall hall = await db.Halls.FirstOrDefaultAsync(p => p.Id == id);
                if (hall != null)
                    return View(hall);
            }
            return NotFound();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Hall hall = await db.Halls.FirstOrDefaultAsync(p => p.Id == id);
                if (hall != null)
                {
                    db.Halls.Remove(hall);
                    await db.SaveChangesAsync();


                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }
    }
}
