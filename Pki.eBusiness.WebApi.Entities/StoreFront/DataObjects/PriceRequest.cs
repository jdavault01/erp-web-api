using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Pki.eBusiness.WebApi.Entities.Converters;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;
using Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
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
