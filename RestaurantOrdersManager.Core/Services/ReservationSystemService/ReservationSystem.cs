using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemServices;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;
using System.Collections.Generic;

namespace RestaurantOrdersManager.Core.Services.ReservationSystemService
{
    public class ReservationSystem : IReservationSystem
    {
        private readonly RestaurantOrdersDbContext _dbContext;
        private readonly ITableService _tableService;
        private List<(int tableId, List<(DateTime start, DateTime end)>)> freeTimeSlotsByTable;

        public ReservationSystem(RestaurantOrdersDbContext dbContext, ITableService tableService)
        {
            _dbContext = dbContext;
            _tableService = tableService;
        }

        public static List<(DateTime, DateTime)> Generate15minuteSlots(DateTime startTime, DateTime endTime)
        {
            List<(DateTime, DateTime)> slotsList = new List<(DateTime, DateTime)>();

            for (var slotStart = startTime; slotStart < endTime; slotStart = slotStart.AddMinutes(15))
            {
                var slotEnd = slotStart.AddMinutes(15);
                slotsList.Add((slotStart, slotEnd));
            }

            return slotsList;
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

                // Generate all possible 15-minute slots within the start and end times

                var allSlotsInReservationTime = Generate15minuteSlots(RoundedStartTime, RoundedEndTime);


                var checkIfok = allSlotsInReservationTime.All(x => emptySlotForSpecificTableAndDate.Any(y => y == x));

                if (checkIfok)
                {
                    Reservation reservation = request.ToReservation();
                    reservation.StartTime = RoundedStartTime;
                    reservation.EndTime = RoundedEndTime;
                    reservation.TableId = table.TableId;
                    await _dbContext.AddAsync(reservation);
                    await _dbContext.SaveChangesAsync();
                    return reservation.ToReservationResponse();
                }
            }


            return null;
            //set table as reserved

        }

        public async Task<IEnumerable<(int tableId, IEnumerable<(DateTime start, DateTime end)>)>> GetFreeTimeSlotsAllTables(DateTime searchDate)
        {
            //
            var freeTimeSlotsByTable = new List<(int tableId, IEnumerable<(DateTime start, DateTime end)>)>();           
            //set date to 12:00AM
            DateTime dateTime = searchDate.Date.Add(new TimeSpan(0, 0, 0));

            //set to working hours
            var startOfWorkDay = dateTime.Add(new TimeSpan(9, 0, 0));
            var endOfWorkDay = dateTime.Add(new TimeSpan(17, 0, 0));


            IEnumerable<TableResponse> allTables = await _tableService.GetAllTables();

            foreach (var table in allTables)
            {

                // First, retrieve all reservations for the day and store them in a list
                var reservations = await _dbContext.Reservations
                    .AsNoTracking()
                    .Where(r => r.StartTime.Date == dateTime && r.TableId == table.TableId)
                    .OrderBy(r => r.StartTime)
                    .ToListAsync();

                //get 15minute slots of working hours
                List<(DateTime start, DateTime end)> allSlots = Generate15minuteSlots(startOfWorkDay, endOfWorkDay);


                // Filter out the slots that overlap with any existing reservation
                var freeSlots = allSlots.Where(slot =>
                    !reservations.Any(reservation =>
                        slot.start < reservation.EndTime && reservation.StartTime < slot.end))
                    .ToList();

                freeTimeSlotsByTable.Add((table.TableId, freeSlots));
            }

            return freeTimeSlotsByTable;
        }

        public async Task<IEnumerable<(DateTime start, DateTime end)>> GetFreeTimeSlotsByTable(int TableId, DateTime searchDate)
        {

            //set date to 12:00AM
            DateTime dateTime = searchDate.Date.Add(new TimeSpan(0, 0, 0));

            //set to working hours
            var startOfWorkDay = dateTime.Add(new TimeSpan(9, 0, 0));
            var endOfWorkDay = dateTime.Add(new TimeSpan(17, 0, 0));



            // First, retrieve all reservations for the day and store them in a list
            var reservations = await _dbContext.Reservations
                .Where(r => r.StartTime.Date == dateTime && r.TableId == TableId)
                .OrderBy(r => r.StartTime)
                .ToListAsync();

            //get 15minute slots of working hours
            List<(DateTime start, DateTime end)> allSlots = Generate15minuteSlots(startOfWorkDay, endOfWorkDay);


            // Filter out the slots that overlap with any existing reservation
            var freeSlots = allSlots.Where(slot =>
                !reservations.Any(reservation =>
                    slot.start < reservation.EndTime && reservation.StartTime < slot.end))
                .ToList();

            return freeSlots;
        }
    }
}
