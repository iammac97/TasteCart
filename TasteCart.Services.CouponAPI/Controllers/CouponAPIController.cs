using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
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
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper=mapper;
            _response = new ResponseDto();

        }

        [HttpGet]
        public ResponseDto Get()
        {
           // _response.IsSuccess = true;
            //_response.Message = "Data Fetched Successfully...";
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = _mapper.Map<IEnumerable<CouponDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message   = "Exception Occurs : " + ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetById/{id:int}")]
        public ResponseDto Get(int id)
        {
            //.IsSuccess = true;
            //_response.Message = "Data Fetched Successfully..";
            try
            {
               Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                _response.Result =_mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Exception Occurs : " + ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetByCode/{code}")]
        public ResponseDto GetByCode(string code)   
         {
            //_response.IsSuccess = true;
            //_response.Message = "Data Fetched Successfully..";
            try
            {
                Coupon obj1 = _db.Coupons.FirstOrDefault(u =>u.CouponCode.ToLower()== code.ToLower());
                if(obj1 == null)
                {
                    _response.IsSuccess=false;
                }
                _response.Result = _mapper.Map<CouponDto>(obj1);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Exception Occurs : " + ex.Message;
            }
            return _response;
        }
 
        [HttpPost]

        public ResponseDto Post([FromBody] CouponDto couponDto) 
        {
            //_response.IsSuccess = true;
            //_response.Message = "Data Successfully Added..";
            try
            {
                Coupon obj = _mapper.Map<Coupon>(couponDto);
                _db.Coupons.Add(obj);
                _db.SaveChanges();
                _response.Result = _mapper.Map<CouponDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Exception Occurs : " + ex.Message;
            }
            return _response;
        }

        [HttpPut]
        [Route("UpdateById/{id}")]
        public ResponseDto put([FromBody] CouponDto couponDto)
        {
            //_response.IsSuccess = true;
            //_response.Message = "Data Successfully Updated..";
            try
            {
                Coupon obj=_mapper.Map<Coupon>(couponDto);
                _db.Coupons.Update(obj);
                _db.SaveChanges();

                _response.Result=_mapper.Map<CouponDto>(obj);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Exception Occurs : " + ex.Message;

            }
            return _response;
        }

        [HttpDelete]
        [Route("DeleteById/{id}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                //_response.IsSuccess = true;
                //_response.Message = "Data Successfully Deleted..";
                Coupon obj = _db.Coupons.First(u=>u.CouponId==id);
                _db.Coupons.Remove(obj);
                _db.SaveChanges();


            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = "Exception Occurs : " + ex.Message;

            }
            return _response;
        }
    }
}
