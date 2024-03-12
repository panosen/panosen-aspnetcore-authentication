using Panosen.AspNetCore.Authentication.Header;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
    /// <summary>
    /// 默认验证器
    /// </summary>
    public class SampleHeaderAuthenticationService : IHeaderAuthenticationService
    {
        /// <summary>
        /// <see cref="IAuthenticationService.AuthenticateAsync(string)"/>
        /// </summary>
        public Task<HeaderAuthenticateResult> AuthenticateAsync(string headerValue)
        {
            var success = !string.IsNullOrEmpty(headerValue);
            if (!success)
            {
                return Task.FromResult(HeaderAuthenticateResult.Fail);
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, headerValue) };

            return Task.FromResult(HeaderAuthenticateResult.Ok(claims));
        }
    }
}
