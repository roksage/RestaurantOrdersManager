using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RestaurantOrdersManager.Core.Services.ReservationSystemService
{
    public class ReservationTimeHosterServices : IHostedService, IDisposable
    {
        private int executionCount;
        private readonly ILogger<ReservationTimeHosterServices> _logger;
        private Timer? _timer = null;

        public ReservationTimeHosterServices(ILogger<ReservationTimeHosterServices> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("task started");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }
        private void DoWork(object? state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation(
                "Timed Hosted Service is working. Count: {Count}", count);
        }
        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
