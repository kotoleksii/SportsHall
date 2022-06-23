using Microsoft.EntityFrameworkCore;
using SportsHall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Data
{
    public class SportsHallContext:DbContext
    {
        public DbSet<Hall> Halls { get; set; }

        public SportsHallContext(DbContextOptions<SportsHallContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
