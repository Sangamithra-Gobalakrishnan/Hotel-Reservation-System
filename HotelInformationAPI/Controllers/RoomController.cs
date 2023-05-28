using HotelInformationAPI.Interface;
using HotelInformationAPI.Models;
using HotelInformationAPI.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelInformationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "staff")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService<Room, RoomDTO> _roomService;

        public RoomController(IRoomService<Room,RoomDTO> roomService)
        {
             _roomService = roomService;
        }
        
        [HttpPost("ADD ROOM INFORMATION")]
        public ActionResult<Room> Add(Room room)
        {
            var roomAddResult = _roomService.Add(room);
            if (roomAddResult != null)
                return Created("Room Information Successfully Added!", roomAddResult);
            return BadRequest(roomAddResult);
        }

        [HttpDelete("DELETE A ROOM INFORMATION")]
        public ActionResult<RoomDTO> DeleteProject(RoomDTO roomDTO)
        {
            var roomDeleteResult = _roomService.Delete(roomDTO);
            if (roomDeleteResult != null)
                return Created("Hotel Information Successfully Deleted!", roomDeleteResult);
            return BadRequest(roomDeleteResult);
        }
    }
}
