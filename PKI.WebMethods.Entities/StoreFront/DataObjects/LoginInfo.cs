using System.Runtime.Serialization;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    public class LoginInfo
    {
        [DataMember(IsRequired = true)]
        public string UserName { get; set; }

        [DataMember(IsRequired = true)]
        public string Password { get; set; }
    }
}
