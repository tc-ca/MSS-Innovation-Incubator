using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorPOC.Utilities
{
    public static class CdtsSettings
    {
        public static void Create(string pathValue, GoC.WebTemplate.Components.Model model, SharedResourceMgt localizer)
        {
            if (string.IsNullOrEmpty(pathValue))
            {
                throw new ArgumentNullException(nameof(pathValue));
            }

            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (pathValue.StartsWith("/en", StringComparison.OrdinalIgnoreCase) ||
                pathValue.StartsWith("/fr", StringComparison.OrdinalIgnoreCase))
            {
                var path = pathValue.Split("/");
                model.Breadcrumbs = PageBreadcrumb.GetBreadcrumbs(pathValue, localizer);
                model.HeaderTitle = "Transport";

                path[1] = path[1].Equals("en", StringComparison.OrdinalIgnoreCase) ? "fr" : "en";
                model.LanguageLink.Href = string.Join("/", path);
            }
        }
    }
}
