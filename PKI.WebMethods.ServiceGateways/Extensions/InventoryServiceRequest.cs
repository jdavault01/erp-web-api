using System.Globalization;
using System.Runtime.Serialization;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using StorefrontInventoryRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.InventoryRequest;

namespace PKI.eBusiness.WMService.ServiceGateways
{
    [DataContract]
    public class InventoryServiceRequest
    {
        [DataMember]
        public InventoryWebServiceRequest WebServiceRequest { get; set; }
        [DataMember]
        public InventoryRequest Request { get; set; }
        [DataMember]
        public InventoryRequestHeader RequestHeader { get; set; }
        [DataMember]
        public Partner2[] Partners { get; set; }
        [DataMember]
        public Partner2 Partner { get; set; }

        //Intilize the object 
        public InventoryServiceRequest(StorefrontInventoryRequest clientRequest)
        {
            this.WebServiceRequest = new InventoryWebServiceRequest();
            this.Request = new InventoryRequest
            {
                InventoryRequestDetail = new InventoryRequestDetail[clientRequest.Products.Count]
            };

            this.Partners = new Partner2[2];
            this.Partner = new Partner2 { PartnerID = clientRequest.PartnerInfo[0].PartnerId, PartnerType = "ShipTo" };
            this.Partners[0] = this.Partner;
            this.Partner = new Partner2 { PartnerID = clientRequest.PartnerInfo[1].PartnerId, PartnerType = "BillTo" };
            this.Partners[1] = this.Partner;

            this.Request.InventoryRequestHeader = new InventoryRequestHeader
            {
                SalesOrgID = clientRequest.SalesAreaInfo.SalesOrgId,
                DistChannelID = clientRequest.SalesAreaInfo.DistChannelId,
                DivisionID = clientRequest.SalesAreaInfo.DivisionId,
                Partner = this.Partners
            };

            var lineNum = 0;
            foreach (var p in clientRequest.Products)
            {
                var inventoryRequestDetail = new InventoryRequestDetail
                {
                    OrderLineNumber = (lineNum + 1).ToString(CultureInfo.InvariantCulture),
                    ProductID = p.ProductId,
                    Quantity = p.Quantity.ToString(CultureInfo.InvariantCulture),
                    RequestedDate = p.RequestedDate.ToString("yyyyMMdd")
                };

                this.Request.InventoryRequestDetail[lineNum] = inventoryRequestDetail;
                lineNum++;
            }
            this.WebServiceRequest.InventoryRequest = this.Request;

        }
    }
}

