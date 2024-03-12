using System.Collections.Generic;
using System.Security.Claims;

namespace Panosen.AspNetCore.Authentication.Basic
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public class BasicAuthenticateResult
    {
        /// <summary>
        /// 验证结果
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 令牌
        /// </summary>
        public List<Claim> Claims { get; set; }
    }
}
