using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

using Microsoft.Net.Http.Headers;
using System.Text;

namespace Panosen.AspNetCore.Authentication.Basic
{
    /// <summary>
    /// BasicAuthenticationHandler
    /// </summary>
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        /// <summary>
        /// BasicAuthenticationHandler
        /// </summary>
        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
        }

        /// <summary>
        /// HandleAuthenticateAsync
        /// </summary>
        /// <returns></returns>
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            IBasicAuthenticationService basicAuthenticationService = this.Context.RequestServices.GetService(typeof(IBasicAuthenticationService)) as IBasicAuthenticationService;
            if (basicAuthenticationService == null)
            {
                Logger.LogInformation($"{nameof(IBasicAuthenticationService)} is not configured.");
                return AuthenticateResult.Fail($"{nameof(IBasicAuthenticationService)} is not configured.");
            }

            string authorization = Request.Headers[HeaderNames.Authorization];
            if (string.IsNullOrEmpty(authorization))
            {
                Logger.LogInformation("Authorzation is null or empty.");
                Response.Headers.Add(HeaderNames.WWWAuthenticate, "Basic realm=\"PanosenBasicAuthentication\"");
                return AuthenticateResult.NoResult();
            }

            if (!authorization.StartsWith(BasicAuthenticationDefaults.AuthenticationScheme + " ", StringComparison.CurrentCultureIgnoreCase))
            {
                Logger.LogInformation("Authorzation is invalid.");
                Response.Headers.Add(HeaderNames.WWWAuthenticate, "Basic realm=\"PanosenBasicAuthentication\"");
                return AuthenticateResult.NoResult();
            }

            var token = authorization.Substring(BasicAuthenticationDefaults.AuthenticationScheme.Length).Trim();
            if (string.IsNullOrEmpty(token))
            {
                Logger.LogInformation("Authorzation is invalid.");
                return AuthenticateResult.NoResult();
            }

            try
            {
                var content = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                if (string.IsNullOrEmpty(content))
                {
                    Logger.LogInformation("token " + token + "failed: token empty error.");
                    return AuthenticateResult.Fail("token empty error.");
                }

                var array = content.Split(':');
                if (array.Length != 2)
                {
                    Logger.LogInformation("token " + token + "failed: token format error.");
                    return AuthenticateResult.Fail("token format error.");
                }

                var valid = await basicAuthenticationService.ValidateAsync(array[0], array[1]);
                if (!valid)
                {
                    Logger.LogWarning("token valid failed.");
                    return AuthenticateResult.Fail("token valida failed.");
                }

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, array[1]) };

                var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, BasicAuthenticationDefaults.AuthenticationScheme));

                return AuthenticateResult.Success(new AuthenticationTicket(principal, BasicAuthenticationDefaults.AuthenticationScheme));
            }
            catch (Exception ex)
            {
                Logger.LogWarning("token " + token + "failed: " + ex.Message);
                return AuthenticateResult.Fail(ex.Message);
            }
        }
    }
}
