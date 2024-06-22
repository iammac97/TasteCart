using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TasteCart.Web.Models;
using TasteCart.Web.Service.IService;

namespace TasteCart.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ICouponService _couponService;
        public CouponController(ICouponService couponService)
        {
            _couponService = couponService;
        }

        //To fetch all the coupons details on index page
        public async  Task<IActionResult> CouponIndex()
        {
            List<CouponDto>? list = new();
            ResponseDto? responese = await _couponService.GetAllCouponsAsync();
            if (responese != null && responese.IsSuccess)
            {
                list=JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(responese.Result));
            }
            else
            {
                TempData["error"] = responese?.Message;
            }
            return View(list);
        }

        //Add button for view create coupon page
        public async Task<IActionResult>CouponCreate()
        {
            return View();
        }

        //Controller for create coupon
        [HttpPost]
        public async Task<IActionResult> CouponCreate(CouponDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? responese = await _couponService.CreateCouponsAsync(model);
                if (responese != null && responese.IsSuccess)
                {
                    TempData["success"] ="Coupon created successfully!";
                    return RedirectToAction(nameof(CouponIndex));
                }
                else
                {
                    TempData["error"] = responese?.Message;
                }
            }
            return View(model);
        }

        //fetch the details view of the coupon you want to delete
        public async Task<IActionResult> CouponDelete(int couponId)
        {
            ResponseDto? responese = await _couponService.GetCouponByIdAsync(couponId);
            if (responese != null && responese.IsSuccess)
            {
                CouponDto? model = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responese.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = responese?.Message;
            }
            return NotFound();
		}


        //Controller to delete the currrent coupon
        [HttpPost]
		public async Task<IActionResult> CouponDelete(CouponDto couponDto)
		{
			ResponseDto? responese = await _couponService.DeleteCouponAsync(couponDto.CouponId);
			if (responese != null && responese.IsSuccess)
			{
                TempData["success"] = "Coupon deleted duccessfully!";
                return RedirectToAction(nameof(CouponIndex));
			}
            else
            {
                TempData["error"] = responese?.Message;
            }
            return View(couponDto);
		}
	}
}
