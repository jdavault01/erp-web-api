using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Pki.eBusiness.WebApi.Contracts.DAL;
using Pki.eBusiness.WebApi.DataAccess.Extensions;
using Pki.eBusiness.WebApi.DataAccess.StoreFrontWebServices;
using Pki.eBusiness.WebApi.DataAccess.WMService;
using Pki.eBusiness.WebApi.Entities;
using Pki.eBusiness.WebApi.Entities.Constants;
using Pki.eBusiness.WebApi.Entities.Extensions;
using Pki.eBusiness.WebApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.WebApi.Entities.Settings;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using Pki.eBusiness.WebApi.Entities.StoreFront.ProductCatalog;
using PKI.eBusiness.WMService.Logger;
using InventoryRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.InventoryRequest;
using InventoryResponse = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.InventoryResponse;
using PartnerRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.PartnerRequest;
using PartnerResponse = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.PartnerResponse;

namespace Pki.eBusiness.WebApi.DataAccess
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

        //Let's get DI going with this guy
        //private ERPRestSettings _erpRestSettings;

        #endregion // Private variables

        #region Constructors

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="soapClient"></param>
        public WebMethodClient()
        {
            _soapClient = new ProcessPediatrixOrder_WSD_PortTypeClient();
            _soapStoreFrontWebService = new StorefrontWebServices_PortTypeClient();
        }

        #endregion // Constructors

        #region Public methods

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
        public OrderInfoResponse ProcessOrderLookUpRequest(OrderInfoRequest request)
        {
            OrderInfoWebServiceRequest req = new OrderInfoWebServiceRequest(request.xmlRequest, request.node);
            var webServiceResponse = new OrderInfoResponse
            {
                xmlResponse = _soapStoreFrontWebService.OrderInfoWebService(req).xmlResponse
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

                if (newProductLists.Length == 0)
                    break;

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
            var match = Regex.Match(errorMessage, @"material ([A-Za-z0-9\-]+) ", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = createOrderRequest.ToWmOrderRequest();
            LogRequest(request);
            var wmOrderResponse = _soapStoreFrontWebService.OrderWebService(request);
            LogResponse(wmOrderResponse);
            return wmOrderResponse.ToOrderResponse();
        }

        public SimulateOrderResponse SimulateOrder(SimulateOrderRequest simulateOrderRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = simulateOrderRequest.ToWmSimulateOrderRequest();
            LogRequest(request);
            var wmSimulateOrderResponse = _soapStoreFrontWebService.SimulateOrderWebService(request);
            LogResponse(wmSimulateOrderResponse);
            var failedItems = new List<FailedItem>();
            while (wmSimulateOrderResponse.ErrorResponse != null && wmSimulateOrderResponse.ErrorResponse.ErrorResponse1.Body[0].Error != string.Empty)
            {
                var errorMessage = wmSimulateOrderResponse.ErrorResponse.ErrorResponse1.Body[0].Error;
                string productId = LogFailedItem(failedItems, errorMessage);

                var newitemsList = request.OrderRequest.OrderRequest.Body[0].OrderRequestDetail.Where(val => val.ProductID != productId).ToArray();
                request.OrderRequest.OrderRequest.Body[0].OrderRequestDetail = newitemsList;

                if (newitemsList.Length == 0)
                    break;

                Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
                LogRequest(request);
                wmSimulateOrderResponse = _soapStoreFrontWebService.SimulateOrderWebService(request);
                LogResponse(wmSimulateOrderResponse);

            }

            var simulateOrderResponose =  wmSimulateOrderResponse.ToSimulateOrderResponse();

            if (failedItems.Count == 0) return simulateOrderResponose;
            simulateOrderResponose.FailedItems = failedItems;
            simulateOrderResponose.ErrorMessage = "We were not able to obtain response items for all requested products.  Please see list of failed inventory items.";
            return simulateOrderResponose;
        }

        public InventoryResponse GetInventory(InventoryRequest inventoryWmRequest)
        {
            var wmInventoryResponse = new InventoryWebServiceResponse1();

            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = inventoryWmRequest.ToWmInventoryRequest();
            LogRequest(request);
            wmInventoryResponse = _soapStoreFrontWebService.InventoryWebService(request);
            LogResponse(wmInventoryResponse);

            var failedItems = new List<FailedItem>();

            while (wmInventoryResponse.ErrorResponse != null)
            {
                var errorMessage = wmInventoryResponse.ErrorResponse.ErrorResponse1.Body[0].Error;
                string productId = LogFailedItem(failedItems, errorMessage);

                var newitemsList = request.InventoryRequest.InventoryRequestDetail.Where(val => val.ProductID != productId).ToArray();
                request.InventoryRequest.InventoryRequestDetail = newitemsList;

                if (newitemsList.Length == 0)
                    break;

                Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
                //request = inventoryWmRequest.ToWmInventoryRequest();
                LogRequest(request);
                wmInventoryResponse = _soapStoreFrontWebService.InventoryWebService(request);
                LogResponse(wmInventoryResponse);

            }
            var inventoryResponse = wmInventoryResponse.ToInventoryResponse();

            if (failedItems.Count == 0) return inventoryResponse;
            inventoryResponse.FailedItems = failedItems;
            inventoryResponse.ErrorMessage = "We were not able to obtain response items for all requested products.  Please see list of failed inventory items.";
            return inventoryResponse;
        }

        private string LogFailedItem(List<FailedItem> failedItems, string errorMessage)
        {
            if (String.IsNullOrEmpty(errorMessage))
                return errorMessage;

            var productId = GetProductFromErrorMessage(errorMessage);
            if (productId == string.Empty)
            {
                Log(string.Format("{0} - {1}", ErrorMessages.ERRORS_CONTAINED_IN_RESPONSE, "Unable to get product from error return object"));
                throw new ApplicationException("Unable to get product from error return object");
            }

            Log(string.Format("{0} for product {1}", ErrorMessages.ERRORS_CONTAINED_IN_RESPONSE, productId));

            var failedItem = new FailedItem { ErrorMessage = errorMessage, ProductId = productId };
            failedItems.Add(failedItem);
            return productId;
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

        public Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.ContactCreateResponse CreateContact(String acountNumber, Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.ContactCreateRequest contactCreateRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = contactCreateRequest.ToWmContactCreateRequest();
            LogRequest(request);
            var _erpSettings = RestGatewaySettings.GetElement<ERPRestSettings>("pkieBusiness/erpRestSettings");
            var _erpRestGateway = new ERPRestGateway(_erpSettings, null);
            var wmCreateContentResponse = _erpRestGateway.CreateContact(request, "ContactCreateRequest");
            LogResponse(wmCreateContentResponse);
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
