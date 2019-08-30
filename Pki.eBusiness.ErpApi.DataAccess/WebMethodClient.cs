using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;
using Pki.eBusiness.ErpApi.DataAccess.Models.Orders;
using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using Pki.eBusiness.ErpApi.Entities.Constants;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.ErpApi.Entities.ProductCatalog;
using Pki.eBusiness.ErpApi.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using static System.String;
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
        private readonly StorefrontWebServices_PortType _soapStoreFrontWebService;
        private readonly IERPRestGateway _erpRestGateway;
        private readonly ILogger _logger;
        private string _baseUrl;

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="soapClient"></param>
        public WebMethodClient(ERPRestSettings erpSettings, IERPRestGateway erpRestGateway, ILogger<WebMethodClient> logger)
        {
            _erpRestGateway = erpRestGateway;
            _soapStoreFrontWebService = new StorefrontWebServices_PortTypeClient(StorefrontWebServices_PortTypeClient.EndpointConfiguration.services_StorefrontWebServices_Port, 
                                        new EndpointAddress($"{erpSettings.BaseUrl}/ws/services.StorefrontWebServices/services_StorefrontWebServices_Port"));
            _logger = logger;
            _baseUrl = erpSettings.BaseUrl;
        }


        #region Public methods

        private void LogInputRequest(string xml)
        {
            Log(xml.Replace("\r\n", ""));
            Log(ErrorMessages.INVOKING_SERVICE);
        }

        public OrderDetailResponse GetOrderDetails(OrderSummaryLookUpRequest request)
        {
            var webServiceDetailRequest = new OrderDetailRequest(request.SAPOrderNumber).ToRequest();
            Log(webServiceDetailRequest.xmlRequest.Replace("\r\n", ""));
            Log(ErrorMessages.INVOKING_SERVICE);
            OrderInfoWebServiceRequest DetailReq = new OrderInfoWebServiceRequest(webServiceDetailRequest.xmlRequest, webServiceDetailRequest.node);
            var webOrderDetailResponse = new OrderInfoResponse
            {
                xmlResponse = _soapStoreFrontWebService.OrderInfoWebServiceAsync(DetailReq).Result.xmlResponse
            };

            Log(webOrderDetailResponse.xmlResponse);
            var orderSummaryResponse = GetOrderSummary(request);

            var orderDetailResponse = webOrderDetailResponse.ToOrderDetailResponse();
            orderDetailResponse.AddOrderSummary(orderSummaryResponse);
            return orderDetailResponse;

        }

        private OrderSummaryResponse GetOrderSummary(OrderSummaryLookUpRequest request)
        {
            var webServiceOrderSummaryRequest = new OrderSummaryRequest(request).ToRequest();
            Log(webServiceOrderSummaryRequest.xmlRequest.Replace("\r\n", ""));
            Log(ErrorMessages.INVOKING_SERVICE);
            OrderInfoWebServiceRequest DetailReq = new OrderInfoWebServiceRequest(webServiceOrderSummaryRequest.xmlRequest, webServiceOrderSummaryRequest.node);
            var webOrderSummaryResponse = new OrderInfoResponse
            {
                xmlResponse = _soapStoreFrontWebService.OrderInfoWebServiceAsync(DetailReq).Result.xmlResponse
            };

            Log(webOrderSummaryResponse.xmlResponse);
            return webOrderSummaryResponse.ToOrderLookUpResponse(); 

        }

        #endregion

        /// <summary>
        /// Price Request/Response
        /// </summary>
        /// <param name="priceWmRequest"></param>
        /// <returns></returns>
        public PriceResponse GetPrice(PriceRequest priceWmRequest)
        {
            var priceResponse = new PriceResponse();
            var request = priceWmRequest.ToWmPriceRequest();
            LogRequest(request,"PriceRequest");
            var wmPriceResponse = _soapStoreFrontWebService.PriceWebServiceAsync(request).Result;
            LogResponse(wmPriceResponse);

            var failedProducts = new List<FailedProduct>();

            while (wmPriceResponse.ErrorReturn != null)
            {
                var productId = GetProductFromMaterialErrorMessage(wmPriceResponse.ErrorReturn.Error);
                if (productId == Empty)
                {
                    priceResponse.ErrorMessage = wmPriceResponse.ErrorReturn.Error;
                    return priceResponse;
                }

                Log($"{ErrorMessages.ERRORS_CONTAINED_IN_RESPONSE} for product {productId}");

                var failedProduct = new FailedProduct { ErrorMessage = wmPriceResponse.ErrorReturn.Error, PartNumber = productId };
                failedProducts.Add(failedProduct);

                var newProductLists = request.PricingRequest.ProductList.Where(val => val.ProductID != productId).ToArray();
                //I don't see why or how this will be needed (if no edge case is reported by 1/1/2020, remove this line altogether)
                //if (newProductLists.Length == request.PricingRequest.ProductList.Length) break;

                request.PricingRequest.ProductList = newProductLists;
                if (newProductLists.Length == 0) break;

                Log(InfoMessages.SEND_DATA_CORRECTED_INPUT_REQUEST);
                LogRequest(request, "Additional PriceRequests (to handle failed products");
                wmPriceResponse = _soapStoreFrontWebService.PriceWebServiceAsync(request).Result;
                LogResponse(wmPriceResponse);
            }

            priceResponse = wmPriceResponse.ToPriceResponse();
            
            if (failedProducts.Count == 0) return priceResponse;
            priceResponse.FailedProducts = failedProducts;
            priceResponse.ErrorMessage = "We were not able to obtain prices for all requested products.  Please see list of failed products.";
            return priceResponse;
        }


        public CreateOrderResponse CreateOrder(CreateOrderRequest createOrderRequest)
        {
            var request = createOrderRequest.ToWmOrderRequest();
            //If this is a CC transaction mask the CC before logging
            if (request.OrderRequest.OrderRequestHeader.CreditCard != null)
            {
                var maskedRequestLogging = createOrderRequest.ToWmOrderRequest();
                var maskedCardNumber = MaskCreditCardNumber(maskedRequestLogging.OrderRequest.OrderRequestHeader.CreditCard.CreditCardNumber);
                maskedRequestLogging.OrderRequest.OrderRequestHeader.CreditCard.CreditCardNumber = maskedCardNumber;
                LogRequest(maskedRequestLogging, "CreateOrder");
            }
            else
            {
                LogRequest(request, "CreateOrder");
            }

            var wmOrderResponse = _soapStoreFrontWebService.OrderWebServiceAsync(request).Result;
            LogResponse(wmOrderResponse);
            return wmOrderResponse.ToOrderResponse();
        }

        private string MaskCreditCardNumber(string cardNumber)
        {
            //If this is a token just allow it to be logged
            var regex = new Regex(@"\w{2}\-\w*\-\w{4}");
            var match = regex.Match(cardNumber);
            if (match.Success)
            {
                return cardNumber;
            }

            var maskedPan = cardNumber.Aggregate(Empty, (value, next) =>
            {
                if (value.Length >= 4 && value.Length < cardNumber.Length - 4)
                {
                    next = '*';
                }
                return value + next;
            });

            return maskedPan;
        }

        public SimulateOrderResponse SimulateOrder(SimulateOrderRequest simulateOrderRequest)
        {
            var endPoint = _soapStoreFrontWebService.ToString();
            var request = simulateOrderRequest.ToWmSimulateOrderRequest();
            LogRequest(request, "SimulateOrder");
            var wmSimulateOrderResponse = _soapStoreFrontWebService.SimulateOrderWebServiceAsync(request).Result;
            var orderResponseError = "We were not able to obtain response items for all requested products.  Please see list of failed inventory items.";
            LogResponse(wmSimulateOrderResponse);
            var failedItems = new List<FailedItem>();
            while (ContainsSAPError(wmSimulateOrderResponse))
            {
                var errorMessage = wmSimulateOrderResponse.ErrorResponse.ErrorResponse1.Body[0].Error;
                string productId = LogFailedItem(failedItems, errorMessage);

                //if we have an error condition but no failed products, we have an order order level issue, we can return
                if (productId == Empty)
                {
                    failedItems.Clear();
                    var failedItem = new FailedItem { ErrorMessage = errorMessage, ProductId = "Order Level Exception, not applicable" };
                    failedItems.Add(failedItem);
                    var orderLevelFailureResponse = new SimulateOrderResponse
                    {
                        FailedItems = failedItems,
                        ErrorMessage = "We were not able to obtain response items for all requested products.Please see list of failed inventory items."
                    };
                    return orderLevelFailureResponse;
                }

                var newItemsList = request.OrderRequest.OrderRequest.Body[0].OrderRequestDetail.Where(val => val.ProductID != productId).ToArray();
                request.OrderRequest.OrderRequest.Body[0].OrderRequestDetail = newItemsList;

                //We had an error condition for a single product .. we need to collect that error and return
                if (newItemsList.Length == 0)
                {
                    var orderLevelFailureResponse = new SimulateOrderResponse
                    {
                        FailedItems = failedItems,
                        ErrorMessage = orderResponseError
                    };
                    return orderLevelFailureResponse;
                }

                LogRequest(request,"Addtional SimulateOrder (to handle failed products");
                wmSimulateOrderResponse = _soapStoreFrontWebService.SimulateOrderWebServiceAsync(request).Result;
                LogResponse(wmSimulateOrderResponse);

            }

            var simulateOrderResponse = wmSimulateOrderResponse.ToSimulateOrderResponse();

            if (failedItems.Count == 0) return simulateOrderResponse;
            simulateOrderResponse.FailedItems = failedItems;
            simulateOrderResponse.ErrorMessage = orderResponseError;
            return simulateOrderResponse;
        }


        private static bool ContainsSAPError(SimulateOrderWebServiceResponse1 wmSimulateOrderResponse)
        {
            return wmSimulateOrderResponse.ErrorResponse != null && wmSimulateOrderResponse.ErrorResponse.ErrorResponse1.Body[0].Error != Empty;
        }

        public InventoryResponse GetInventory(InventoryRequest inventoryWmRequest)
        {
            var inventoryResponse = new InventoryResponse();
            var request = inventoryWmRequest.ToWmInventoryRequest();
            LogRequest(request, "GetInventory");
            var wmInventoryResponse = _soapStoreFrontWebService.InventoryWebServiceAsync(request).Result;
            LogResponse(wmInventoryResponse);

            var failedInventoryItems = new List<FailedItem>();

            while (wmInventoryResponse.ErrorResponse != null)
            {
                var errorMessage = wmInventoryResponse.ErrorResponse.ErrorResponse1.Body[0].Error;
                var productId = LogFailedItem(failedInventoryItems, errorMessage);

                if (productId == Empty)
                {
                    inventoryResponse.FailedItems = failedInventoryItems;
                    inventoryResponse.ErrorMessage = "We were not able to obtain response items for all requested products.  Please see list of failed inventory items.";
                    return inventoryResponse;
                }

                var newItemsList = request.InventoryRequest.InventoryRequestDetail.Where(val => val.ProductID != productId).ToArray();
                request.InventoryRequest.InventoryRequestDetail = newItemsList;
                if (newItemsList.Length == 0) break;

                LogRequest(request,"Additional GetInventory (to handle failed products");
                wmInventoryResponse = _soapStoreFrontWebService.InventoryWebServiceAsync(request).Result;
                LogResponse(wmInventoryResponse);

            }

            inventoryResponse = wmInventoryResponse.ToInventoryResponse();
            if (failedInventoryItems.Count == 0) return inventoryResponse;
            inventoryResponse.FailedItems = failedInventoryItems;
            inventoryResponse.ErrorMessage = "We were not able to obtain response items for all requested products.  Please see list of failed inventory items.";
            return inventoryResponse;
        }

        private string LogFailedItem(List<FailedItem> failedItems, string errorMessage)
        {
            if (IsNullOrEmpty(errorMessage))
                return errorMessage;

            var productId = GetProductFromMaterialErrorMessage(errorMessage);
            if (productId == Empty)
            {
                Log(
                    $"{ErrorMessages.ERRORS_CONTAINED_IN_RESPONSE} - Unable to get product from error return object");
            }

            Log($"{ErrorMessages.ERRORS_CONTAINED_IN_RESPONSE} for product {productId}");

            var failedItem = new FailedItem { ErrorMessage = errorMessage, ProductId = productId };
            failedItems.Add(failedItem);
            return productId;
        }
    
        //Temporarily bringing this back for comparision with the new Boomi version
        public PartnerResponse GetPartnerDetails(SimplePartnerRequest partnerRequest)
        {
            var request = partnerRequest.ToWmPartnerRequest();
            LogRequest(request, "GetPartnerDetails");
            var wmPartnerResponse = _soapStoreFrontWebService.PartnerWebServiceAsync(request).Result;
            LogResponse(wmPartnerResponse);
            return wmPartnerResponse.ToPartnerResponse();

        }

        public ContactCreateClientResponse CreateContact(ContactCreateClientRequest request)
        {
            return _erpRestGateway.CreateContact(request);
        }

        private void LogRequest<T>(T request, string nameOfMethod)
        {
            string jsonRequest = request.SerializeToJson(OutPutType.Unformatted,true);
            Log($"{ErrorMessages.SEND_DATA_INPUT_REQUEST} for {nameOfMethod} using {_baseUrl}");
            Log(jsonRequest.Replace("\r\n", ""));
            Log(InfoMessages.INVOKING_SERVICE_REQUEST);
        }

        private void LogResponse<T>(T response)
        {
            string jsonResponse = response.SerializeToJson(OutPutType.Formatted);
            var newJsonResponse = JsonConvert.SerializeObject(response, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            Log(InfoMessages.RESPONSE_FROM_SERVICE);
            Log(jsonResponse);
        }


        private string GetProductFromMaterialErrorMessage(string errorMessage)
        {
            var match = Regex.Match(errorMessage, @"material ([A-Za-z0-9_\-]+)", RegexOptions.IgnoreCase);
            return match.Success ? match.Groups[1].Value : Empty;
        }


        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        private void Log(string message)
        {
            _logger.LogInformation(message);
        }
    }
}
