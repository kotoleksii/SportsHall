using Microsoft.EntityFrameworkCore;
using SportsHall.Data;
using SportsHall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsHall.Services
{
    public static class UserService
    {
        public static async Task<List<ApplicationUser>> GetUsersByRole(ApplicationDbContext context, string role_str)
        {
            var UserInRole = await (from user in context.Users
                                    join userRole in context.UserRoles
                                    on user.Id equals userRole.UserId
                                    join role in context.Roles
                                    on userRole.RoleId equals role.Id
                                    where role.Name == role_str
                                    select user)
                                        .ToListAsync();
            return UserInRole;
        }
    }
}
