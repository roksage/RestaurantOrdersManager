using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace RestaurantOrdersManager.Core.Helpers
{
    public class RequestLogger
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public RequestLogger(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLogger>();
        }

        public (string id, string role) GetUserIDByJwt(string token)
        {
            var var = new JwtSecurityToken(token);
            string id = var.Claims.FirstOrDefault(x => x.Type == "id").ToString();
            string role = var.Claims.FirstOrDefault(x => x.Type == "role").ToString();
            return (id, role);
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var userInfo = GetUserIDByJwt(context.Request.Headers.Authorization.FirstOrDefault().Split(" ").Last());
                _logger.LogInformation(userInfo.id + " " + userInfo.role + " method: " + context.Request.Method + " endpoint: " + context.Request.Path);
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
