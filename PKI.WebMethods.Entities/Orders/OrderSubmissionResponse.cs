using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace PKI.eBusiness.WMService.Entities.Orders
{
    [XmlRoot("xmlResponse")]
    [DataContract(Name = "xmlResponse", Namespace = "")]
    public class OrderSubmissionResponse : EntityBase
    {
        [XmlElement(ElementName = "code", Type = typeof(int))]
        [DataMember(Name = "code")]
        public int Code { get; set; }

        [DataMember(Name="Message")]
        public string Message { get; set; }
    }
}