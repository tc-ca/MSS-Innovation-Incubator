using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoC.WebTemplate.Components.Entities;
using Microsoft.AspNetCore.Components;

namespace BlazorPOC.Utilities
{
    public static class PageBreadcrumb
    {
        public static List<Breadcrumb> GetBreadcrumbs(string path, SharedResourceMgt localizer)
        {
            if (localizer == null)
            {
                throw new ArgumentNullException(nameof(localizer));
            }

            List<Breadcrumb> list = new List<Breadcrumb>();
            list.Add(new Breadcrumb { Href = localizer[nameof(Resources.SharedResource.HomeHref)], Title = localizer[nameof(Resources.SharedResource.Home)] });
          
            switch (path)
            {
                case @"/en/counter":
                case @"/fr/counter":
                    list.Add(new Breadcrumb { Href = path, Title = localizer[nameof(Resources.SharedResource.Counter)] });
                    break;
                case @"/en/fetchdata":
                case @"/fr/fetchdata":
                    list.Add(new Breadcrumb { Href = path, Title = localizer[nameof(Resources.SharedResource.FetchDataNav)] });
                    break;
                case @"/en/vesseldimension":
                case @"/fr/vesseldimension":
                    list.Add(new Breadcrumb { Href = path, Title = localizer[nameof(Resources.SharedResource.VesselDimensionNav)] });
                    break;
                case @"/en/feedback":
                case @"/fr/feedback":
                    list.Add(new Breadcrumb { Href = path, Title = localizer[nameof(Resources.SharedResource.FeedbackNav)] });
                    break;
            }
            return list;
        }
    }
}
