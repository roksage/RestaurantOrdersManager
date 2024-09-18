using Microsoft.Extensions.Logging;
using RestaurantOrdersManager.Core.ServiceContracts.EmailDTO;
using RestaurantOrdersManager.Core.ServiceContracts.EmailServices;
using RestaurantOrdersManager.Core.Services.BackGroundJobs.ReservationJobs;

namespace RestaurantOrdersManager.Core.Services.EmailServices
{
    public class SendEmailService : ISendEmailService
    {
        private readonly ILogger<SendEmailService> _logger;

        public SendEmailService(ILogger<SendEmailService> logger)
        {
            _logger = logger;
        }
        public async Task<bool> SendEmailAsync(EmailSendRequest request)
        {
            _logger.LogCritical($"email with body - {request.EmailBody}, subject - {request.EmailSubject}, email - {request.EmailToName}");

            _logger.LogCritical("Need to implement email sending itself");

            return true;
        }
    }
}
