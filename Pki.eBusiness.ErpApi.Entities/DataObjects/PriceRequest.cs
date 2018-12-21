using System.Collections.Generic;
using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.Converters;
using Pki.eBusiness.ErpApi.Entities.ProductCatalog;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    public class PriceRequest : EntityBase
    {
        #region Properties

        [JsonConverter(typeof(CollectionEntityConverter<Partner, IPartner>))]
        public List<IPartner> PartnerInfo { get; set; }

        public SalesArea SalesAreaInfo { get; set; }

        public List<Product> Products { get; set; }

        #endregion
    }
}
