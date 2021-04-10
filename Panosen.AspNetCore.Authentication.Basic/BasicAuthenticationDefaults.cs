using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panosen.AspNetCore.Authentication.Basic
{
    /// <summary>
    /// Default values related to basic authentication handler
    /// </summary>
    public static class BasicAuthenticationDefaults
    {
        /// <summary>
        /// Basic
        /// </summary>
        public const string AuthenticationScheme = "Basic";

        /// <summary>
        /// Basic Authentication
        /// </summary>
        public const string DisplayName = "Basic Authentication";
    }
}
