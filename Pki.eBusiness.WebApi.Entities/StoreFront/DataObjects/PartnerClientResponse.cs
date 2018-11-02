using System.Collections.Generic;
using System.Runtime.Serialization;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;

namespace Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class PartnerClientResponse : EntityBase
    {
        [DataMember]
        public PartnerResponse PartnerResponse { get; set; }

        public PartnerClientResponse()
        {



        }

    }

    [DataContract]
    public class PartnerResponse : EntityBase
    {
        [DataMember]
        public string ERPHierarchyNumber { get; set; }

        [DataMember]
        public string ERPHierarchyName { get; set; }

        [DataMember]
        public List<Partner> Partners { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        public PartnerResponse() { }

    }
    /// <summary>
    /// Order Response Detail
    /// </summary>
    [DataContract]
    public class PartnerResponseDetail : EntityBase
    {
        #region Properties

        [DataMember]
        public Partner Partner { get; set; }

        #endregion // Properties

    }

    [DataContract]
    public class PartnerResponseHeader : EntityBase
    {
        #region Properties



        #endregion

    }

}
