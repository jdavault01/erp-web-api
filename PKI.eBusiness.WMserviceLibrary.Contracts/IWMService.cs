using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.Errors;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;

namespace PKI.eBusiness.WMService.WMServiceLibraryContracts
{
    /// <summary>
    /// Web Method Service Interface
    /// </summary>
    [ServiceContract]
   [ServiceKnownType(typeof(OrderSubmissionResponse))]
    public  interface IWMService
    {
        [OperationContract]
        [FaultContract(typeof (CustomError))]       
        OrderSubmissionResponse ProcessOrderSubmission(Order order);

        [OperationContract]
        [FaultContract(typeof(CustomError))]
        void ProcessMultipleOrderSubmission(List<Order> orders);

        [OperationContract]
        [FaultContract(typeof(CustomError))]
        OrderLookUpResponse GetOrders(OrderLookUpRequest request);

        [OperationContract]
        [FaultContract(typeof(CustomError))]
        OrderDetailResponse GetOrderDetails(string sellerOrderId);

     
    }
}