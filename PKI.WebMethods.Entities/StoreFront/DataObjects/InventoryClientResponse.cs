using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;
using WebMethodsInventoryResponse1 = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.InventoryWebServiceResponse1;
//using WebMethodsInventoryResponse1 = PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices.InventoryWebServiceResponse1;
namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class InventoryClientResponse
    {
        [DataMember]
        public String ErrorResponse { get; set; }

        public InventoryResponse InventoryResponse { get; set; }

        public InventoryClientResponse(WebMethodsInventoryResponse1 response)
        {
            if (response.InventoryResponse == null)
            {
                InventoryResponse = new InventoryResponse();
                return;
            }
            InventoryResponse = new InventoryResponse
            {
                InventoryResponseItems = new InventoryResponseItem[response.InventoryResponse.InventoryResponseDetail.Length]
            };

            int itemNum = 0;
            foreach (var serviceInventoryResponseDetail in response.InventoryResponse.InventoryResponseDetail)
            {
                //Values comes in as a string with decimal formatting, e.g "1.00"
                var quantity = Convert.ToDecimal(serviceInventoryResponseDetail.Quantity, CultureInfo.InvariantCulture);
                var inventoryResponseDetail = new InventoryResponseItem
                {
                    OrderLineNumber = serviceInventoryResponseDetail.OrderLineNumber,
                    ProductId = serviceInventoryResponseDetail.ProductID,
                    Quantity = Convert.ToInt16(quantity),
                    ShippingPoint = serviceInventoryResponseDetail.ShippingPoint,
                    Availabilities = new Availability[serviceInventoryResponseDetail.ItemDetail.Length]
                };

                var i = 0;
                foreach (var avaialblity in serviceInventoryResponseDetail.ItemDetail.Select(itemDetail => new Availability
                {
                    AvailableDate = itemDetail.AvailableDate,
                    AvailableQty = Convert.ToDecimal(itemDetail.AvailableQty, CultureInfo.InvariantCulture)
                }))
                {
                    inventoryResponseDetail.Availabilities[i] = avaialblity;
                    i++;
                }

                InventoryResponse.InventoryResponseItems[itemNum] = inventoryResponseDetail;
                itemNum++;

            }
        }

    }

    [DataContract]
    public class InventoryResponse
    {
        [DataMember]
        public InventoryResponseItem[] InventoryResponseItems { get; set; }

        [DataMember]
        public String ErrorMessage { get; set; }

        [DataMember]
        public List<FailedItem> FailedItems { get; set; }

    }

    [DataContract]
    public class FailedItem : InventoryItem
    {
        [DataMember]
        public string ErrorMessage { get; set; }
    }

    [DataContract]
    public class InventoryResponseItem : InventoryItem
    {
        [DataMember]
        public String ShippingPoint { get; set; }

        [DataMember]
        public string OrderLineNumber { get; set; }

        [DataMember]
        [JsonProperty(PropertyName = "Availability")]
        public Availability[] Availabilities { get; set; }

    }

    [DataContract]
    public class InventoryItem
    {
        [DataMember]
        public string ProductId { get; set; }

        [DataMember]
        public decimal Quantity { get; set; }

    }
}
