﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
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
        #region Private variables

        [DataMember]
        public PartnerResponseHeader PartnerResponseHeader { get; set; }

        [DataMember]
        public List<PartnerResponseDetail> PartnerResponseDetails { get; set; }

        #endregion // Private variables
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

        [DataMember]
        public string ERPHierarchyNumber { get; set; }

        [DataMember]
        public string ERPHierarchyName { get; set; }

        #endregion

    }

}
