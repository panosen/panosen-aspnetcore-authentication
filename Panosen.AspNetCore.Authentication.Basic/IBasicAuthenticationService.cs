using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Panosen.AspNetCore.Authentication.Basic
{
    /// <summary>
    /// 验证用户名密码
    /// </summary>
    public interface IBasicAuthenticationService
    {
        /// <summary>
        /// 验证用户名密码
        /// </summary>
        Task<BasicAuthenticateResult> ValidateAsync(string userName, string password);
    }
}
