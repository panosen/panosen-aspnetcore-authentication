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
        public bool Success { get; private set; }

        /// <summary>
        /// 令牌
        /// </summary>
        public IEnumerable<Claim> Claims { get; private set; }

        /// <summary>
        /// 验证失败
        /// </summary>
        public static readonly BasicAuthenticateResult Fail = new BasicAuthenticateResult { Success = false };

        /// <summary>
        /// 验证成功
        /// </summary>
        public static BasicAuthenticateResult Ok(IEnumerable<Claim> claims)
        {
            return new BasicAuthenticateResult { Success = true, Claims = claims };
        }
    }
}
