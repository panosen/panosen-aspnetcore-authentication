﻿using System.Collections.Generic;
using System.Security.Claims;

namespace Panosen.AspNetCore.Authentication.Header
{
    /// <summary>
    /// 验证结果
    /// </summary>
    public class HeaderAuthenticateResult
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
        public static readonly HeaderAuthenticateResult Fail = new HeaderAuthenticateResult { Success = false };

        /// <summary>
        /// 验证成功
        /// </summary>
        public static HeaderAuthenticateResult Ok(IEnumerable<Claim> claims)
        {
            return new HeaderAuthenticateResult { Success = true, Claims = claims };
        }
    }
}
