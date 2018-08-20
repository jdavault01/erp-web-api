using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ClientModels = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using ServiceModels = PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using StorefrontInventoryRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.InventoryRequest;
using StorefrontPriceRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.PriceRequest;
using WebMethodsInventoryResponse1 = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.InventoryWebServiceResponse1;
using WebMethodsPriceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.PriceWebServiceResponse1;
using StorefrontSimulateOrderRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.SimulateOrderRequest;
using SimulateOrderWebServiceResponse1 = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.SimulateOrderWebServiceResponse1;
using StorefrontCreateOrderRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.CreateOrderRequest;
using OrderWebServiceResponse1 = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.OrderWebServiceResponse1;


namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{
    public static class CatalogExtensions
    {
        public static ServiceModels.PriceWebServiceRequest ToWmPriceRequest(this StorefrontPriceRequest request)
        {
            return new PriceServiceRequest(request).PriceWebServiceRequest;
        }

        public static ClientModels.PriceResponse ToPriceResponse(this WebMethodsPriceResponse response)
        {
            return new ClientModels.PriceClientResponse(response).PriceResponse;
        }

        public static ServiceModels.InventoryWebServiceRequest ToWmInventoryRequest(this StorefrontInventoryRequest request)
        {
            return new InventoryServiceRequest(request).WebServiceRequest;
        }

        public static ClientModels.InventoryResponse ToInventoryResponse(this WebMethodsInventoryResponse1 response)
        {
            return new ClientModels.InventoryClientResponse(response).InventoryResponse;
        }

        public static ServiceModels.OrderWebServiceRequest ToWmOrderRequest(this StorefrontCreateOrderRequest request)
        {
            return new CreateOrderServiceRequest(request).OrderWebServiceRequest;
        }

        public static ClientModels.CreateOrderResponse ToOrderResponse(this OrderWebServiceResponse1 response)
        {
            return new ClientModels.OrderClientResponse(response).OrderResponse;
        }

        public static ServiceModels.SimulateOrderWebServiceRequest ToWmSimulateOrderRequest(this StorefrontSimulateOrderRequest request)
        {
            return new SimulateOrderServiceRequest(request).SimulateOrderWebServiceRequest;
        }

        public static ClientModels.SimulateOrderResponse ToSimulateOrderResponse(this SimulateOrderWebServiceResponse1 response)
        {
            return new ClientModels.SimulateOrderClientResponse(response).SimulateOrderResponse;
        }

    }
}
