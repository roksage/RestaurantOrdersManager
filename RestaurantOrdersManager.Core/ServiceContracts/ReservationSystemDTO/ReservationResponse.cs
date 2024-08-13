using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using RestaurantOrdersManager.Core.Enums;

namespace RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO
{
    public class ReservationResponse
    {
        public int ReservationId { get; set; }
        public string ReservationInfo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PeopleCount { get; set; }

        public int TableId { get; set; }
        public ReservationEnums ReservationStatus { get; set; }
    }
    public static class ReservationResponseExtension
    {
        public static ReservationResponse ToReservationResponse(this Reservation request)
        {
            return new ReservationResponse
            {
                ReservationId = request.ReservationId,
                ReservationInfo = request.ReservationInfo,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                ReservationStatus = request.ReservationStatus,
                PeopleCount = request.PeopleCount,
                TableId = request.TableId
            };
        }
    }
}
