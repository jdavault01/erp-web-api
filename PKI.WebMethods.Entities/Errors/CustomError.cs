using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Specialized;

namespace PKI.eBusiness.WMService.Entities.Errors
{
    /// <summary>
    /// Process Order Submission Fault
    /// </summary>
    [DataContract]
    public class CustomError
    {
        #region Properties

        [DataMember]
        public string ErrorMessage { get; set; }

        #endregion // Properties
    }
}