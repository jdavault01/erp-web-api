using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Text.RegularExpressions;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.Errors;
using PKI.eBusiness.WMService.Utility;
using PKI.eBusiness.WMService.WMServiceLibraryContracts;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;

using GeneticsOrderService = PKI.eBusiness.WMService.BusinessServicesContracts.IOrderService;
using StoreFrontOrderService = PKI.eBusiness.WMService.BusinessServicesContracts.StoreFront.IOrderService;

namespace PKI.eBusiness.WMService.WMServiceLibrary
{
    /// <summary>
    /// Web Method Service Class
    /// </summary>
    [WebMethodServiceBehavior]
    public class WMService: IWMService
    {
       
        #region Private variables

        private readonly GeneticsOrderService _orderService;
        private readonly StoreFrontOrderService _orderLookUpService;

        #endregion // Private variables
        

        #region Constructors

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="orderService"></param>
        public WMService(GeneticsOrderService orderService, StoreFrontOrderService orderLookUpService)
        {
            _orderService = orderService;
            _orderLookUpService = orderLookUpService;
        }

        #endregion // Constructors


        #region Public methods

        /// <summary>
        /// Process Order Submission
        /// </summary>
        /// <param name="order">Order to be processed</param>
        /// <returns></returns>
        public OrderSubmissionResponse ProcessOrderSubmission(Order order)
        {
            // Get a response from OrderService object:
            OrderSubmissionResponse response = new OrderSubmissionResponse();
            if (order != null && order.OrderRequest != null)
            {
                string orderNumber = order.OrderRequest.OrderRequestHeader.OrderID;
                response = _orderService.ProcessSubmision(order);
                if (response.Code == 200)
                    _orderService.Log(String.Format(ErrorMessages.ORDER_NUMBER_SUBMISSION_SUCCESS, orderNumber));
                else
                    _orderService.Log(String.Format(ErrorMessages.ORDER_NUMBER_SUBMISSION_FAILURE, orderNumber));
            }
            return response;

        }
        /// <summary>
        /// Process multiple orders
        /// </summary>
        /// <param name="orders">orders</param>
        public void ProcessMultipleOrderSubmission(List<Order> orders)
        {
            _orderService.Log(ErrorMessages.SEND_DATA_STARTED);
         
            foreach (Order order in orders)
            {
                OrderSubmissionResponse response = ProcessOrderSubmission(order);
                if (response.Code == 200)
                    _orderService.UpdateOrderStatus(order.OrderRequest.OrderRequestHeader.OrderID);
                      
            }
            _orderService.Log(ErrorMessages.SEND_DATA_COMPLETED);
           
        }
       
        /// <summary>
        /// This method gets the list of orders based on search conditions
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>OrderLookUpResponse</returns>
        public OrderLookUpResponse GetOrders(OrderLookUpRequest request)
        {
           return _orderLookUpService.GetOrders(request);
            
        }

        public OrderDetailResponse GetOrderDetails(string sellerOrderId)
        {
            return _orderLookUpService.GetOrderDetails(sellerOrderId);
        }

        #endregion // Public methods

    }
}