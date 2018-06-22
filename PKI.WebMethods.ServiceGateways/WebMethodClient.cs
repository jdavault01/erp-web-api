﻿using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.Entities.StoreFront.ProductCatalog;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using PKI.eBusiness.WMService.ServiceGateways.Extensions;
using PKI.eBusiness.WMService.ServiceGatewaysContracts;
using PKI.eBusiness.WMService.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using InventoryRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.InventoryRequest;
using InventoryResponse = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.InventoryResponse;
using PartnerRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.PartnerRequest;
using PartnerResponse = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.PartnerResponse;
using ContactCreateRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.ContactCreateRequest;
using ContactCreateResponse = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.ContactCreateResponse;
//TODO:  Dependency Injection .. chat with Raji
using PKI.eBusiness.WMService.ServiceGateways.RestCalls;
using PKI.eBusiness.WMService.ServiceGateways.WMService;
using PKI.eBusiness.WMService.Entities.Orders;
using AutoMapper;

namespace PKI.eBusiness.WMService.ServiceGateways
{
    /// <summary>
    /// Web Method Client Class
    /// </summary>
    public class WebMethodClient : IWebMethodClient
    {
        #region Private variables

        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly ProcessPediatrixOrder_WSD_PortTypeClient _soapClient;
        private readonly StorefrontWebServices_PortType _soapStoreFrontWebService;
        //private readonly IWMRestServices _wmRestServices;

        #endregion // Private variables

        #region Constructors

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="soapClient"></param>
        public WebMethodClient()
        {
            _soapStoreFrontWebService = new StorefrontWebServices_PortTypeClient();
        }

        #endregion // Constructors

        #region Public methods

        /// <summary>
        /// Process Order Submission
        /// </summary>
        /// <param name="pediatrix">Pediatrix object to be processed</param>
        /// <returns></returns>
        public string ProcessOrderSubmission(Order order)
        {
            Pediatrix pedOrder = Mapper.Map<Order, Pediatrix>(order);
            string xml = pedOrder.SerializeToXml<Pediatrix>();
            LogInputRequest(xml);
            return _soapClient.ProcessPediatrixOrder(pedOrder);
        }

        private void LogInputRequest(string xml)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            Log(xml.Replace("\r\n", ""));
            Log(ErrorMessages.INVOKING_SERVICE);


        }

        //<summary>
        //This method will call the WebMethods API service and get the response back
        //</summary>
        //<param name="request">request</param>
        //<returns>response</returns>
        public OrderInfoWebServiceResponse ProcessOrderLookUpRequest(OrderInfoWebServiceRequest request)
         {
            var webServiceResponse = new OrderInfoWebServiceResponse
            {
                xmlResponse = _soapStoreFrontWebService.OrderInfoWebService(request).xmlResponse
            };
            return webServiceResponse;
         }

        #endregion 

        /// <summary>
        /// Price Request/Response
        /// </summary>
        /// <param name="priceWmRequest"></param>
        /// <returns></returns>
        public PriceResponse GetPrice(PriceRequest priceWmRequest)
        {
            Log(InfoMessages.SEND_DATA_INPUT_REQUEST);
            PriceWebServiceRequest request = priceWmRequest.ToWmPriceRequest();
            LogRequest(request);
            var wmPriceResponse = _soapStoreFrontWebService.PriceWebService(request);
            LogResponse(wmPriceResponse);

            var failedProducts = new List<FailedProduct>();

            while (wmPriceResponse.ErrorReturn != null)
            {
                var productId = GetProductFromErrorMessage(wmPriceResponse.ErrorReturn.Error);
                if (productId == string.Empty)
                {
                    Log(string.Format("{0} - {1}", ErrorMessages.ERRORS_CONTAINED_IN_RESPONSE, "Unable to get product from error return object"));
                    throw new ApplicationException("Unable to get product from error return object");
                }

                Log(string.Format("{0} for product {1}", ErrorMessages.ERRORS_CONTAINED_IN_RESPONSE, productId));

                var failedProduct = new FailedProduct { ErrorMessage = wmPriceResponse.ErrorReturn.Error, PartNumber = productId };
                failedProducts.Add(failedProduct);

                var newProductLists = request.PricingRequest.ProductList.Where(val => val.ProductID != productId).ToArray();
                request.PricingRequest.ProductList = newProductLists;
                
                Log(InfoMessages.SEND_DATA_CORRECTED_INPUT_REQUEST);
                LogRequest(request);
                wmPriceResponse = _soapStoreFrontWebService.PriceWebService(request);
                LogResponse(wmPriceResponse);
            }

            var priceResponse = wmPriceResponse.ToPriceResponse();
            
            if (failedProducts.Count == 0) return priceResponse;
            priceResponse.FailedProducts = failedProducts;
            priceResponse.ErrorMessage = "We were not able to obtain prices for all requested products.  Please see list of failed products.";
            return priceResponse;
        }

        private void LogRequest<T>(T request)
        {
            string jsonRequest = request.SerializeToJson(OutPutType.Unformatted);
            Log(jsonRequest.Replace("\r\n", ""));
            Log(InfoMessages.INVOKING_SERVICE_REQUEST);
        }

        private void LogResponse<T>(T response)
        {
            string jsonResponse = response.SerializeToJson(OutPutType.Formatted);
            Log(InfoMessages.RESPONSE_FROM_SERVICE);
            Log(jsonResponse);
        }


        private string GetProductFromErrorMessage(string errorMessage)
        {
            var match = Regex.Match(errorMessage, @"material ([A-Za-z0-9\-]+) is not defined for sales org", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }


        public SimulateOrderResponse SimulateOrder(SimulateOrderRequest simulateOrderRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = simulateOrderRequest.ToWmSimulateOrderRequest();
            LogRequest(request);
            var wmSimulateOrderResponse = _soapStoreFrontWebService.SimulateOrderWebService(request);
            LogResponse(wmSimulateOrderResponse);
            return wmSimulateOrderResponse.ToSimulateOrderResponse();
        }

        public InventoryResponse GetInventory(InventoryRequest inventoryWmRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = inventoryWmRequest.ToWmInventoryRequest();
            LogRequest(request);
            var wmInventoryResponse = _soapStoreFrontWebService.InventoryWebService(request);
            LogResponse(wmInventoryResponse);

            return wmInventoryResponse.ToInventoryResponse();
        }

        public PartnerResponse GetPartnerInfo(PartnerRequest partnerRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = partnerRequest.ToWmPartnerRequest();
            LogRequest(request);
            var wmPartnerResponse = _soapStoreFrontWebService.PartnerWebService(request);
            LogResponse(wmPartnerResponse);
            return wmPartnerResponse.ToPartnerResponse();
        }

        public PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = partnerRequest.ToWmPartnerRequest();
            LogRequest(request);
            var wmPartnerResponse = _soapStoreFrontWebService.PartnerWebService(request);
            LogResponse(wmPartnerResponse);
            return wmPartnerResponse.ToPartnerResponse();

        }

        public ContactCreateResponse CreateContact(String acountNumber, ContactCreateRequest contactCreateRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            //Convert to WebMethods Object
            var request = contactCreateRequest.ToWmContactCreateRequest();
            LogRequest(request);
            var wmRestServices = new WMRestServices();
            //Return WebMethods Object
            ContactCreateWebServiceResponse wmCreateContentResponse = wmRestServices.CreateContactRestService(request);  
            LogResponse(wmCreateContentResponse);
            //Converts to StoreFront Object
            return wmCreateContentResponse.ToContactCreateResponse();
        }


        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, Constants.LOG_AREA_STOREFRONT);
        }
    }
}
