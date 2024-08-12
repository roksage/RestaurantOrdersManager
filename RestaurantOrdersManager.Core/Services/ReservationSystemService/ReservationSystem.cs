using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemServices;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;
using System.Linq;

namespace RestaurantOrdersManager.Core.Services.ReservationSystemService
{
    public class ReservationSystem : IReservationSystem
    {
        private readonly RestaurantOrdersDbContext _dbContext;
        private readonly ITableService _tableService;



        public ReservationSystem(RestaurantOrdersDbContext dbContext, ITableService tableService)
        {
            _dbContext = dbContext;
            _tableService = tableService;
        }

        public static DateTime RoundUpTime(DateTime dateTime, bool roundUp)
        {
            int quarterHour = 15;
            int minutes = dateTime.Minute;
            int roundedMinutes;

            if (roundUp)
            {
                roundedMinutes = (minutes / quarterHour) * quarterHour;
            }
            else
            {
                roundedMinutes = ((minutes / quarterHour) + 1) * quarterHour;
                if (roundedMinutes == 60)
                {
                    roundedMinutes = 0;
                    dateTime = dateTime.AddHours(1);
                }
            }

            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, roundedMinutes, 0);
        }


        public async Task<ReservationResponse> CreateReservation(ReservationCreateRequest request)
        {
            if (request == null) throw new ArgumentNullException("please check request body");

            //get all tables
            IEnumerable<TableResponse> tables = await _tableService.GetAllTables();


            //filter table that have enough seats 
            IEnumerable<TableResponse> tablesWithEnoughSeats = tables.Where(seats => seats.Seats >= request.PeopleCount).OrderBy(s => s.Seats);

            //find table that is not reserved or occupied at specific time
            foreach (TableResponse table in tablesWithEnoughSeats)
            {
                IEnumerable<(DateTime start, DateTime end)> emptySlotForSpecificTableAndDate = await GetFreeTimeSlotsByTable(table.TableId, request.StartTime);

                //round up start time to 15minutes interval
                DateTime RoundedStartTime = RoundUpTime(request.StartTime, true);

                //round up end time to 15minutes interval
                DateTime RoundedEndTime = RoundUpTime(request.EndTime, false);

                var allSlotsInReservationTime = new List<(DateTime start, DateTime end)>();
                // Generate all possible 15-minute slots within the start and end times
                for (var slotStart = RoundedStartTime; slotStart < RoundedEndTime; slotStart = slotStart.AddMinutes(15))
                {
                    var slotEnd = slotStart.AddMinutes(15);
                    allSlotsInReservationTime.Add((slotStart, slotEnd));
                }



                var checkIfok = allSlotsInReservationTime.All(x => emptySlotForSpecificTableAndDate.Any(y => y == x));

                await Console.Out.WriteLineAsync(RoundedStartTime.ToString());
                await Console.Out.WriteLineAsync(RoundedEndTime.ToString());
                //if (checkIfok)
                //{

                //}
            }


            return new ReservationResponse { };
            //set table as reserved

        }

        public async Task<IEnumerable<(DateTime start, DateTime end)>> GetFreeTimeSlotsByTable(int TableId, DateTime date)
        {
            var workingHoursStart = new TimeSpan(9, 0, 0);
            var workingHoursEnd = new TimeSpan(17, 0, 0);

            //set date to 12:00AM
            DateTime dateTime = date.Date.Add(new TimeSpan(0, 0, 0));

            //set to working hours
            var startOfWorkDay = dateTime.Add(workingHoursStart);
            var endOfWorkDay = dateTime.Add(workingHoursEnd);

            // First, retrieve all reservations for the day and store them in a list
            var reservations = await _dbContext.Reservations
                .Where(r => r.StartTime.Date == dateTime && r.TableId == TableId)
                .OrderBy(r => r.StartTime)
                .ToListAsync();  // Execute query and store result in a list

            var allSlots = new List<(DateTime start, DateTime end)>();

            // Generate all possible 15-minute slots within the working hours
            for (var slotStart = startOfWorkDay; slotStart < endOfWorkDay; slotStart = slotStart.AddMinutes(15))
            {
                var slotEnd = slotStart.AddMinutes(15);
                allSlots.Add((slotStart, slotEnd));
            }

            // Filter out the slots that overlap with any existing reservation
            var freeSlots = allSlots.Where(slot =>
                !reservations.Any(reservation =>
                    slot.start < reservation.EndTime && reservation.StartTime < slot.end))
                .ToList();

            return freeSlots;
        }
    }
}
