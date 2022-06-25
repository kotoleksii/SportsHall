using Microsoft.AspNetCore.Identity;
using SportsHall.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Status { get; set; }
        public string Specialization { get; set; }
        public string WorkTime { get; set; }
    }
}
