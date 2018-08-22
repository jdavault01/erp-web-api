using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.Orders
{    
    [DataContract]
    public class OrderRequestHeader : EntityBase
    {
        #region Properties

        [DataMember]
        public string RequestDate { get; set; }
        [DataMember]
        public string RequestTime { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string AptSuite { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public string Zip { get; set; }
        [DataMember]
        public string Telephone { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string NumOfChildren { get; set; }
        [DataMember]
        public string Questions { get; set; }
        [DataMember]
        public string HeardAboutUs { get; set; }
        [DataMember]
        public string RequestType { get; set; }
        [DataMember]
        public string OrderID { get; set; }

        [DataMember]
        public string AreYouAViacordCustomer { get; set; }

        #endregion
            
    }
}
