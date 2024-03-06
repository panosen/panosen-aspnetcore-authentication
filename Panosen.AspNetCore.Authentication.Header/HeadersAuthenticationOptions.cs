using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panosen.AspNetCore.Authentication.Header
{
    /// <summary>
    /// HeaderAuthenticationOptions
    /// </summary>
    public class HeaderAuthenticationOptions : AuthenticationSchemeOptions
    {
        /// <summary>
        /// HeaderKey
        /// </summary>
        public string HeaderKey { get; set; }
    }
}
