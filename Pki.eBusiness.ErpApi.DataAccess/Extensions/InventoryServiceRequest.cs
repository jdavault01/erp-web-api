using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{
    
    public class InventoryServiceRequest
    {
        
        public InventoryWebServiceRequest WebServiceRequest { get; set; }
        
        public InventoryRequest Request { get; set; }
        
        public InventoryRequestHeader RequestHeader { get; set; }
        
        public Partner2[] Partners { get; set; }
        
        public Partner2 Partner { get; set; }

        //Intilize the object 
        //public InventoryServiceRequest(StorefrontInventoryRequest clientRequest)
        //{
        //    this.WebServiceRequest = new InventoryWebServiceRequest();
        //    this.Request = new InventoryRequest
        //    {
        //        InventoryRequestDetail = new InventoryRequestDetail[clientRequest.Products.Count]
        //    };

        //    this.Partners = new Partner2[2];
        //    this.Partner = new Partner2 { PartnerID = clientRequest.PartnerInfo[0].PartnerId, PartnerType = "ShipTo" };
        //    this.Partners[0] = this.Partner;
        //    this.Partner = new Partner2 { PartnerID = clientRequest.PartnerInfo[1].PartnerId, PartnerType = "BillTo" };
        //    this.Partners[1] = this.Partner;

        //    this.Request.InventoryRequestHeader = new InventoryRequestHeader
        //    {
        //        SalesOrgID = clientRequest.SalesAreaInfo.SalesOrgId,
        //        DistChannelID = clientRequest.SalesAreaInfo.DistChannelId,
        //        DivisionID = clientRequest.SalesAreaInfo.DivisionId,
        //        Partner = this.Partners
        //    };

        //    var lineNum = 0;
        //    foreach (var p in clientRequest.Products)
        //    {
        //        var inventoryRequestDetail = new InventoryRequestDetail
        //        {
        //            OrderLineNumber = (lineNum + 1).ToString(CultureInfo.InvariantCulture),
        //            ProductID = p.ProductId,
        //            Quantity = p.Quantity.ToString(CultureInfo.InvariantCulture),
        //            RequestedDate = p.RequestedDate.ToString("yyyyMMdd")
        //        };

        //        this.Request.InventoryRequestDetail[lineNum] = inventoryRequestDetail;
        //        lineNum++;
        //    }
        //    this.WebServiceRequest.InventoryRequest = this.Request;

        //}
    }
}

