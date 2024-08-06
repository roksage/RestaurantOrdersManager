using Microsoft.AspNetCore.Mvc;
using RestaurantOrdersManager.Core.Entities.RolesAndUsers;
using RestaurantOrdersManager.Core.Helpers.AuthenticationAuthorization.AuthorizeAttribute;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUserDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersServices;

namespace RestaurantOrdersManager.WebAPI.Controllers.RolesAndUsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthorizationService _rolesAndUsersService;

        public UsersController(IAuthorizationService rolesAndUsersService)
        {
            _rolesAndUsersService = rolesAndUsersService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> login(AuthenticateRequest model)
        {
            var response = await _rolesAndUsersService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
