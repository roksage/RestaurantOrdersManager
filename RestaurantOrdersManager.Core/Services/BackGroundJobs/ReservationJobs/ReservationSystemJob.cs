using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Quartz;
using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Core.Services.BackGroundJobs.ReservationJobs;

public class ReservationSystemJob : IJob
{
    private readonly ILogger<ReservationSystemJob> _logger;
    private static int _executionCount;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public ReservationSystemJob(ILogger<ReservationSystemJob> logger, IServiceScopeFactory serviceScopeFactory)
    {
        _logger = logger;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task Execute(IJobExecutionContext context)
    {
        int count = Interlocked.Increment(ref _executionCount);

        _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", _executionCount);

        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var _dbContext = scope.ServiceProvider.GetRequiredService<RestaurantOrdersDbContext>();

            List<Reservation> reservation = await _dbContext.Reservations.Where(r => r.TimeCreated < DateTime.UtcNow.AddMinutes(-1) && r.ReservationStatus == Enums.ReservationEnums.Pending).ToListAsync();

            foreach (Reservation obj in reservation)
            {
                if (obj != null)
                {
                    obj.ReservationStatus = Enums.ReservationEnums.Canceled;
                    _logger.LogInformation($"reservation with ID {obj.ReservationId} set to {Enums.ReservationEnums.Canceled.ToString().ToUpper()}");
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}