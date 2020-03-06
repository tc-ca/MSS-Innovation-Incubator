using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPOC.Utilities
{
    public class CustomRequestCultureProvider : RequestCultureProvider
    {
        private string _culture = "en-CA";
        public override Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            if (httpContext.Request.Path.Value.StartsWith("/en", StringComparison.OrdinalIgnoreCase))
            {
                _culture = "en-CA";
            }
            if (httpContext.Request.Path.Value.StartsWith("/fr", StringComparison.OrdinalIgnoreCase))
            {
                _culture = "fr-CA";
            }
            return Task.FromResult(new ProviderCultureResult(_culture));
        }
    }
}
