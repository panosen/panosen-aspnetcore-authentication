using Panosen.AspNetCore.Authentication.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Sample
{
    /// <summary>
    /// 默认身份验证器
    /// </summary>
    public class SampleIBasicAuthenticationService : IBasicAuthenticationService
    {
        public Task<BasicAuthenticateResult> ValidateAsync(string userName, string password)
        {
            var success = "harriszhang".Equals(userName, StringComparison.CurrentCultureIgnoreCase) &&
              "abc123".Equals(password, StringComparison.CurrentCultureIgnoreCase);
            if (!success)
            {
                return Task.FromResult(BasicAuthenticateResult.Fail);
            }

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            return Task.FromResult(BasicAuthenticateResult.Ok(claims));
        }
    }
}
