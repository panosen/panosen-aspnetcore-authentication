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
            var result = new BasicAuthenticateResult();

            result.Success = "harriszhang".Equals(userName, StringComparison.CurrentCultureIgnoreCase) &&
              "abc123".Equals(password, StringComparison.CurrentCultureIgnoreCase);
            if (!result.Success)
            {
                return Task.FromResult(result);
            }

            result.Claims = new List<Claim> { new Claim(ClaimTypes.Name, userName) };

            return Task.FromResult(result);
        }
    }
}
