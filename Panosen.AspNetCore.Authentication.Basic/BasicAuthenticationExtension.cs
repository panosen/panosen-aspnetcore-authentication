using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Panosen.AspNetCore.Authentication.Basic;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 参考 https://github.com/dotnet/aspnetcore/tree/master/src/Security/Authentication/Basics/src
    /// </summary>
    public static class BasicAuthenticationExtension
    {
        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication(this AuthenticationBuilder builder)
            => builder.AddPanosenBasicAuthentication(BasicAuthenticationDefaults.AuthenticationScheme);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication(this AuthenticationBuilder builder, string authenticationScheme)
            => builder.AddPanosenBasicAuthentication(authenticationScheme, configureOptions: null);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication(this AuthenticationBuilder builder, Action<BasicAuthenticationOptions> configureOptions)
            => builder.AddPanosenBasicAuthentication(BasicAuthenticationDefaults.AuthenticationScheme, configureOptions);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication(this AuthenticationBuilder builder, string authenticationScheme, Action<BasicAuthenticationOptions> configureOptions)
            => builder.AddPanosenBasicAuthentication(authenticationScheme, displayName: null, configureOptions: configureOptions);

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<BasicAuthenticationOptions> configureOptions)
        {
            builder.Services.AddOptions<BasicAuthenticationOptions>(authenticationScheme);

            return builder.AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
        }
    }
}
