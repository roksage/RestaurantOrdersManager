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

            RunReservationChecker();

            using PeriodicTimer timer = new(TimeSpan.FromSeconds(30));

            try
            {
                while (await timer.WaitForNextTickAsync(stoppingToken))
                {
                    RunReservationChecker();
                }
            }
            catch (OperationCanceledException)
            {
                _logger.LogInformation("Timed Hosted Service is stopping.");
            }
        }

        private async void RunReservationChecker()
        {
            int count = Interlocked.Increment(ref _executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

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
}
