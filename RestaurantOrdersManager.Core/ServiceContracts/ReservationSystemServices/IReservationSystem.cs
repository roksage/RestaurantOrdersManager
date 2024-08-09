using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemServices
{
    public interface IReservationSystem
    {
        Task<ReservationResponse> CreateReservation(ReservationCreateRequest request);
        Task<IEnumerable<(DateTime start, DateTime end)>> GetFreeTimeSlotsByTable(int TableId, DateTime date);
    }
}
