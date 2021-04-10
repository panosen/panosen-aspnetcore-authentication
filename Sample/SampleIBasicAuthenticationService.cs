using Panosen.AspNetCore.Authentication.Basic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Sample
{
    /// <summary>
    /// 默认身份验证器
    /// </summary>
    public class SampleIBasicAuthenticationService : IBasicAuthenticationService
    {
        public Task<bool> ValidateAsync(string userName, string password)
        {
            var valid = "harriszhang".Equals(userName, StringComparison.CurrentCultureIgnoreCase) &&
              "abc123".Equals(password, StringComparison.CurrentCultureIgnoreCase);

            return Task.FromResult(valid);
        }
    }
}
