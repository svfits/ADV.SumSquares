using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using Microsoft.AspNetCore.Identity;

namespace ADV.Model.EF
{
    public class DataContextApp : IdentityDbContext
    {
        public DataContextApp(DbContextOptions<DataContextApp> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
    }
}
