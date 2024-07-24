namespace RestaurantOrdersManager.Core.ServiceContracts.RolesAndUserDTO
{
    public class AuthenticateRequest
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}
