using RestaurantOrdersManager.Core.Entities.RolesAndUsers;

namespace RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersDTO
{
    public class AuthenticateResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // Add this property
        public string Token { get; set; }


    }
    public static class AuthenticateResponseExtension
    {


        public static AuthenticateResponse ToAuthenticateResponse(this User request, string Token)
        {
            return new AuthenticateResponse
            {
                UserId = request.Id,
                Username = request.Username,
                Password = request.Password,
                Role = request.Role,
                Token = Token
            };
        }

    }
}
