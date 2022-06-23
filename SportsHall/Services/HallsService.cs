using SportsHall.Data;
using SportsHall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Services
{
    public static class HallsService
    {
        public static void Initialize(SportsHallContext context)
        {
            if (!context.Halls.Any())
            {
                context.Halls.AddRange(
                    new Hall { Title = "test1title", Description = "test1description" },
                    new Hall { Title = "test2title", Description = "test2description" },
                    new Hall { Title = "test3title", Description = "test3description" }
                );
                context.SaveChanges();
            }
        }
    }
}
