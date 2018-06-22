﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using PKI.eBusiness.WMWebApi.BusinessServices.Models.StoreFront.Accounts;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{

    [DataContract]
    public class SimplePartnerRequest
    {
        [DataMember]
        public string PartnerId { get; set; }
        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }
    }

    /// <summary>
    /// Order Request Class
    /// </summary>
    [DataContract]
    public class PartnerRequest : EntityBase
    {
        #region Private variables

        [DataMember]
        public PartnerHeader Header { get; set; }

        [DataMember]
        public PartnerRequestHeader RequestHeader { get; set; }

        [DataMember]
        public PartnerRequestDetail[] RequestDetail { get; set; }

        #endregion // Private variables
    }

    [DataContract]
    public class PartnerHeader : EntityBase
    {
        [DataMember]
        [XmlElement(ElementName = "Version")]
        public PartnerVersion VersionNumber { get; set; }

        [DataMember]
        public PartnerSender Sender { get; set; }

    }

    [DataContract]
    public class PartnerVersion
    {

        [DataMember]
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        [DataMember]
        [XmlText]
        public string Data { get; set; }

        public PartnerVersion()
        {

        }
        public PartnerVersion(string value, string data)
        {
            this.Value = value;
            this.Data = data;
        }

    }

    [DataContract]
    public class PartnerSender : EntityBase
    {
        [DataMember]
        public string LogicalID { get; set; }

        [DataMember]
        public string Task { get; set; }

        public PartnerSender()
        {

        }
        public PartnerSender(string logicalId, string task)
        {
            this.LogicalID = logicalId;
            this.Task = task;
        }
    }
    [DataContract]
    public class PartnerRequestHeader : EntityBase
    {
        #region Properties

        [DataMember]
        public SalesArea SalesAreaInfo { get; set; }

        #endregion

    }


    /// <summary>
    /// Order Request Detail
    /// </summary>
    [DataContract]
    public class PartnerRequestDetail : EntityBase
    {
        #region Properties

        [DataMember]
        public List<Partner> PartnerInfo { get; set; }

        #endregion // Properties

    }
}
