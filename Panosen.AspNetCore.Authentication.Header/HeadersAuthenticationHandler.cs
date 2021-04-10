using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Panosen.AspNetCore.Authentication.Header
{
    /// <summary>
    /// HeaderAuthenticationHandler
    /// </summary>
    public class HeaderAuthenticationHandler : AuthenticationHandler<HeaderAuthenticationOptions>
    {
        /// <summary>
        /// HeaderAuthenticationHandler
        /// </summary>
        public HeaderAuthenticationHandler(IOptionsMonitor<HeaderAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// <see cref="AuthenticationHandler{TOptions}.AuthenticationHandler(IOptionsMonitor{TOptions}, ILoggerFactory, UrlEncoder, ISystemClock)"/>
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            IHeaderAuthenticationService authenticationService = this.Context.RequestServices.GetService(typeof(IHeaderAuthenticationService)) as IHeaderAuthenticationService;
            if (authenticationService == null)
            {
                Logger.LogInformation($"{nameof(IHeaderAuthenticationService)} is not configured.");
                return AuthenticateResult.Fail($"{nameof(IHeaderAuthenticationService)} is not configured.");
            }

            var headerValue = Request.Headers[Options.HeaderKey];
            if (headerValue.Equals(StringValues.Empty))
            {
                return AuthenticateResult.Fail($"{Options.HeaderKey} is null or empty.");
            }

            var valid = await authenticationService.AuthenticateAsync(headerValue);
            if (!valid)
            {
                Logger.LogWarning("token valid failed.");
                return AuthenticateResult.Fail($"{Options.HeaderKey} is invalid.");
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, headerValue) };

            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, HeaderAuthenticationDefaults.AuthenticationScheme));

            return AuthenticateResult.Success(new AuthenticationTicket(principal, HeaderAuthenticationDefaults.AuthenticationScheme));
        }
    }
}
