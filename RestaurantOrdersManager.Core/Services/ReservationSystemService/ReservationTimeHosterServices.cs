using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RestaurantOrdersManager.Core.Entities.ReservationSystem;
using RestaurantOrdersManager.Infrastructure;

namespace RestaurantOrdersManager.Core.Services.ReservationSystemService
{

    public class ReservationTimedHostedService : BackgroundService
    {
        private readonly ILogger<ReservationTimedHostedService> _logger;
        private int _executionCount;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ReservationTimedHostedService(ILogger<ReservationTimedHostedService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Reservation checker running");

            // When the timer should have no due-time, then do the work once now.
            DoWork();

            using PeriodicTimer timer = new(TimeSpan.FromSeconds(30));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    DoWork();
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Timed Hosted Service is stopping.");
            }
        }

        // Could also be a async method, that can be awaited in ExecuteAsync above
        private async void DoWork()
        {
            int count = Interlocked.Increment(ref _executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _dbContext = scope.ServiceProvider.GetRequiredService<RestaurantOrdersDbContext>();



                Reservation reservation = await _dbContext.Reservations.FirstOrDefaultAsync(r => r.TimeCreated < DateTime.UtcNow.AddMinutes(-15) && r.ReservationStatus == Enums.ReservationEnums.Pending);
                if (reservation != null)
                {
                    reservation.ReservationStatus = Enums.ReservationEnums.Canceled;
                    _logger.LogInformation($"reservation with ID {reservation.ReservationId} set to {Enums.ReservationEnums.Canceled.ToString().ToUpper()}");
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
