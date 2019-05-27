using Pki.eBusiness.ErpApi.Entities.Orders;
using Pki.eBusiness.ErpApi.Entities.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using Pki.eBusiness.ErpApi.DataAccess.Client;

namespace Pki.eBusiness.ErpApi.DataAccess.AtgApi
{
    public partial class OrderApi
    {
        public OrderApi(ERPRestSettings erpRestSettings)
        {
            var apiKey = new Dictionary<string, string>
            {
                { "x-api-key", erpRestSettings.AtgApiKey }
            };
            var atgApiConfiguration = new Configuration()
            {
                BasePath = erpRestSettings.AtgBaseUrl,
                ApiKey = apiKey
            };
            this.Configuration = atgApiConfiguration;

        }
    }
}

namespace Pki.eBusiness.ErpApi.DataAccess.Model
{
    public partial class ShippingNotificationOrderDto
    {
        public ShippingNotificationOrderDto(ShippingNotification shippingNotification)
        {
            var body = shippingNotification.Body;
            var summary = body.OrderSummary;
            var orderDetails = summary.OrderDetail;
            var orerItems = new ShippingNotificationValidator();

            foreach (var item in orderDetails)
            {
                var newItem = new ShippingNotificationLineItemDto(item.Carrier, item.Description, item.id, item.QuantityOrdered,
                    item.QuantityShipped, Int32.Parse(item.SAPLineOrderNo), item.ShipDate, item.TrackingNumber);
                orerItems.Add(newItem);
            }

            this.CcLast4 = summary.CCLast4;
            this.CcType = summary.CCType;
            this.CustomerPO = summary.CustomerPO;
            this.SapON = summary.SAPON;
            this.ShipToAttn = summary.ShipToAttn;
            this.WebON = summary.WebON;
            this.OrderItems = orerItems;
        }
    }
}
