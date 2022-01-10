using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Bookstore.API.Configurations.Security
{
    internal class InMemoryBasicAuthHandler : AuthenticationHandler<InMemoryBasicAuthSchemeOptions>
    {
        private readonly List<InMemoryBasicAuthOptions> _inMemoryBasicAuthOptions;

        public InMemoryBasicAuthHandler(
            IOptionsMonitor<InMemoryBasicAuthSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IOptions<List<InMemoryBasicAuthOptions>> inMemoryBasicAuthOptions
        ) : base(options, logger, encoder, clock)
        {
            _inMemoryBasicAuthOptions = inMemoryBasicAuthOptions.Value;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            if (string.IsNullOrEmpty(authHeader))
                return Task.FromResult(AuthenticateResult.Fail("No Authorization Header"));

            var token = authHeader.Replace("Basic ", "");
            var basicAuth = FindBasicAuthInMemory(token);
            if (basicAuth == null)
                return Task.FromResult(AuthenticateResult.Fail("Invalid Token"));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, basicAuth.Username),
                new Claim(ClaimTypes.Role, basicAuth.Role),
            };

            var identity = new ClaimsIdentity(claims, Scheme.Name);

            var claimsPrincipal = new ClaimsPrincipal(identity);

            var ticket = new AuthenticationTicket(claimsPrincipal, Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }

        private InMemoryBasicAuthOptions FindBasicAuthInMemory(string token)
        {
            return _inMemoryBasicAuthOptions
                .Where(x => token.Equals(Convert.ToBase64String(Encoding.ASCII.GetBytes($"{x.Username}:{x.Password}"))))
                .FirstOrDefault();
        }
    }
}
