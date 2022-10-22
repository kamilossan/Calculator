using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Primitives;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Unicode;

namespace Calculator.Services
{
    public interface IBasicAuthorizationService
    {
        public bool IsAuthorized(HttpRequest request);
    }
    public class BasicAuthorizationService : IBasicAuthorizationService
    {
        private readonly IConfiguration _configuration;

        public BasicAuthorizationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool IsAuthorized(HttpRequest request)
        {
            var authHeader = request.Headers["Authorization"];
            if (authHeader == StringValues.Empty) return false;
            var user = AuthenticateUser(AuthenticationHeaderValue.Parse(authHeader));
            return user != null;
        }
        private string? AuthenticateUser(AuthenticationHeaderValue authHeader)
        {
            if(authHeader.Scheme.ToLower() == "basic" && authHeader.Parameter != null)
            {
                string[] credentials = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader.Parameter)).Split(':');
                if (credentials[0].ToLower() == _configuration["username"].ToLower() && credentials[1] == _configuration["password"]) return credentials[0];
            }
            return null;
        }
    }
}
