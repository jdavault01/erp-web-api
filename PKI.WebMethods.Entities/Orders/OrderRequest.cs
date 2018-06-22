using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace PKI.eBusiness.WMService.Entities.Orders
{    
    /// <summary>
    /// Order Request Class
    /// </summary>
    [DataContract]
    public class OrderRequest : EntityBase
    {
        #region Private variables

        [DataMember]
        public OrderRequestHeader OrderRequestHeader { get; set; }
        [DataMember]
        public OrderRequestDetail[] OrderRequestDetail { get; set; }

        #endregion // Private variables
    }
}
