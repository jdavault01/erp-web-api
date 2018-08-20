using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class RestRequest
    {
        [DataMember(IsRequired = true)]
        public string PayLoad { get; set; }

        [DataMember(IsRequired = true)]
        public HttpVerb HttpMethod { get; set; }

    }

    public enum HttpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}
