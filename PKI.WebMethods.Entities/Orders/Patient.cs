using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PKI.eBusiness.WMService.Entities.Orders
{
    [DataContract]
    public class Patient
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string DOB { get; set; }

        [DataMember]
        public string KitNumber { get; set; }

        [DataMember]
        public string SampleType { get; set; }

        [DataMember]
        public string ProductName { get; set; }
    }
}
