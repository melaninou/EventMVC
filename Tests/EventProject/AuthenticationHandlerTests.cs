using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Tests.EventProject
{
    public class AuthenticationHandlerTests : AuthenticationHandler<AuthenticationOptionsTest>
    {

        public static bool IsLoggedIn;

        public AuthenticationHandlerTests(IOptionsMonitor<AuthenticationOptionsTest> options,
            ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock) { }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var authenticationTicket = new AuthenticationTicket(
                new ClaimsPrincipal(Options.Identity),
                new AuthenticationProperties(),
                "Test Scheme");
            var r = IsLoggedIn
                ? Task.FromResult(AuthenticateResult.Success(authenticationTicket))
                : Task.FromResult(AuthenticateResult.NoResult());
            IsLoggedIn = false;
            return r;
        }

    }
}
