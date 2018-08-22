using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
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
