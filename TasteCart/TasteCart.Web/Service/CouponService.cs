﻿using TasteCart.Web.Models;
using TasteCart.Web.Service.IService;
using TasteCart.Web.Utility;

namespace TasteCart.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        public CouponService(IBaseService baseService) 
        {
            _baseService=baseService;
        }


        public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data=couponDto,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/"
            });
        }

        public async Task<ResponseDto?> DeleteCouponAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/DeleteById"+id
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType=SD.ApiType.GET,
                ApiUrl=SD.CouponAPIBase+"/api/coupon"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/GetByCode"+couponCode
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                ApiUrl = SD.CouponAPIBase + "/api/coupon/GetById"+id
            });
        }

        public async Task<ResponseDto?> UpdateCouponAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data=couponDto,
                ApiUrl = SD.CouponAPIBase + "/api/coupon"
            });
        }
    }
}
