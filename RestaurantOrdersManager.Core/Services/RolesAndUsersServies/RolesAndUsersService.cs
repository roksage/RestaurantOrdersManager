using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantOrdersManager.Core.DatabaseDbContext;
using RestaurantOrdersManager.Core.Entities.RolesAndUsers;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUserDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantOrdersManager.Core.Services.RolesAndUsersServies
{
    public class RolesAndUsersService: IRolesAndUsersService
    {
        private readonly AppSettings _appSettings;
        private readonly RolesAndUsersDbContext _dbContext;


        public RolesAndUsersService(IOptions<AppSettings> appSettings, RolesAndUsersDbContext dbContext)
        {
            _appSettings = appSettings.Value;
            _dbContext = dbContext;
        }

        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }



        public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
        {
            User? user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = await generateJwtToken(user);

            return user.ToAuthenticateResponse(token);

        }

        private async Task<string> generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }

    }

}
