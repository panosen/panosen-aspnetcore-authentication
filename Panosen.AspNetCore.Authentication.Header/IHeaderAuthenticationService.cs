using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Panosen.AspNetCore.Authentication.Header
{
    /// <summary>
    /// Header验证器
    /// </summary>
    public interface IHeaderAuthenticationService
    {
        /// <summary>
        /// 验证成功，返回userName，否则返回null
        /// </summary>
        /// <returns></returns>
        Task<bool> AuthenticateAsync(string headerValue);
    }
}
