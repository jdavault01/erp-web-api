using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pki.eBusiness.WebApi.DataAccess.Extensions;
using Pki.eBusiness.WebApi.Entities.Orders;

namespace Pki.eBusiness.WebApi.DataAccess.ErpApi.Model
{
    public partial class SimulateOrderRequestRoot
    {
        public SimulateOrderRequestRoot(SimulateOrderErpRequest req)
        {
            ORDER_ITEMS_IN = req.OrderItems.Select(o => new SimulateOrderRequestRootORDERITEMSIN(o)).ToList();
            ORDER_PARTNERS = req.Partners.Select(p => new SimulateOrderRequestRootORDERPARTNERS(p)).ToList();
            ORDER_HEADER_IN = new List<SimulateOrderRequestRootORDERHEADERIN>();
            ORDER_HEADER_IN.Add(new SimulateOrderRequestRootORDERHEADERIN(req));
        }
    }

    public partial class SimulateOrderResponseRoot
    {
        public SimulateOrderErpResponse ToResponse()
        {
            var result = new SimulateOrderErpResponse();
            result.PaymentTerms = PAYTEXT;
            result.INCOCode = SOLD_TO_PARTY?.First()?.INCOTERMS1 + " ";
            result.INCOTerms = SOLD_TO_PARTY?.First()?.INCOTERMS2;
            result.Currency = SOLD_TO_PARTY?.First()?.CURRENCY;
            result.ShippingCost =
                ZWEB_ORDER_STATUS.Sum(s => s.FREIGHT.ToDecimal() + s.HANDLING.ToDecimal());
            result.LineItems = ORDER_ITEMS_OUT.Select(i =>
            {
                result.OrderTotal += i.NETVALUE1.ToDecimal();
                return i.ToResponse(ORDER_SCHEDULE_EX, ZWEB_ORDER_STATUS);
            }).ToList();
            return result;
        }
    }

    public partial class SimulateOrderResponseRootORDERITEMSOUT
    {
        public OrderErpLineItemResponse ToResponse(List<SimulateOrderResponseRootORDERSCHEDULEEX> ORDER_SCHEDULE_EX,
            List<SimulateOrderResponseRootZWEBORDERSTATUS> zwebOrderStatus)
        {
            var toAdd = new OrderErpLineItemResponse();
            int itemNumber = Int32.Parse(ITM_NUMBER) / 100;
            toAdd.ProductID = MATERIAL;
            toAdd.OrderLineNumber = itemNumber;
            toAdd.ShippingPoint = zwebOrderStatus.Where(z => z.ITM_NUMBER == ITM_NUMBER).Select(z => z.SHIP_POINT).FirstOrDefault();
            toAdd.Quantity = REQ_QTY.ToDecimal();
            toAdd.TaxVAT = TX_DOC_CUR.ToDecimal();
            toAdd.AdjustedPrice = SUBTOTAL1.ToDecimal() / toAdd.Quantity;
            toAdd.Availability = ORDER_SCHEDULE_EX.Where(s => s.ITM_NUMBER == ITM_NUMBER)
                .Select(s => new AvailabilityErp(s.CONFIR_QTY, s.REQ_DATE)).ToList();
            return toAdd;
        }
    }

    public partial class SimulateOrderRequestRootORDERHEADERIN
    {
        public SimulateOrderRequestRootORDERHEADERIN(SimulateOrderErpRequest req)
        {
            DOC_TYPE = "ZWEB";
            DISTR_CHAN = "01";
            DIVISION = "02";
            PURCH_DATE = req.RequestedDate.ToString("yyyyMMdd");
            PO_METHOD = "INET";
            COLLECT_NO = "";
            PMNTTRMS = "";
            COMPL_DLV = "";
            SHIP_COND = "";

        }
    }

    public partial class SimulateOrderRequestRootORDERPARTNERS
    {
        public SimulateOrderRequestRootORDERPARTNERS(string partnerId)
        {
            if (!string.IsNullOrEmpty(partnerId) && partnerId.Length == 10)
            {
                PARTN_ROLE = partnerId.IndexOf("1") == 1 ? "WE" : "RG";
                PARTN_NUMB = partnerId;
            }
        }
    }

    public partial class SimulateOrderRequestRootORDERITEMSIN
    {
        public SimulateOrderRequestRootORDERITEMSIN(OrderErpLineItem item)
        {
            ITM_NUMBER = (item.OrderLineNumber * 100).ToString();
            MATERIAL = item.ProductID;
            REQ_QTY = (item.Quantity * 1000).ToString();
            REQ_DATE = item.RequestedDate.ToString("yyyyMMdd");
        }
    }
}
