using Panosen.AspNetCore.Authentication.Header;
using System;
using System.Collections.Generic;
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
        public Task<bool> AuthenticateAsync(string headerValue)
        {
            return Task.FromResult(!string.IsNullOrEmpty(headerValue));
        }
    }
}
