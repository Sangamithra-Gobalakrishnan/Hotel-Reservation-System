using HotelInformationAPI.Interface;
using HotelInformationAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "staff")]
    public class HotelController : ControllerBase
    {
        private readonly IService<Hotel, int> _service;

        public HotelController(IService<Hotel,int> service)
        { 
            _service = service;
        }

        [HttpPost("ADD HOTEL INFORMATION")]
        public ActionResult<Hotel> Add(Hotel hotel)
        {
            var hotelAddResult = _service.Add(hotel);
            if (hotelAddResult != null)
                    return Created("Hotel Information Successfully Added!", hotelAddResult);
            return BadRequest(hotelAddResult);
        }

        [HttpPut("UPDATE HOTEL INFORMATION")]
        public ActionResult<Hotel> Update(Hotel hotel)
        {
            var hotelUpdateResult = _service.Update(hotel);
            if (hotelUpdateResult != null)
                return Created("Hotel Information Successfully Updated!", hotelUpdateResult);
            return BadRequest(hotelUpdateResult);

        }

        [HttpDelete("DELETE A HOTEL INFORMATION")]
        public ActionResult<Hotel> DeleteProject(int HotelID)
        {
            var hotelDeleteResult = _service.Delete(HotelID);
            if (hotelDeleteResult != null)
               return Created("Hotel Information Successfully Deleted!",hotelDeleteResult);
            return BadRequest(hotelDeleteResult);
        }
    }
}
