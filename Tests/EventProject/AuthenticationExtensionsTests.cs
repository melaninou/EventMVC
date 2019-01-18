using System;
using Microsoft.AspNetCore.Authentication;

namespace Tests.EventProject
{
    public static class AuthenticationExtensionsTests
    {

        public static AuthenticationBuilder AddTestAuth(this AuthenticationBuilder builder,
            Action<AuthenticationOptionsTest> configureOptions)
        {
            return builder.AddScheme<AuthenticationOptionsTest, AuthenticationHandlerTests>(
                "Test Scheme", "Test Auth", configureOptions);
        }
    }
}
