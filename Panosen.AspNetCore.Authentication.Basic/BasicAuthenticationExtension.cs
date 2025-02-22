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
        public static AuthenticationBuilder AddPanosenBasicAuthentication<TBasicAuthenticationService>(this AuthenticationBuilder builder, ServiceLifetime serviceLifetime)
            where TBasicAuthenticationService : class, IBasicAuthenticationService
        {
            return builder.AddPanosenBasicAuthentication<TBasicAuthenticationService>(BasicAuthenticationDefaults.AuthenticationScheme, serviceLifetime);
        }


        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication<TBasicAuthenticationService>(this AuthenticationBuilder builder, string authenticationScheme, ServiceLifetime serviceLifetime)
            where TBasicAuthenticationService : class, IBasicAuthenticationService
        {
            return builder.AddPanosenBasicAuthentication<TBasicAuthenticationService>(authenticationScheme, configureOptions: null, serviceLifetime);
        }

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication<TBasicAuthenticationService>(this AuthenticationBuilder builder, Action<BasicAuthenticationOptions> configureOptions, ServiceLifetime serviceLifetime)
            where TBasicAuthenticationService : class, IBasicAuthenticationService
        {
            return builder.AddPanosenBasicAuthentication<TBasicAuthenticationService>(BasicAuthenticationDefaults.AuthenticationScheme, configureOptions, serviceLifetime);
        }

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication<TBasicAuthenticationService>(this AuthenticationBuilder builder, string authenticationScheme, Action<BasicAuthenticationOptions> configureOptions, ServiceLifetime serviceLifetime)
            where TBasicAuthenticationService : class, IBasicAuthenticationService
        {
            return builder.AddPanosenBasicAuthentication<TBasicAuthenticationService>(authenticationScheme, displayName: BasicAuthenticationDefaults.DisplayName, configureOptions: configureOptions, serviceLifetime);
        }

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenBasicAuthentication<TBasicAuthenticationService>(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<BasicAuthenticationOptions> configureOptions, ServiceLifetime serviceLifetime)
            where TBasicAuthenticationService : class, IBasicAuthenticationService
        {
            builder.Services.AddOptions<BasicAuthenticationOptions>(authenticationScheme);

            builder.AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>(authenticationScheme, displayName, configureOptions);

            builder.Services.Add(ServiceDescriptor.Describe(typeof(IBasicAuthenticationService), typeof(TBasicAuthenticationService), serviceLifetime));

            return builder;
        }
    }
}
