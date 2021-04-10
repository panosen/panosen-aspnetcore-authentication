using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Panosen.AspNetCore.Authentication.Header;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 参考 https://github.com/dotnet/aspnetcore/tree/master/src/Security/Authentication/Basics/src
    /// </summary>
    public static class HeaderAuthenticationExtension
    {
        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddHeader(this AuthenticationBuilder builder)
            => builder.AddHeader(HeaderAuthenticationDefaults.AuthenticationScheme);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddHeader(this AuthenticationBuilder builder, string authenticationScheme)
            => builder.AddHeader(authenticationScheme, configureOptions: null);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddHeader(this AuthenticationBuilder builder, Action<HeaderAuthenticationOptions> configureOptions)
            => builder.AddHeader(HeaderAuthenticationDefaults.AuthenticationScheme, configureOptions);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddHeader(this AuthenticationBuilder builder, string authenticationScheme, Action<HeaderAuthenticationOptions> configureOptions)
            => builder.AddHeader(authenticationScheme, displayName: null, configureOptions: configureOptions);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddHeader(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<HeaderAuthenticationOptions> configureOptions)
        {
            builder.Services.AddOptions<HeaderAuthenticationOptions>(authenticationScheme)
                .Validate(options => !string.IsNullOrEmpty(options.HeaderKey), "options.HeaderKey is null or empty");

            return builder.AddScheme<HeaderAuthenticationOptions, HeaderAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
