using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.Utility;
using PKI.eBusiness.WMService.Entities.Stubs;

namespace PKI.eBusiness.WMService.BusinessServicesContracts
{

    //public class OrderRequestHandler : IRequestHandler<OrderLookUpRequest,OrderLookUpResponse>
    //{
    //    private readonly IWebMethodClient _webMethodClient;

    //    public OrderRequestHandler(IWebMethodClient webMethodClient)
    //    {
    //        _webMethodClient = webMethodClient;
    //    }
    //    public OrderLookUpResponse ProcessRequest(OrderLookUpRequest request)
    //    {
    //        OrderSummaryRequest summaryRequest=request.ToWmLookUpRequest();
    //        string xmlRequest=summaryRequest.SerializeToXml();

    //        OrderInfoWebServiceRequest webServiceRequest=new OrderInfoWebServiceRequest();
    //        webServiceRequest.xmlRequest = xmlRequest;

    //        OrderInfoWebServiceResponse webServiceResponse=_webMethodClient.GetOrders(webServiceRequest);
    //        return  new OrderLookUpResponse();

    //    }
    //}
}
