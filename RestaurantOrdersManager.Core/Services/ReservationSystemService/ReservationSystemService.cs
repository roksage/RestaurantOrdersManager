using Microsoft.EntityFrameworkCore;
using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using RestaurantOrdersManager.Core.ServiceContracts.DTO.TableDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemDTO;
using RestaurantOrdersManager.Core.ServiceContracts.ReservationSystemServices;
using RestaurantOrdersManager.Core.ServiceContracts.RestaurantOrdersServices;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Core.Services.ReservationSystemService
{
    public class ReservationSystemService : IReservationSystem
    {
        private readonly RestaurantOrdersDbContext _dbContext;
        private readonly ITableService _tableService;
        private readonly ReservationServiceHelper _reservationServiceHelper;

        //working hours, update would allow to update working hours from api
        private const int openingHours = 9;
        private const int closingHours = 17;

        public ReservationSystemService(RestaurantOrdersDbContext dbContext, ITableService tableService, ReservationServiceHelper reservationHelper)
        {
            _dbContext = dbContext;
            _tableService = tableService;
            _reservationServiceHelper = reservationHelper;
        }




        public async Task<ReservationResponse> CreateReservation(ReservationCreateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("please check request body");
            }
            //check if request is during working hours
            if (request.StartTime.Hour < openingHours || request.EndTime.Hour > closingHours)
            {
                throw new InvalidOperationException($"Working hours are {openingHours} - {closingHours}");
            }
            //get all tables
            IEnumerable<TableResponse> tables = await _tableService.GetAllTables();
            //filter table that have enough seats 
            IEnumerable<TableResponse> tablesWithEnoughSeats = tables.Where(seats => seats.Seats >= request.PeopleCount).OrderBy(s => s.Seats);



            //find table that is not reserved or occupied at specific time
            foreach (TableResponse table in tablesWithEnoughSeats)
            {
                IEnumerable<(DateTime start, DateTime end)> emptySlotForSpecificTableAndDate = await GetFreeTimeSlotsByTable(table.TableId, request.StartTime);

                //round up start time to 15minutes interval
                DateTime RoundedStartTime = _reservationServiceHelper.RoundUpTime(request.StartTime, true);

                //round up end time to 15minutes interval
                DateTime RoundedEndTime = _reservationServiceHelper.RoundUpTime(request.EndTime, false);

                // Generate all possible 15-minute slots within the start and end times

                var allSlotsInReservationTime = _reservationServiceHelper.Generate15minuteSlots(RoundedStartTime, RoundedEndTime);


                var checkIfok = allSlotsInReservationTime.All(x => emptySlotForSpecificTableAndDate.Any(y => y == x));

                if (checkIfok)
                {
                    Reservation reservation = request.ToReservation();
                    reservation.StartTime = RoundedStartTime;
                    reservation.EndTime = RoundedEndTime;
                    reservation.TableId = table.TableId;
                    //generate and attach varification code
                    reservation.VerificationCode = _reservationServiceHelper.GenerateVerificationCode();

                    //TODO implement email service to send verification to user


                    await _dbContext.AddAsync(reservation);
                    await _dbContext.SaveChangesAsync();

                    return reservation.ToReservationResponse();
                }
            }

            return null;
            //set table as reserved

        }

        public async Task<IEnumerable<(int tableId, IEnumerable<(DateTime start, DateTime end)>)>> GetFreeTimeSlotsAllTables(DateTime searchDate, int seats)
        {
            //
            var freeTimeSlotsByTable = new List<(int tableId, IEnumerable<(DateTime start, DateTime end)>)>();
            //set date to 12:00AM
            DateTime dateTime = searchDate.Date.Add(new TimeSpan(0, 0, 0));

            //set to working hours
            var startOfWorkDay = dateTime.Add(new TimeSpan(openingHours, 0, 0));
            var endOfWorkDay = dateTime.Add(new TimeSpan(closingHours, 0, 0));


            IEnumerable<TableResponse> allTables = await _tableService.GetAllTables();

            IEnumerable<TableResponse> tablesWithEnoughSeats = allTables.Where(s => s.Seats >= seats)
                                                                         .OrderBy(s => s.Seats);


            foreach (var table in tablesWithEnoughSeats)
            {

                // retrieve all reservations for the day and store them in a list
                var reservations = await _dbContext.Reservations
                    .AsNoTracking()
                    .Where(r => r.StartTime.Date == dateTime && r.TableId == table.TableId && r.ReservationStatus == Enums.ReservationEnums.Reserved)
                    .OrderBy(r => r.StartTime)
                    .ToListAsync();

                //get 15minute slots of working hours
                List<(DateTime start, DateTime end)> allSlots = _reservationServiceHelper.Generate15minuteSlots(startOfWorkDay, endOfWorkDay);


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
            var startOfWorkDay = dateTime.Add(new TimeSpan(openingHours, 0, 0));
            var endOfWorkDay = dateTime.Add(new TimeSpan(closingHours, 0, 0));



            //  retrieve all reservations for the day and store them in a list
            var reservations = await _dbContext.Reservations
                .Where(r => r.StartTime.Date == dateTime && r.TableId == TableId && r.ReservationStatus == Enums.ReservationEnums.Reserved)
                .OrderBy(r => r.StartTime)
                .ToListAsync();

            //get 15minute slots of working hours
            List<(DateTime start, DateTime end)> allSlots = _reservationServiceHelper.Generate15minuteSlots(startOfWorkDay, endOfWorkDay);


            // Filter out the slots that overlap with any existing reservation
            var freeSlots = allSlots.Where(slot =>
                !reservations.Any(reservation =>
                    slot.start < reservation.EndTime && reservation.StartTime < slot.end))
                .ToList();

            return freeSlots;
        }

        public async Task<ReservationResponse> ConfirmReservation(string verification)
        {
            if (verification == null)
            {
                throw new ArgumentNullException("Please provide verification code");
            }

            Reservation? reservation = await _dbContext.Reservations.FirstOrDefaultAsync(r => r.VerificationCode == verification);

            if (reservation == null)
            {
                throw new ArgumentNullException($"Verification code does not exist - {verification}");
            }
            if (reservation.ReservationStatus == Enums.ReservationEnums.Reserved ||
                reservation.ReservationStatus == Enums.ReservationEnums.Canceled)
            {
                throw new InvalidOperationException($"This reservation is already set to - '{reservation.ReservationStatus.ToString().ToLower()}'");
            }

            //set as reserved
            reservation.ReservationStatus = Enums.ReservationEnums.Reserved;
            await _dbContext.SaveChangesAsync();

            return reservation.ToReservationResponse();
        }
    }
}
