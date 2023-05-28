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

        [HttpPost("Add Hotel Information")]
        [ProducesResponseType(typeof(Hotel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        public ActionResult<Hotel> Add(Hotel hotel)
        {
            var hotelAddResult = _service.Add(hotel);
            if (hotelAddResult != null)
                return Ok("Hotel Information Successfully Added!");
            return BadRequest("Information Could Not Be Added!");
        }

        [HttpPut("Update Hotel Information")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Hotel> Update(Hotel hotel)
        {
            var hotelUpdateResult = _service.Update(hotel);
            if (hotelUpdateResult != null)
                return Ok("Hotel Information Successfully Updated!");
            return BadRequest("Information Could Not Be Updated!");

        }

        [HttpDelete("Delete Hotel Information")]
        [ProducesResponseType(typeof(Hotel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Hotel> Delete(int HotelID)
        {
            var hotelDeleteResult = _service.Delete(HotelID);
            if (hotelDeleteResult != null)
               return Ok("Hotel Information Successfully Deleted!");
            return BadRequest("Information Could Not Be Deleted");
        }
    }
}
