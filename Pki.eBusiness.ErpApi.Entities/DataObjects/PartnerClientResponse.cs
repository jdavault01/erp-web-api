using System.Collections.Generic;
using Pki.eBusiness.ErpApi.Entities.Account;

namespace Pki.eBusiness.ErpApi.Entities.DataObjects
{
    
    public class PartnerClientResponse : EntityBase
    {
        
        public PartnerResponse PartnerResponse { get; set; }

        public PartnerClientResponse()
        {



        }

    }

    
    public class PartnerResponse : EntityBase
    {
        
        public string ERPHierarchyNumber { get; set; }

        
        public string ERPHierarchyName { get; set; }

        
        public List<Partner> Partners { get; set; }

        
        public string ErrorMessage { get; set; }

        public PartnerResponse() { }

    }
    /// <summary>
    /// Order Response Detail
    /// </summary>
    
    public class PartnerResponseDetail : EntityBase
    {
        #region Properties

        
        public Partner Partner { get; set; }

        #endregion // Properties

    }

    
    public class PartnerResponseHeader : EntityBase
    {
        #region Properties



        #endregion

    }

}
