using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReviewAppMVC2.Models;
using System;

namespace ReviewAppMVC2.DAL
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MediaFile> MediaFiles { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ReviewAppMVC;Trusted_Connection=True;");
        }
    }
}
