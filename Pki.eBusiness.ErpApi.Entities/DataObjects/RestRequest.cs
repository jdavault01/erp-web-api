namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class RestRequest
    {
        
        public string PayLoad { get; set; }

        
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
