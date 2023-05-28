using HotelInformationAPI.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoomReservationAPI.Interfaces;
using RoomReservationAPI.Models;
using RoomReservationAPI.Models.DTO;

namespace RoomReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "user")]
    public class ReservationController : ControllerBase
    {
        private readonly IReserveService<Reservation, ReservationDTO> _service;

        public ReservationController(IReserveService<Reservation,ReservationDTO> service)
        {
            _service = service;
        }

        [HttpPost("MAKE A RESERVATION")]
        public ActionResult<Reservation> Book(Reservation reservation)
        {
            var roomReserveResult = _service.Book(reservation);
            if (roomReserveResult != null)
                return Created("Reservation Successfull!", roomReserveResult);
            return BadRequest(roomReserveResult);
        }

        [HttpDelete("CANCEL A RESERVATION")]
        public ActionResult<ReservationDTO> Cancel(ReservationDTO reservationDTO)
        {
            var roomCancelResult = _service.Cancel(reservationDTO);
            if (roomCancelResult != null)
                return Created("Cancellation Successfull!", roomCancelResult);
            return BadRequest(roomCancelResult);
        }
    }
}
