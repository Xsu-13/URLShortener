using Microsoft.EntityFrameworkCore;
using Pet_Project.Persistence.Configurations;
using Pet_Project.Persistence.Entities;
using System;
using System.Reflection.Emit;

namespace Pet_Project.Persistence
{
    public class URLGeneratingDBContext(DbContextOptions<URLGeneratingDBContext> options) : DbContext(options)
    {
        public DbSet<URLEntity> Urls { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new URLConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
