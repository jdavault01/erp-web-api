using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            result.LineItems = new List<OrderErpLineItemResponse>();
            foreach (var itemOut in ORDER_ITEMS_OUT)
            {
                var toAdd = new OrderErpLineItemResponse();
                toAdd.ProductID = itemOut.MATERIAL;
                toAdd.OrderLineNumber = itemOut.ITM_NUMBER;
                toAdd.TaxVAT = itemOut.TX_DOC_CUR;
                toAdd.AdjustedPrice = itemOut.NET_VALUE1;
                toAdd.Availability = new List<AvailabilityErp>();
                toAdd.Availability = ORDER_SCHEDULE_EX.Where(s => s.ITM_NUMBER == itemOut.ITM_NUMBER)
                    .Select(s => new AvailabilityErp(s.CONFIR_QTY, s.REQ_DATE)).ToList();
                result.LineItems.Add(toAdd);
            }
            return result;
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
