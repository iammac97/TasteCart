using Microsoft.EntityFrameworkCore;
using TasteCart.Services.CouponAPI.Models;

namespace TasteCart.Services.CouponAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        //Coupons will be the Db table name and we're fetching fields from coupon model
        public DbSet<Coupon>Coupons { get; set; }

        //Seed the data in DB
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 1,
                CouponCode = "10OFF",
                DiscountAmount = 10,
                MinAmount = 20,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 2,
                CouponCode = "20OFF",
                DiscountAmount = 20,
                MinAmount = 40,
            });

            modelBuilder.Entity<Coupon>().HasData(new Coupon
            {
                CouponId = 3,
                CouponCode = "50OFF",
                DiscountAmount = 50,
                MinAmount = 100,
            });
        }
    }
}
