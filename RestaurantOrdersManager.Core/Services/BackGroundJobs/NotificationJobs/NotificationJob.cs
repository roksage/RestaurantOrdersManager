using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using RestaurantOrdersManager.Core.Services.BackGroundJobs.ReservationJobs;
using RestaurantOrdersManager.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Services.BackGroundJobs.NotificationJobs
{
    public class NotificationJob : IJob
    {
        private readonly ILogger<ReservationSystemJob> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public NotificationJob(ILogger<ReservationSystemJob> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async Task Execute(IJobExecutionContext context)
        {

            _logger.LogInformation("NotificationJob running");

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<RestaurantOrdersDbContext>();

                List<Reservation> reservation = await _dbContext.Reservations.Where(r => r.ReservationStatus == Enums.ReservationEnums.Reserved &&
                                                                                         r.IsReservationNotificationSent == false &&
                                                                                         r.StartTime.Day == DateTime.Now.Day)
                                                                                         .ToListAsync();

                foreach (Reservation obj in reservation)
                {
                    if (obj != null)
                    {
                        obj.IsReservationNotificationSent = true;
                        _logger.LogInformation($"notification for reservation with ID {obj.ReservationId} has been sent");
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
