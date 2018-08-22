using System.Runtime.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices;
using PartnerRequestDetail = PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices.PartnerRequestDetail;
using PartnerRequestHeader = PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices.PartnerRequestHeader;

namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{
    [DataContract]
    public class PartnerServiceRequest
    {
        [DataMember]
        public PartnerWebServiceRequest WebServiceRequest { get; set; }

        [DataMember]
        public StoreFrontWebServices.PartnerRequest RequestPayLoad { get; set; }

        [DataMember]
        public PartnerRequestHeader RequestHeader { get; set; }

        [DataMember]
        public PartnerRequestDetail RequestDetail { get; set; }

        [DataMember]
        public PartnerRequestDetail[] RequestDetails { get; set; }
        public PartnerServiceRequest(Entities.StoreFront.DataObjects.PartnerRequest clientRequest)
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
