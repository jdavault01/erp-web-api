using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMService.Entities.StoreFront.ProductCatalog;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class PriceRequest : EntityBase
    {
        #region Properties

        [DataMember]
        public List<BasePartner> PartnerInfo { get; set; }

        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }

        [DataMember]
        public List<Product> Products { get; set; }

        #endregion
    }
}
