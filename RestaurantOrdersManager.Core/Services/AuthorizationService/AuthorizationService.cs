using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantOrdersManager.Core.DatabaseDbContext;
using RestaurantOrdersManager.Core.Entities.RolesAndUsers;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUserDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersDTO;
using RestaurantOrdersManager.Core.ServiceContracts.RolesAndUsersServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RestaurantOrdersManager.Core.Services.RolesAndUsersServies
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IConfiguration _configuration;
        private readonly AuthorizationDbContext _dbContext;

        public AuthorizationService(IConfiguration configuration, AuthorizationDbContext dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        //public bool IsAuthenticated(string email, string password)
        //{
        //    var user = this.GetByEmail(email);
        //    return this.DoesUserExists(email) && BC.Verify(password, user.Password);
        //}

        //public bool DoesUserExists(string email)
        //{
        //    var user = this.dataContext.Users.FirstOrDefault(x => x.Email == email);
        //    return user != null;
        //}

        //public User GetById(string id)
        //{
        //    return this.dataContext.Users.FirstOrDefault(c => c.UserId == id);
        //}

        //public User[] GetAll()
        //{
        //    return this.dataContext.Users.ToArray();
        //}

        //public User GetByEmail(string email)
        //{
        //    return this.dataContext.Users.FirstOrDefault(c => c.Email == email);
        //}

        //public User RegisterUser(User model)
        //{
        //    var id = IdGenerator.CreateLetterId(10);
        //    var existWithId = this.GetById(id);
        //    while (existWithId != null)
        //    {
        //        id = IdGenerator.CreateLetterId(10);
        //        existWithId = this.GetById(id);
        //    }
        //    model.UserId = id;
        //    model.Password = BC.HashPassword(model.Password);

        //    var userEntity = this.dataContext.Users.Add(model);
        //    this.dataContext.SaveChanges();

        //    return userEntity.Entity;
        //}



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
            var token = await Authenticate(user);

            return user.ToAuthenticateResponse(token);

        }
        public async Task<string> Authenticate(User user)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                        new Claim("id", user.Id.ToString()),
                        new Claim(ClaimTypes.Role, user.Role)
                        }),
                Expires = DateTime.UtcNow.AddDays(5),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        //public string DecodeEmailFromToken(string token)
        //{
        //    var decodedToken = new JwtSecurityTokenHandler();
        //    var indexOfTokenValue = 7;

        //    var t = decodedToken.ReadJwtToken(token.Substring(indexOfTokenValue));

        //    return t.Payload.FirstOrDefault(x => x.Key == "email").Value.ToString();
        //}

        //public User ChangeRole(string email, string role)
        //{
        //    var user = this.GetByEmail(email);
        //    user.Role = role;
        //    this.dataContext.SaveChanges();


        //    return user;
        //}
    }
}
