using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SA.Models
{
    public class SAContext : IdentityDbContext<AplicationUser>
    {
        public SAContext()
        {
        }

        public SAContext(DbContextOptions<SAContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
        /*
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SAContext>
    {
        public SAContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<SAContext>();
            var connectionString = configuration.GetConnectionString("SAContextConnection");
            builder.UseSqlServer(connectionString);
            return new SAContext(builder.Options);
        }
    }*/
    
}
