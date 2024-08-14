using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemServices;

namespace RestaurantOrdersManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationSystem _reservationSystem;
        private readonly ILogger<ReservationController> _logger;

        public ReservationController(IReservationSystem reservationSystem, ILogger<ReservationController> logger)
        {
            _logger = logger;
            _reservationSystem = reservationSystem;
        }




        [HttpGet("confirmReservation/{verificationCode}")]
        public async Task<IActionResult> confirmReservation(string verificationCode)
        {
            try
            {
                ReservationResponse confirmReservation = await _reservationSystem.ConfirmReservation(verificationCode);
                return Ok(new ReservationResponse
                {
                    ReservationId = confirmReservation.ReservationId,
                    StartTime = confirmReservation.StartTime,
                    EndTime = confirmReservation.EndTime,
                    PeopleCount = confirmReservation.PeopleCount,
                    ReservationInfo = confirmReservation.ReservationInfo,
                    ReservationStatus = confirmReservation.ReservationStatus
                });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }

        }


        [HttpPost("reserveTable")]
        public async Task<IActionResult> reserveTable(ReservationCreateRequest request)
        {
            try
            {
                ReservationResponse reserve = await _reservationSystem.CreateReservation(request);
                if (reserve != null)
                {
                    return Ok(new { ReservationId = reserve.ReservationId });
                }
                else
                {
                    return Conflict(new { messsage = "Failed to reserve table" });
                }
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { Message = "An unexpected error occurred. Please try again later." });
            }
        }


        //needs update
        [HttpGet("GetFreeTimeSlotsAllTables")]
        public async Task<IActionResult> GetFreeTimeSlotsAllTables(DateTime date, int seats)
        {
            try
            {
                var timeSlots = await _reservationSystem.GetFreeTimeSlotsAllTables(date, seats);

                return Ok(timeSlots);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = ex.Message });
            }
        }

    }
}