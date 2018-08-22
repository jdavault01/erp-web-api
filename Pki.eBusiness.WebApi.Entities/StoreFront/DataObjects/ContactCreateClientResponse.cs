using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class ContactCreateClientResponse
    {
        [DataMember]
        public ContactCreateResponse ContactCreateResponse { get; set; }

        public ContactCreateClientResponse()
        {
        }

    }
}
