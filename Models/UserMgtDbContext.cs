using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserMgtApp.Models;

namespace UserMgtApp.Models
{
    public class UserMgtDbContext : DbContext
    {
        public UserMgtDbContext(DbContextOptions<UserMgtDbContext> options) : base(options)
        {
            //
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Nationalities> Nationalities { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
