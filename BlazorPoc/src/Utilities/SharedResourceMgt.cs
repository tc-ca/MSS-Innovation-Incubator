using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorPOC.Utilities
{
    public class SharedResourceMgt
    {
        public string this[string name]
        {
            get
            {
                return Resources.SharedResource.ResourceManager.GetString(name, Resources.SharedResource.Culture);
            }
        }

    }
}
