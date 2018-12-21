using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using PartnerRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.PartnerRequest;
using PartnerRequestDetail = Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices.PartnerRequestDetail;
using PartnerRequestHeader = Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices.PartnerRequestHeader;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
{
    
    public class PartnerServiceRequest
    {
        
        public PartnerWebServiceRequest WebServiceRequest { get; set; }

        
        public StoreFrontWebServices.PartnerRequest RequestPayLoad { get; set; }

        
        public PartnerRequestHeader RequestHeader { get; set; }

        
        public PartnerRequestDetail RequestDetail { get; set; }

        
        public PartnerRequestDetail[] RequestDetails { get; set; }
        public PartnerServiceRequest(PartnerRequest clientRequest)
        {
            WebServiceRequest = new PartnerWebServiceRequest();
            RequestHeader = new PartnerRequestHeader()
            {
                SalesOrgID = clientRequest.RequestHeader.SalesAreaInfo.SalesOrgId,
                DISTR_CHAN = clientRequest.RequestHeader.SalesAreaInfo.DistChannelId,
                DIVISION = clientRequest.RequestHeader.SalesAreaInfo.DivisionId
            };

            RequestDetail = new PartnerRequestDetail()
            {
                PartnerID = clientRequest.RequestDetail[0].PartnerInfo[0].PartnerId,
                PartnerType = "ShipTo"
            };

            RequestDetails = new PartnerRequestDetail[clientRequest.RequestDetail.Length];
            RequestDetails[0] = RequestDetail;

            RequestPayLoad = new StoreFrontWebServices.PartnerRequest()
            {
                PartnerRequestDetail = RequestDetails, 
                PartnerRequestHeader = RequestHeader
            };
            WebServiceRequest.PartnerRequest = RequestPayLoad;

        }

        public PartnerServiceRequest(SimplePartnerRequest clientRequest)
        {
            this.WebServiceRequest = new PartnerWebServiceRequest();
            this.RequestHeader = new PartnerRequestHeader()
            {
                SalesOrgID = clientRequest.SalesAreaInfo.SalesOrgId,
                DISTR_CHAN = clientRequest.SalesAreaInfo.DistChannelId,
                DIVISION = clientRequest.SalesAreaInfo.DivisionId
            };

            this.RequestDetail = new PartnerRequestDetail()
            {
                PartnerID = clientRequest.PartnerId,
                PartnerType = "ShipTo"
            };

            this.RequestDetails = new PartnerRequestDetail[1];
            RequestDetails[0] = RequestDetail;

            RequestPayLoad = new StoreFrontWebServices.PartnerRequest()
            {
                PartnerRequestDetail = RequestDetails,
                PartnerRequestHeader = RequestHeader
            };
            WebServiceRequest.PartnerRequest = RequestPayLoad;

        }

    }
}
