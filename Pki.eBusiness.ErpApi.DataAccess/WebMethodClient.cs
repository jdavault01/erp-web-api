using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;
using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using Pki.eBusiness.ErpApi.DataAccess.WMService;
using Pki.eBusiness.ErpApi.Entities.Constants;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.Extensions;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.ErpApi.Entities.ProductCatalog;
using Pki.eBusiness.ErpApi.Entities.Settings;
using Pki.eBusiness.ErpApi.Logger;
using InventoryRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.InventoryRequest;
using InventoryResponse = Pki.eBusiness.ErpApi.Entities.DataObjects.InventoryResponse;
using PartnerResponse = Pki.eBusiness.ErpApi.Entities.DataObjects.PartnerResponse;

namespace Pki.eBusiness.ErpApi.DataAccess
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
        private readonly IERPRestGateway _erpRestGateway;

        #endregion // Private variables

        #region Constructors

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="soapClient"></param>
        public WebMethodClient(ERPRestSettings erpSettings, IERPRestGateway erpRestGateway)
        {
            _erpRestGateway = erpRestGateway;
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
                xmlResponse = _soapStoreFrontWebService.OrderInfoWebServiceAsync(req).Result.xmlResponse
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
            var wmPriceResponse = _soapStoreFrontWebService.PriceWebServiceAsync(request).Result;
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
                if (newProductLists.Length == request.PricingRequest.ProductList.Length)
                    break;
                request.PricingRequest.ProductList = newProductLists;

                if (newProductLists.Length == 0)
                    break;

                Log(InfoMessages.SEND_DATA_CORRECTED_INPUT_REQUEST);
                LogRequest(request);
                wmPriceResponse = _soapStoreFrontWebService.PriceWebServiceAsync(request).Result;
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
            var match = Regex.Match(errorMessage, @"material ([A-Za-z0-9\-\s]+) is not defined for", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value : string.Empty;
        }

        public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = createOrderRequest.ToWmOrderRequest();
            LogRequest(request);
            var wmOrderResponse = _soapStoreFrontWebService.OrderWebServiceAsync(request).Result;
            LogResponse(wmOrderResponse);
            return wmOrderResponse.ToOrderResponse();
        }

        public SimulateOrderResponse SimulateOrder(SimulateOrderRequest simulateOrderRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = simulateOrderRequest.ToWmSimulateOrderRequest();
            LogRequest(request);
            var wmSimulateOrderResponse = _soapStoreFrontWebService.SimulateOrderWebServiceAsync(request).Result;
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
                wmSimulateOrderResponse = _soapStoreFrontWebService.SimulateOrderWebServiceAsync(request).Result;
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
            wmInventoryResponse = _soapStoreFrontWebService.InventoryWebServiceAsync(request).Result;
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
                LogRequest(request);
                wmInventoryResponse = _soapStoreFrontWebService.InventoryWebServiceAsync(request).Result;
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
    
        //Temporarily bringing this back for comparision with the new Boomi version
        public PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            var request = partnerRequest.ToWmPartnerRequest();
            LogRequest(request);
            var wmPartnerResponse = _soapStoreFrontWebService.PartnerWebServiceAsync(request).Result;
            LogResponse(wmPartnerResponse);
            return wmPartnerResponse.ToPartnerResponse();

        }

        public ContactCreateClientResponse CreateContact(ContactCreateClientRequest contactCreateRequest)
        {
            return _erpRestGateway.CreateContact(contactCreateRequest);
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
