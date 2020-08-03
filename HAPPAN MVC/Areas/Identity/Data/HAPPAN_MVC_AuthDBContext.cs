using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAPPAN_MVC.Areas.Identity.Data;
using HAPPAN_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HAPPAN_MVC.Data
{
    public class HAPPAN_MVC_AuthDBContext : IdentityDbContext<HAPPAN_MVCUser>
    {
        public HAPPAN_MVC_AuthDBContext(DbContextOptions<HAPPAN_MVC_AuthDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
