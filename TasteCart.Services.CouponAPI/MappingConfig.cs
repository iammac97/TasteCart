using AutoMapper;
using TasteCart.Services.CouponAPI.Models;
using TasteCart.Services.CouponAPI.Models.Dto;

namespace TasteCart.Services.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig=new MapperConfiguration(config=>
            {
                //configuration CouponDto to Coupon and vice versa
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });
            return mappingConfig;
        }
    }
}
