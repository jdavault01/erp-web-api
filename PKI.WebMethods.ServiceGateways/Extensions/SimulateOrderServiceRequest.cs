using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using ServiceStubs = PKI.eBusiness.WMService.Entities.Stubs;
using System.Runtime.Serialization;
using StorefrontSimulateOrderRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.SimulateOrderRequest;

namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{

    public class SimulateOrderServiceRequest
    {
        [DataMember]
        public SimulateOrderWebServiceRequest SimulateOrderWebServiceRequest { get; set; }

        [DataMember]
        public orderRequest OrderRequestPayLoad { get; set; }

        [DataMember]
        public OrderRequest Request { get; set; }

        [DataMember]
        public OrderRequestHeader RequestHeader { get; set; }

        [DataMember]
        public OrderRequestDetail RequestDetail { get; set; }

        [DataMember]
        public OrderRequestDetail[] RequestDetails { get; set; }

        public SimulateOrderServiceRequest(StorefrontSimulateOrderRequest clientRequest)
        {
            SimulateOrderWebServiceRequest = new SimulateOrderWebServiceRequest();

            var header = new Header()
            {
                Version = new ServiceStubs.StoreFront.Version(){value = "001"},
                Sender = new Sender { Component = "ZWEB", Task = "OrderSimulateRequest" }
            };

            RequestDetails = new OrderRequestDetail[clientRequest.NumberOfItems];
            for (var i = 0; i < clientRequest.OrderItems.Count; i++)
            {
                var lineNum = i + 1;
                var requestDetail = new OrderRequestDetail
                {
                    OrderLineNumber = lineNum.ToString(),
                    ProductID = clientRequest.OrderItems[i].ProductID,
                    Quantity = clientRequest.OrderItems[i].Quantity.ToString(),
                    RequestedDate = clientRequest.OrderItems[i].RequestedDate
                };

                RequestDetails[i] = requestDetail;
            }

            var partners = new Partner3[clientRequest.Partners.Count];
            for (var i = 0; i < clientRequest.Partners.Count; i++)
            {
                var partner = new Partner3
                {
                    id = clientRequest.Partners[i].PartnerType.ToString(),
                    PartnerID = clientRequest.Partners[i].PartnerId,
                    PartnerType = clientRequest.Partners[i].PartnerType.ToString()
                };
                partners[i] = partner;
            }

            RequestHeader = new OrderRequestHeader()
            {
                SalesOrgID = clientRequest.SalesAreaInfo.SalesOrgId,
                DistChannelID = clientRequest.SalesAreaInfo.DistChannelId,
                DivisionID = clientRequest.SalesAreaInfo.DivisionId,
                language = "EN",
                NumberOfItems = clientRequest.NumberOfItems.ToString(),
                PromoCode = clientRequest.PromoCode,
                Partner = partners
            };

            var body = new Body(){OrderRequestHeader = RequestHeader,OrderRequestDetail = RequestDetails};
            var bodies = new Body[1] {body = body};

            Request = new OrderRequest(){Header = header,Body = bodies};
            OrderRequestPayLoad = new orderRequest(){OrderRequest = Request};
            SimulateOrderWebServiceRequest.OrderRequest = OrderRequestPayLoad;
        }

    }
}
