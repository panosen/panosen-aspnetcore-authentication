using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Panosen.AspNetCore.Authentication.Basic
{
    /// <summary>
    /// BasicAuthenticationBuilder
    /// </summary>
    public class BasicAuthenticationBuilder
    {
        private readonly IServiceCollection services;

        /// <summary>
        /// BasicAuthenticationBuilder
        /// </summary>
        /// <param name="services"></param>
        public BasicAuthenticationBuilder(IServiceCollection services) => this.services = services;

        /// <summary>
        /// AddBasicAuthenticationService
        /// </summary>
        public void AddBasicAuthenticationService<TBasicAuthenticationService>(ServiceLifetime serviceLifetime)
            where TBasicAuthenticationService : class, IBasicAuthenticationService
        {
            services.Add(ServiceDescriptor.Describe(typeof(TBasicAuthenticationService), typeof(TBasicAuthenticationService), serviceLifetime));
        }
    }
}
