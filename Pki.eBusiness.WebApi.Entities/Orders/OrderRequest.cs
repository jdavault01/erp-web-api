using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.Orders
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
