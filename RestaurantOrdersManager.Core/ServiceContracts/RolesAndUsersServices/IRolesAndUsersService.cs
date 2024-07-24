using RestaurantOrdersManager.Core.Entities.RolesAndUsers;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUserDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersDTO;

namespace RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersServices
{
    public interface IRolesAndUsersService
    {
        Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
        Task<User?> GetById(int id);

    }
}
