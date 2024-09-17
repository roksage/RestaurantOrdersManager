using RestaurantOrdersManager.Core.ServiceContracts.EmailDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.ServiceContracts.EmailServices
{
    public interface ISendEmailService
    {
        Task<bool> SendEmailAsync(EmailSendRequest request);
    }
}
