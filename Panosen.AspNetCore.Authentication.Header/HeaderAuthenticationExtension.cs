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
        public static AuthenticationBuilder AddPanosenHeaderAuthentication<THeaderAuthenticationService>(this AuthenticationBuilder builder, ServiceLifetime serviceLifetime)
            where THeaderAuthenticationService : class, IHeaderAuthenticationService
        {
            return builder.AddPanosenHeaderAuthentication<THeaderAuthenticationService>(HeaderAuthenticationDefaults.AuthenticationScheme, serviceLifetime);
        }

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenHeaderAuthentication<THeaderAuthenticationService>(this AuthenticationBuilder builder, string authenticationScheme, ServiceLifetime serviceLifetime)
            where THeaderAuthenticationService : class, IHeaderAuthenticationService
        {
            return builder.AddPanosenHeaderAuthentication<THeaderAuthenticationService>(authenticationScheme, configureOptions: null, serviceLifetime);
        }

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenHeaderAuthentication<THeaderAuthenticationService>(this AuthenticationBuilder builder, Action<HeaderAuthenticationOptions> configureOptions, ServiceLifetime serviceLifetime)
            where THeaderAuthenticationService : class, IHeaderAuthenticationService
        {
            return builder.AddPanosenHeaderAuthentication<THeaderAuthenticationService>(HeaderAuthenticationDefaults.AuthenticationScheme, configureOptions, serviceLifetime);
        }

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenHeaderAuthentication<THeaderAuthenticationService>(this AuthenticationBuilder builder, string authenticationScheme, Action<HeaderAuthenticationOptions> configureOptions, ServiceLifetime serviceLifetime)
            where THeaderAuthenticationService : class, IHeaderAuthenticationService
        {
            return builder.AddPanosenHeaderAuthentication<THeaderAuthenticationService>(authenticationScheme, displayName: HeaderAuthenticationDefaults.DisplayName, configureOptions: configureOptions, serviceLifetime);
        }

        /// <summary>
        /// 添加基础身份认证
        /// </summary>
        public static AuthenticationBuilder AddPanosenHeaderAuthentication<THeaderAuthenticationService>(this AuthenticationBuilder builder, string authenticationScheme, string displayName, Action<HeaderAuthenticationOptions> configureOptions, ServiceLifetime serviceLifetime)
            where THeaderAuthenticationService : class, IHeaderAuthenticationService
        {
            builder.Services.AddOptions<HeaderAuthenticationOptions>(authenticationScheme)
                .Validate(options => !string.IsNullOrEmpty(options.HeaderKey), "options.HeaderKey is null or empty");

            builder.AddScheme<HeaderAuthenticationOptions, HeaderAuthenticationHandler>(authenticationScheme, displayName, configureOptions);

            builder.Services.Add(ServiceDescriptor.Describe(typeof(IHeaderAuthenticationService), typeof(THeaderAuthenticationService), serviceLifetime));

            return builder;
        }
    }
}
