using RestaurantOrdersManager.Core.Entities.RestaurantOrders;
using RestaurantOrdersManager.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace RestaurantOrdersManager.Core.Entities.ReservationSystem
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ReservationInfo { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ReservationEnums ReservationStatus { get; set; }
        public int TableId { get; set; }
        public int PeopleCount {  get; set; } 
        public Table Table { get; set; }
        public string Email {  get; set; } 
        public DateTime TimeCreated { get; set; }
        public string VerificationCode { get; set; }

        public Reservation()
        {
            ReservationStatus = ReservationEnums.Pending;
            TimeCreated = DateTime.UtcNow;
        }
    }
}
