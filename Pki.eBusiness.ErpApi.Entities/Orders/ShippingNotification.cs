using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;

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

    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationHeaderVersion
    {

        private byte valueField;

        private byte valueField1;

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

        public string WebON { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string CCType { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string CCLast4 { get; set; }
        public string ShipToAttn { get; set; }
        public string SAPON { get; set; }
        public string CustomerPO { get; set; }
        //[DefaultValue(null), XmlElement(IsNullable = true)]
        //public decimal? TotalPrice { get; set; }
        public string PromotionalDiscount { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string OrderType { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string OrderStatus { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string VAT { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string OrderValue { get; set; }

        [System.Xml.Serialization.XmlArrayItemAttribute("Product", IsNullable = false)]
        public ShippingNotificationBodyOrderSummaryProduct[] OrderDetail { get; set; }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ShippingNotificationBodyOrderSummaryProduct
    {

        public string WebLineItemNo { get; set; }
        public string SAPLineOrderNo { get; set; }
        public string Description { get; set; }
        public int QuantityOrdered { get; set; }
        public int QuantityShipped { get; set; }
        public string Carrier { get; set; }
        public string TrackingNO { get; set; }
        public string ShippingPoint { get; set; }
        public string ShipDate { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string VAT { get; set; }
        [DefaultValue(null), XmlElement(IsNullable = true)]
        public string Status { get; set; }

        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id { get; set; }
    }


    public class ShippingNotificationResponse
    {
        public bool EmailSent { get; set; }
        public String ErrorMessage { get; set; }
    }

}
