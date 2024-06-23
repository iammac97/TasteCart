using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasteCart.Services.AuthAPI.Models;

namespace TasteCart.Services.AuthAPI.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //Coupons will be the Db table name and we're fetching fields from 
        public DbSet<ApplicationUser>ApplicationUsers { get; set; }

        //Seed the data in DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
