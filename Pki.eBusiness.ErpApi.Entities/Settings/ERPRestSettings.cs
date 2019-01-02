using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pki.eBusiness.ErpApi.Entities.Settings
{
    public class ERPRestSettings
    {
        public string BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public List<Resource> Resources { get; set; }

        public string GetEndpoint(string resourceName)
        {
            var resource = Resources.FirstOrDefault(c => c.Name == resourceName);
            return resource == null ? null : $"{BaseUrl}/{resource.Path}";
        }

        public Resource GetResource(string resourceName)
        {
            return Resources.FirstOrDefault(c => c.Name == resourceName);
        }
    }

    public class Resource
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
    }
}
