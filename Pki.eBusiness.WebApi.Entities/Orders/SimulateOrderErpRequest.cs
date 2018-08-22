using System;
using System.Collections.Generic;

namespace Pki.eBusiness.WebApi.Entities.Orders
{
    public class SimulateOrderErpRequest
    {
        //public SalesArea SalesAreaInfo { get; set; }
        //public string Language { get; set; }
        //public int NumberOfItems { get; set; }
        public string SalesOrg { get; set; }
        public DateTime RequestedDate { get; set; }
        public List<string> Partners { get; set; }
        public List<OrderErpLineItem> OrderItems { get; set; }
        //public string PromoCode { get; set; }

    }

    public class OrderErpLineItem
    {
        public int OrderLineNumber { get; set; }
        public string ProductID { get; set; }
        public decimal Quantity { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}
