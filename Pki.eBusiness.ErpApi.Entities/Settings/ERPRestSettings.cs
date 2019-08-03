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
        public string IntegrationPlatformBaseUrl { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string AtgBaseUrl { get; set; }
        public string AtgApiKey { get; set; }

        protected Resource this[string name]
        {
            get { return this.Resources?.FirstOrDefault(r => r.Name == name); }
        }

        public Resource GetContactCreateRequest => this["GetContactCreateRequest"];


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
