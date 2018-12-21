using System;
using System.Collections.Generic;

namespace Pki.eBusiness.ErpApi.Entities.Orders
{
    public class SimulateOrderErpRequest
    {
        public List<OrderErpLineItem> OrderItems { get; set; }
        public string PromoCode { get; set; }
        public string SalesOrg { get; set; }
        public string Language { get; set; }
        public string ShipTo { get; set; }
        public string BillTo { get; set; }
        public List<string> Partners => new List<String>
        {
            ShipTo,
            BillTo
        };
        //TODO:  Ask Piotr why this was added
        //public DateTime RequestedDate { get; set; }

    }

    public class OrderErpLineItem
    {
        public int OrderLineNumber { get; set; }
        public string ProductID { get; set; }
        public decimal Quantity { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}
