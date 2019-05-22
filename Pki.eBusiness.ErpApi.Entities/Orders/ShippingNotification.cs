﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pki.eBusiness.ErpApi.Entities.Orders
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ShippingNotification
    {

        private ShippingNotificationHeader headerField;

        private ShippingNotificationBody bodyField;

        /// <remarks/>
        public ShippingNotificationHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                this.headerField = value;
            }
        }

        /// <remarks/>
        public ShippingNotificationBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationHeader
    {

        private ShippingNotificationHeaderVersion versionField;

        private ShippingNotificationHeaderSender senderField;

        /// <remarks/>
        public ShippingNotificationHeaderVersion Version
        {
            get
            {
                return this.versionField;
            }
            set
            {
                this.versionField = value;
            }
        }

        /// <remarks/>
        public ShippingNotificationHeaderSender Sender
        {
            get
            {
                return this.senderField;
            }
            set
            {
                this.senderField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationHeaderVersion
    {

        private byte valueField;

        private byte valueField1;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public byte Value
        {
            get
            {
                return this.valueField1;
            }
            set
            {
                this.valueField1 = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationHeaderSender
    {

        private string logicalIDField;

        private string taskField;

        /// <remarks/>
        public string LogicalID
        {
            get
            {
                return this.logicalIDField;
            }
            set
            {
                this.logicalIDField = value;
            }
        }

        /// <remarks/>
        public string Task
        {
            get
            {
                return this.taskField;
            }
            set
            {
                this.taskField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationBody
    {

        private ShippingNotificationBodyOrderSummary orderSummaryField;

        /// <remarks/>
        public ShippingNotificationBodyOrderSummary OrderSummary
        {
            get
            {
                return this.orderSummaryField;
            }
            set
            {
                this.orderSummaryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationBodyOrderSummary
    {

        private string webONField;

        private string cCTypeField;

        private string cCLast4Field;

        private string shipToAttnField;

        private string sAPONField;

        private string customerPOField;

        private string totalPriceField;

        private string trackingNOField;

        private string promotionalDiscountField;

        private string shippingPointField;

        private string shipDateField;

        private string orderTypeField;

        private string deliveryChargesField;

        private string handlingChargesField;

        private string orderStatusField;

        private string vATField;

        private string orderValueField;

        private ShippingNotificationBodyOrderSummaryProduct[] orderDetailField;

        /// <remarks/>
        public string WebON
        {
            get
            {
                return this.webONField;
            }
            set
            {
                this.webONField = value;
            }
        }

        /// <remarks/>
        public string CCType
        {
            get
            {
                return this.cCTypeField;
            }
            set
            {
                this.cCTypeField = value;
            }
        }

        /// <remarks/>
        public string CCLast4
        {
            get
            {
                return this.cCLast4Field;
            }
            set
            {
                this.cCLast4Field = value;
            }
        }

        /// <remarks/>
        public string ShipToAttn
        {
            get
            {
                return this.shipToAttnField;
            }
            set
            {
                this.shipToAttnField = value;
            }
        }

        /// <remarks/>
        public string SAPON
        {
            get
            {
                return this.sAPONField;
            }
            set
            {
                this.sAPONField = value;
            }
        }

        /// <remarks/>
        public string CustomerPO
        {
            get
            {
                return this.customerPOField;
            }
            set
            {
                this.customerPOField = value;
            }
        }

        /// <remarks/>
        public string TotalPrice
        {
            get
            {
                return this.totalPriceField;
            }
            set
            {
                this.totalPriceField = value;
            }
        }

        /// <remarks/>
        public string TrackingNO
        {
            get
            {
                return this.trackingNOField;
            }
            set
            {
                this.trackingNOField = value;
            }
        }

        /// <remarks/>
        public string PromotionalDiscount
        {
            get
            {
                return this.promotionalDiscountField;
            }
            set
            {
                this.promotionalDiscountField = value;
            }
        }

        /// <remarks/>
        public string ShippingPoint
        {
            get
            {
                return this.shippingPointField;
            }
            set
            {
                this.shippingPointField = value;
            }
        }

        /// <remarks/>
        public string ShipDate
        {
            get
            {
                return this.shipDateField;
            }
            set
            {
                this.shipDateField = value;
            }
        }

        /// <remarks/>
        public string OrderType
        {
            get
            {
                return this.orderTypeField;
            }
            set
            {
                this.orderTypeField = value;
            }
        }

        /// <remarks/>
        public string DeliveryCharges
        {
            get
            {
                return this.deliveryChargesField;
            }
            set
            {
                this.deliveryChargesField = value;
            }
        }

        /// <remarks/>
        public string HandlingCharges
        {
            get
            {
                return this.handlingChargesField;
            }
            set
            {
                this.handlingChargesField = value;
            }
        }

        /// <remarks/>
        public string OrderStatus
        {
            get
            {
                return this.orderStatusField;
            }
            set
            {
                this.orderStatusField = value;
            }
        }

        /// <remarks/>
        public string VAT
        {
            get
            {
                return this.vATField;
            }
            set
            {
                this.vATField = value;
            }
        }

        /// <remarks/>
        public string OrderValue
        {
            get
            {
                return this.orderValueField;
            }
            set
            {
                this.orderValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Product", IsNullable = false)]
        public ShippingNotificationBodyOrderSummaryProduct[] OrderDetail
        {
            get
            {
                return this.orderDetailField;
            }
            set
            {
                this.orderDetailField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationBodyOrderSummaryProduct
    {

        private string carrierField;

        private string webLineItemNoField;

        private string sAPLineOrderNoField;

        private string descriptionField;

        private int quantityOrderedField;

        private int quantityShippedField;

        private string adjustedUnitPriceField;

        private string vATField;

        private string statusField;

        private string idField;

        private string shipDate;

        private string trackingNumber;

        /// <remarks/>
        public string Carrier
        {
            get
            {
                return this.carrierField;
            }
            set
            {
                this.carrierField = value;
            }
        }


        /// <remarks/>
        public string WebLineItemNo
        {
            get
            {
                return this.webLineItemNoField;
            }
            set
            {
                this.webLineItemNoField = value;
            }
        }

        /// <remarks/>
        public string SAPLineOrderNo
        {
            get
            {
                return this.sAPLineOrderNoField;
            }
            set
            {
                this.sAPLineOrderNoField = value;
            }
        }

        /// <remarks/>
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        public int QuantityOrdered
        {
            get
            {
                return this.quantityOrderedField;
            }
            set
            {
                this.quantityOrderedField = value;
            }
        }

        /// <remarks/>
        public int QuantityShipped
        {
            get
            {
                return this.quantityShippedField;
            }
            set
            {
                this.quantityShippedField = value;
            }
        }

        /// <remarks/>
        public string AdjustedUnitPrice
        {
            get
            {
                return this.adjustedUnitPriceField;
            }
            set
            {
                this.adjustedUnitPriceField = value;
            }
        }

        /// <remarks/>
        public string VAT
        {
            get
            {
                return this.vATField;
            }
            set
            {
                this.vATField = value;
            }
        }

        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }

        public string ShipDate
        {
            get
            {
                return this.shipDate;
            }
            set
            {
                this.shipDate = value;
            }
        }
        public string TrackingNumber
        {
            get
            {
                return this.trackingNumber;
            }
            set
            {
                this.trackingNumber = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }


    public class ShippingNotificationResponse
    {
        public bool EmailSent { get; set; }
        public String ErrorMessage { get; set; }
    }

}
