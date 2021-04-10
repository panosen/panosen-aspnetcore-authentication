using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.AspNetCore.Authentication.Header
{
    /// <summary>
    /// Default values related to Header authentication handler
    /// </summary>
    public static class HeaderAuthenticationDefaults
    {
        /// <summary>
        /// Basic
        /// </summary>
        public const string AuthenticationScheme = "Header";

        /// <summary>
        /// Basic Authentication
        /// </summary>
        public const string DisplayName = "Header Authentication";
    }
}
