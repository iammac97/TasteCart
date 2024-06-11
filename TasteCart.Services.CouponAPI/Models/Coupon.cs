using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using TasteCart.Services.CouponAPI.Models.Dto;

namespace TasteCart.Services.CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponId { get; set; }
        [Required]
        public string CouponCode { get; set; }
        [Required]
        public double DiscountAmount { get; set; }
        public int MinAmount {  get; set; }

  
        // public DateTime LastUpdated { get; set; }

    }
}
