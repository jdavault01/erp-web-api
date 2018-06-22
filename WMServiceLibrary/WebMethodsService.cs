using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace WMServiceLibrary
{
    [ServiceBehavior(Namespace = "http://npsv04.perkinelmer.com/PKIPediatrix/flows/ProcessPediatrixOrderService")]
    public class WebMethodsService: ProcessPediatrixOrderService_PortType
    {
        public void ProcessFormRequest()
        {
            throw new NotImplementedException();
        }

        public ProcessPediatrixOrderResponse ProcessPediatrixOrder(ProcessPediatrixOrderRequest request)
        {
            
            ProcessPediatrixOrderService_PortTypeClient client = new ProcessPediatrixOrderService_PortTypeClient();

            Pediatrix pediatrix = new Pediatrix();
            OrderRequest order = new OrderRequest();
            OrderRequestHeader header = new OrderRequestHeader();
            header.RequestDate = "20130326";
            header.RequestTime = "8:28:49 AM";
            header.RequestType = "ORDER";
            header.FirstName = "Test";
            header.LastName = "Test";
            header.Address = "1000 Test St";
            header.AptSuite = "";
            header.City = "Waltham";
            header.State = "MA";
            header.Zip = "05875";
            header.Telephone = "465346435";
            header.Email = "Rajyalakshmi.Mylavarapu@perkinelmer.com";
            header.NumOfChildren = "1";
            header.Questions = "Customer order 2001883 on Mar  26 2013  8:28AM for Products: Qty: 1 Severe Combined Immunodeficiency Screening Packet (SCID ONLY)   CC auth is 646PNI,ref nbr is V19A4B32EB8B,type is Visa,last four is 1111,exp is 03/14";
            header.HeardAboutUs = "Other";
            header.RequestType = "ORDER";
            header.OrderID = "2001883";

            OrderRequestDetail detail = new OrderRequestDetail();
            detail.OrderItemID = "2001883";
            detail.OrderItemSequence = "100";
            detail.ItemID = "SCID";
            detail.ItemPrice = "49";
            detail.FilterPaperNumber = "I2001883S1";
            detail.GiftWrapMessage = "";
            detail.OrigFilterPaperNumber = "";


            OrderRequestDetail[] detailColl = new OrderRequestDetail[1];
            detailColl[0] = detail;

            order.OrderRequestDetail = detailColl;

            order.OrderRequestHeader = header;
            pediatrix.OrderRequest = order;
            client.ProcessPediatrixOrder(pediatrix);
            return new ProcessPediatrixOrderResponse();
        }
    }
}
