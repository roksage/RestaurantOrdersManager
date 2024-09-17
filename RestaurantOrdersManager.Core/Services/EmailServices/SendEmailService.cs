using RestaurantOrdersManager.Core.ServiceContracts.EmailDTO;
using RestaurantOrdersManager.Core.ServiceContracts.EmailServices;

namespace RestaurantOrdersManager.Core.Services.EmailServices
{
    public class SendEmailService : ISendEmailService
    {

        private readonly ISendEmailService _emailService;

        public SendEmailService(ISendEmailService emailService)
        {
            _emailService = emailService;
        }
        public Task<bool> SendEmailAsync(EmailSendRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
