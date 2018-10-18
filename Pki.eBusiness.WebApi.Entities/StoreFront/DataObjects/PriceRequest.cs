using System.Collections.Generic;
using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;
using Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class PriceRequest : EntityBase
    {
        #region Properties

        [DataMember]
        public List<IPartner> PartnerInfo { get; set; }

        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }

        [DataMember]
        public List<Product> Products { get; set; }

        #endregion
    }
}
