using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Panosen.AspNetCore.Authentication.Header
{
    /// <summary>
    /// HeaderAuthenticationBuilder
    /// </summary>
    public class HeaderAuthenticationBuilder
    {
        private readonly IServiceCollection services;

        /// <summary>
        /// HeaderAuthenticationBuilder
        /// </summary>
        /// <param name="services"></param>
        public HeaderAuthenticationBuilder(IServiceCollection services) => this.services = services;

        /// <summary>
        /// AddHeaderAuthenticationService
        /// </summary>
        public void AddHeaderAuthenticationService<THeaderAuthenticationService>(ServiceLifetime serviceLifetime)
            where THeaderAuthenticationService : class, IHeaderAuthenticationService
        {
            services.Add(ServiceDescriptor.Describe(typeof(THeaderAuthenticationService), typeof(THeaderAuthenticationService), serviceLifetime));
        }
    }
}
