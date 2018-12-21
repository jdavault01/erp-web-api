using System.Collections.Generic;
using System.Xml.Serialization;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{

    
    public class SimplePartnerRequest
    {
        public SimplePartnerRequest(string accountNumber, string salesOrg)
        {
            this.PartnerId = accountNumber;
            this.SalesAreaInfo = new SalesArea(salesOrg);
        }

        
        public string PartnerId { get; set; }
        
        public SalesArea SalesAreaInfo { get; set; }
    }

    /// <summary>
    /// Order Request Class
    /// </summary>
    
    public class PartnerRequest : EntityBase
    {
        #region Private variables

        
        public PartnerHeader Header { get; set; }

        
        public PartnerRequestHeader RequestHeader { get; set; }

        
        public PartnerRequestDetail[] RequestDetail { get; set; }

        #endregion // Private variables
    }

    
    public class PartnerHeader : EntityBase
    {
        
        [XmlElement(ElementName = "Version")]
        public PartnerVersion VersionNumber { get; set; }

        
        public PartnerSender Sender { get; set; }

    }

    
    public class PartnerVersion
    {

        
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }

        
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

    
    public class PartnerSender : EntityBase
    {
        
        public string LogicalID { get; set; }

        
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
    
    public class PartnerRequestHeader : EntityBase
    {
        #region Properties

        
        public SalesArea SalesAreaInfo { get; set; }

        #endregion

    }


    /// <summary>
    /// Order Request Detail
    /// </summary>
    
    public class PartnerRequestDetail : EntityBase
    {
        #region Properties

        
        public List<Partner> PartnerInfo { get; set; }

        #endregion // Properties

    }
}
