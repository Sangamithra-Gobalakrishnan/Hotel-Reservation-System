using HotelInformationAPI.Interface;
using HotelInformationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HotelFitlerController : ControllerBase
    {
        private readonly IHotelSummaryService<Hotel, string, double, int> _service;

        public HotelFitlerController(IHotelSummaryService<Hotel,string,double,int> service)
        {
            _service = service;
        }

        [HttpGet("FETCH ALL HOTELS")]
        public ActionResult<ICollection<Hotel>> FetchAllHotels()
        {
            var hotels = _service.GetAll();
            if (hotels != null)
                return Created("Hotels List", hotels);
            return BadRequest("Oops!No Hotels Available");
        }

        [HttpGet("GET HOTELS BY LOCATION")]
        public ActionResult<ICollection<Hotel>> FetchByLocation(string location)
        {
            var hotels = _service.GetByLocation(location);
            if (hotels != null)
                return Created("Hotels List", hotels);
            return BadRequest("Oops!No Hotels Available In This Location Currently");
        }

        [HttpGet("GET HOTELS BY PRICE RANGE")]
        public ActionResult<ICollection<Hotel>> FetchByPriceRange(double minRange)
        {
            var hotels = _service.GetByPriceRange(minRange);
            if (hotels != null)
                return Created("Hotels List", hotels);
            return BadRequest("Oops!No Hotels Available In This Price Range Currently");
        }

        [HttpGet("GET AVAILABLE ROOMS ")]
        public ActionResult<int> FetchCount(string hotelName)
        {
            var hotelCount = _service.GetCount(hotelName);
            if (hotelCount != 0)
                return Created("Available Rooms", hotelCount);
            return BadRequest("Oops!No Rooms Available Currently");
        }
    }
}
