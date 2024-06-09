using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TasteCart.Services.CouponAPI.Data;
using TasteCart.Services.CouponAPI.Models;
using TasteCart.Services.CouponAPI.Models.Dto;

namespace TasteCart.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        public CouponAPIController(AppDbContext db)
        {
            _db = db;
            _response = new ResponseDto();

        }

        [HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = objList;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message   = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
               Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                _response.Result = obj; ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)   
         {
            try
            {
                Coupon obj1 = _db.Coupons.FirstOrDefault(u =>u.CouponCode.ToLower()== code.ToLower());
                if(obj1 == null)
                {
                    _response.IsSuccess=false;
                }
                _response.Result = obj1; ;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message; 
            }
            return _response;
        }

    }
}
