using HRManageIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManageIdentity.DbContext
{
    public class HRManageIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HRManageIdentityDbContext(DbContextOptions<HRManageIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HRManageIdentityDbContext).Assembly);
        }
    }
}
