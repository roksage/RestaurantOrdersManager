using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;

namespace RestaurantOrdersManager.API.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;


        public RequestLogMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<RequestLogMiddleware>();
        }

        public (string id, string role, string ErrorMessage) GetUserIDByJwt(string token)
        {
            try
            {
                var var = new JwtSecurityToken(token);
                string id = var.Claims.FirstOrDefault(x => x.Type == "id").ToString();
                string role = var.Claims.FirstOrDefault(x => x.Type == "role").ToString();
                return (id, role, null);
            }

            catch (Exception ex)
            {
                _logger.LogError($"ERROR VALIDATING JWT TOKEN: {ex.Message}");
                return (null, null, ex.Message);
            }
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                string jwtToken = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();
                if (string.IsNullOrEmpty(jwtToken))
                {
                    _logger.LogInformation($"Missing JWT token - Method: {context.Request.Method}, Endpoint: {context.Request.Path}, IPaddress: {context.Connection.RemoteIpAddress}");
                }
                else
                {
                    var userInfo = GetUserIDByJwt(jwtToken);
                    if (userInfo.ErrorMessage == null)
                    {

                        _logger.LogInformation($"User ID: {userInfo.id}, Role: {userInfo.role} - Method: {context.Request.Method}, Endpoint: {context.Request.Path}, , IPaddress: {context.Connection.RemoteIpAddress}");
                    }
                    else
                    {
                        _logger.LogWarning(userInfo.ErrorMessage);
                    }
                }

                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"exception in middlaware: {ex.Message}");
                throw new Exception(ex.Message);
            }
        }
    }
}
