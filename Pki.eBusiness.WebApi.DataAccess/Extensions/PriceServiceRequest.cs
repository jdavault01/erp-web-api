using System.Runtime.Serialization;
using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using StorefrontPriceRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.PriceRequest;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{
    [DataContract]
    public class PriceServiceRequest
    {
        [DataMember]
        public PriceWebServiceRequest PriceWebServiceRequest { get; set; }

        public PriceServiceRequest(StorefrontPriceRequest request)
        {

            PriceWebServiceRequest = new PriceWebServiceRequest();
            var productLists = new ProductList[request.Products.Count];

            for (int i = 0; i < request.Products.Count; i++)
            {
                var productList = new ProductList { ProductID = request.Products[i].PartNumber };
                productLists[i] = productList;
            }

            var pricingRequest = new ProductPricingRequest
            {
                ShipTo = request.PartnerInfo[0].PartnerId,
                BillTo = request.PartnerInfo[1].PartnerId,
                DistChannelID = request.SalesAreaInfo.DistChannelId,
                DivisionID = request.SalesAreaInfo.DivisionId,
                SalesOrgID = request.SalesAreaInfo.SalesOrgId,
                ProductList = productLists
            };

            PriceWebServiceRequest.PricingRequest = pricingRequest;

        }
    }
}
