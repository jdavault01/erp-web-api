using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PKI.eBusiness.WMService.Entities.Orders
{    
    /// <summary>
    /// Order Entity Class
    /// </summary>
    [DataContract]
    public class Order : EntityBase
    {
        #region Properties

        [DataMember]
        public OrderRequest OrderRequest { get; set; }
        [DataMember]
        public string CustomerID { get; set; }
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public string Encoding { get; set; }

        #endregion // Properties
    }
}
