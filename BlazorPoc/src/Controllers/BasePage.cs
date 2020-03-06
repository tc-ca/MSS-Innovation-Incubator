using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Routing;
using BlazorPOC.Utilities;
using System.Globalization;
using System.Threading;
using System;
using System.Collections.Generic;

namespace BlazorPOC.Controllers
{
    public class BasePageComponent : ComponentBase
    {
        [Inject] NavigationManager navigationManager { get; set; }
        [Inject] IJSRuntime jsRuntime { get; set; }
        [Inject] SharedResourceMgt localizer { get; set; }

        private string currentUri;
        [Parameter]
        public string LanguageCode { get; set; }

        void LocationChanged(object sender, LocationChangedEventArgs e)
        {
#pragma warning disable CA1304 // Specify CultureInfo
            var currentRelativePath = navigationManager.ToBaseRelativePath(currentUri).ToLower();
            var newRelativePath = navigationManager.ToBaseRelativePath(navigationManager.Uri).ToLower();
#pragma warning restore CA1304 // Specify CultureInfo1

            if ((currentRelativePath.StartsWith("en", StringComparison.OrdinalIgnoreCase) && newRelativePath.StartsWith("fr", StringComparison.OrdinalIgnoreCase)) ||
               (currentRelativePath.StartsWith("fr", StringComparison.OrdinalIgnoreCase) && newRelativePath.StartsWith("en", StringComparison.OrdinalIgnoreCase)))
            {
                //if language has been changed, redirect to new URI
                navigationManager.NavigateTo(navigationManager.Uri, true);
                return;
            }

            if (newRelativePath.StartsWith("en", StringComparison.OrdinalIgnoreCase) || newRelativePath.StartsWith("fr", StringComparison.OrdinalIgnoreCase))
            {
                List<GoC.WebTemplate.Components.Entities.Breadcrumb> breadcrumbs = PageBreadcrumb.GetBreadcrumbs("/"+newRelativePath, localizer);
                string breadcrumbStrs = "";
                foreach (var item in breadcrumbs)
                {
                    breadcrumbStrs += "<li><a href =" + item.Href + " > " + item.Title + " </a></li>";
                }
                jsRuntime.InvokeVoidAsync("UpdateBreadcrumbs", breadcrumbStrs);
            }
        }

        public void SetSwitchLanguage()
        {
            navigationManager.LocationChanged += LocationChanged;
            currentUri = navigationManager.Uri;
            string newCultureCode = navigationManager.ToBaseRelativePath(navigationManager.Uri).Substring(0, 2).ToLower();
            string switchLanguage = newCultureCode.Equals("en", StringComparison.OrdinalIgnoreCase) ? "fr" : "en";
            string path = navigationManager.ToBaseRelativePath(navigationManager.Uri).Substring(2).Replace("#", "");
            jsRuntime.InvokeVoidAsync("UpdateSwitchLanguage", switchLanguage + path);
        }
    }
}
