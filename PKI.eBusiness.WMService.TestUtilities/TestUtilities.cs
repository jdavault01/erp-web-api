using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities.OrderLookUp.BasicRequest;
using PKI.eBusiness.WMService.Entities.Orders;
using PKI.eBusiness.WMService.Entities.Stubs;
using AutoMapper;
using PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using PKI.eBusiness.WMService.Utility;
using PediatrixService = PKI.eBusiness.WMService.ServiceGatewContracts.WMService;

namespace PKI.eBusiness.WMService.TestUtilities
{
    /// <summary>
    /// Utilities for tests
    /// </summary>
    public class Utilities
    {
        #region Static Order Properties

        public static readonly string HEADER_REQUESTDATE = "20130326";
        public static readonly string HEADER_REQUESTTIME = "8:28:49 AM";
        public static readonly string HEADER_REQUESTTYPE = "ORDER";
        public static readonly string HEADER_FIRSTNAME = "Test";
        public static readonly string HEADER_LASTNAME = "Test";
        public static readonly string HEADER_ADDRESS = "1000 Test St";
        public static readonly string HEADER_APTSUITE = "";
        public static readonly string HEADER_CITY = "Waltham";
        public static readonly string HEADER_STATE = "MA";
        public static readonly string HEADER_ZIP = "05875";
        public static readonly string HEADER_TELEPHONE = "465346435";
        public static readonly string HEADER_EMAIL = "Ewa.Lach@perkinelmer.com";
        public static readonly string HEADER_NUMOFCHILDREN = "1";
        public static readonly string HEADER_QUESTIONS = "Customer order 2001883 on Mar  26 2013  8:28AM for Products: Qty: 1 Severe Combined Immunodeficiency Screening Packet (SCID ONLY)   CC auth is 646PNI,ref nbr is V19A4B32EB8B,type is Visa,last four is 1111,exp is 03/14";
        public static readonly string HEADER_HEARDABOUTUS = "Other";
        public static readonly string HEADER_ORDERID = "2001883";

        public static readonly string DETAIL_ORDERITEMID = "2001883";
        public static readonly string DETAIL_ORDERITEMSEQUENCE = "100";
        public static readonly string DETAIL_ITEMID = "SCID";
        public static readonly string DETAIL_ITEMPRICE = "49";
        public static readonly string DETAIL_FILTERPAPERNUMBER = "I2001883S1";
        public static readonly string DETAIL_GIFTWRAPMESSAGE = "";
        public static readonly string DETAIL_ORIGFILTERPAPERNUMBER = "";
        
        #endregion // Static Order Properties

        #region Other Static Properties

        public static readonly string EXPECTED_SERVICE_RESPONSE = "<?xml version=\"1.0\"?>\n\n<xmlResponse>\n\n  <code>200</code>\n\n  <Message>order entered</Message>\n\n</xmlResponse>";
        public static readonly string EXPECTED_SERVICE_MESSAGE= "order entered";


        #endregion // Other Static Properties

#region ProcessPiedatirxOrder_PortTypeClient Utils

        public static string PROCESSPIEDATIRXORDER_PORTTYPECLIENT_ENPOINTCONFIGURACTIONNAME = "PKIPediatrix_flows_ProcessPiedatirxOrder_Port";
        public static string PROCESSPIEDATIRXORDER_PORTTYPECLIENT_REMOTEADDRESS = @"http://165.88.161.141:5556/ws/PKIPediatrix.flows:ProcessPiedatirxOrder/PKIPediatrix_flows_ProcessPiedatirxOrder_Port";

#endregion


        public static OrderSubmissionResponse GetSampleResponse()
        {
            OrderSubmissionResponse response = new OrderSubmissionResponse();
            GeneralUtil<OrderSubmissionResponse> genUtil = new GeneralUtil<OrderSubmissionResponse>();
            response = genUtil.ConvertToObject(EXPECTED_SERVICE_RESPONSE);
            return response;
        }

        public static OrderLookUpResponse GetLookUpResponse()
        {
            OrderLookUpResponse response=new OrderLookUpResponse();
            List<PurchaseOrder> orderList=new List<PurchaseOrder>();
            orderList.Add(new PurchaseOrder() { PurchaseOrderID = "354005969", SAPOrderNum = "30250762" });
            response.OrderList = orderList;
            return response;

        }

        public static OrderDetailResponse GetDetailResponse()
        {
            return GetDetailedOrderInfoWebServiceResponse().ToOrderDetailResponse();
        }

        public static OrderInfoWebServiceResponse GetDetailedOrderInfoWebServiceResponse()
        {
            OrderInfoWebServiceResponse response = new OrderInfoWebServiceResponse();
            response.xmlResponse = @"<?xml version=""1.0""?>
<!DOCTYPE OrderDetailResponseOutput SYSTEM ""OrderDetailResponseOutput.dtd"">
<OrderDetailResponse>
  <Header>
    <Version value=""001"">001</Version>
    <Sender>
      <LogicalID>SF</LogicalID>
      <Task>DisplayOrderDetail</Task>
    </Sender>
  </Header>
  <Body Error="""">
    <OrderDetailResponseHeader>
      <ItemList>
        <Product id=""L160000A"">
          <WebLineItemNO>1</WebLineItemNO>
          <SAPLineItemNO>1</SAPLineItemNO>
          <Description>Spectrum Two FT-IR/Sp10 S/W</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>9887.11</AdjustedUnitPrice>
          <VAT>1977.43</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT>03/20/2014</ReceivedAtMIT>
          <ReleasedFromMIT>05-20-2014</ReleasedFromMIT>
          <PickedUpFromMIT>05-20-2014</PickedUpFromMIT>
          <ShipmentCreatedOn>05-20-2014</ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>9887.11</ExtendedPrice>
        </Product>
        <Product id=""L1600300"">
          <WebLineItemNO>2</WebLineItemNO>
          <SAPLineItemNO>2</SAPLineItemNO>
          <Description>Spectrum Two FT-IR</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""LX108873"">
          <WebLineItemNO>3</WebLineItemNO>
          <SAPLineItemNO>3</SAPLineItemNO>
          <Description>Spectrum 10 Software Kit</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""L1600107"">
          <WebLineItemNO>4</WebLineItemNO>
          <SAPLineItemNO>4</SAPLineItemNO>
          <Description>ATR DIAMOND ACCESSORY</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>4076.02</AdjustedUnitPrice>
          <VAT>815.20</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>4076.02</ExtendedPrice>
        </Product>
        <Product id=""09991415"">
          <WebLineItemNO>5</WebLineItemNO>
          <SAPLineItemNO>5</SAPLineItemNO>
          <Description>POWER CORD EUROPE</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>11.36</AdjustedUnitPrice>
          <VAT>2.27</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>11.36</ExtendedPrice>
        </Product>
        <Product id=""N8140002"">
          <WebLineItemNO>6</WebLineItemNO>
          <SAPLineItemNO>6</SAPLineItemNO>
          <Description>FINAL ASSY-NEXION-300X ICP-MS</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>61261.20</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>R</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>61261.20</ExtendedPrice>
        </Product>
        <Product id=""N8140501"">
          <WebLineItemNO>7</WebLineItemNO>
          <SAPLineItemNO>7</SAPLineItemNO>
          <Description>Installation Kit for NexION X</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>R</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""N8145002"">
          <WebLineItemNO>8</WebLineItemNO>
          <SAPLineItemNO>8</SAPLineItemNO>
          <Description>Vacuum Pump-SV40BI Fomblin NexION</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>R</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""W1033677"">
          <WebLineItemNO>9</WebLineItemNO>
          <SAPLineItemNO>9</SAPLineItemNO>
          <Description>ASSY TOP LEVEL 300X</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>R</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""N8145007"">
          <WebLineItemNO>10</WebLineItemNO>
          <SAPLineItemNO>10</SAPLineItemNO>
          <Description>POWER CORD-SV40BI SCHUKO EUROPE</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>100.23</AdjustedUnitPrice>
          <VAT>20.05</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>100.23</ExtendedPrice>
        </Product>
        <Product id=""N8140504"">
          <WebLineItemNO>11</WebLineItemNO>
          <SAPLineItemNO>11</SAPLineItemNO>
          <Description>KIT-SOLUTION NEXION CELL</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>394.24</AdjustedUnitPrice>
          <VAT>78.85</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>394.24</ExtendedPrice>
        </Product>
        <Product id=""WE016558"">
          <WebLineItemNO>12</WebLineItemNO>
          <SAPLineItemNO>12</SAPLineItemNO>
          <Description>CHEM CHILLER COOLANT</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>28.06</AdjustedUnitPrice>
          <VAT>5.61</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>28.06</ExtendedPrice>
        </Product>
        <Product id=""ED024220"">
          <WebLineItemNO>13</WebLineItemNO>
          <SAPLineItemNO>13</SAPLineItemNO>
          <Description>CHILLER LABTECH H150-2100</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>1754.02</AdjustedUnitPrice>
          <VAT>350.80</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>1754.02</ExtendedPrice>
        </Product>
        <Product id=""PEEBLENW7FRA"">
          <WebLineItemNO>14</WebLineItemNO>
          <SAPLineItemNO>14</SAPLineItemNO>
          <Description>LENOVO THINKCENTRE M92P TOWER FR/Azerty</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>800.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>R</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>800.00</ExtendedPrice>
        </Product>
        <Product id=""MPL22TFTW"">
          <WebLineItemNO>15</WebLineItemNO>
          <SAPLineItemNO>15</SAPLineItemNO>
          <Description>MONITOR 22&quot; LENOVO WIDE 16:10, LT2252p/L</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>173.73</AdjustedUnitPrice>
          <VAT>69.49</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>347.46</ExtendedPrice>
        </Product>
        <Product id=""N2020006"">
          <WebLineItemNO>16</WebLineItemNO>
          <SAPLineItemNO>16</SAPLineItemNO>
          <Description>S10 Autosampler for ICP</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>4877.86</AdjustedUnitPrice>
          <VAT>975.57</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>4877.86</ExtendedPrice>
        </Product>
        <Product id=""N2020020"">
          <WebLineItemNO>17</WebLineItemNO>
          <SAPLineItemNO>17</SAPLineItemNO>
          <Description>S10 Autosampler^</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""N6519581"">
          <WebLineItemNO>18</WebLineItemNO>
          <SAPLineItemNO>18</SAPLineItemNO>
          <Description>CLARUS 580 GC 240 VOLTS</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>8968.59</AdjustedUnitPrice>
          <VAT>3047.53</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>15237.63</ExtendedPrice>
        </Product>
        <Product id=""N6480021"">
          <WebLineItemNO>19</WebLineItemNO>
          <SAPLineItemNO>19</SAPLineItemNO>
          <Description>CLARUS SQ8S MS 120/230V (580 EI)</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>36884.64</AdjustedUnitPrice>
          <VAT>7376.93</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>36884.64</ExtendedPrice>
        </Product>
        <Product id=""09991415"">
          <WebLineItemNO>20</WebLineItemNO>
          <SAPLineItemNO>20</SAPLineItemNO>
          <Description>POWER CORD EUROPE</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>11.36</AdjustedUnitPrice>
          <VAT>9.09</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>45.44</ExtendedPrice>
        </Product>
        <Product id=""N6470045"">
          <WebLineItemNO>21</WebLineItemNO>
          <SAPLineItemNO>21</SAPLineItemNO>
          <Description>VENT KIT-TURBOMASS INERT GAS</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>380.21</AdjustedUnitPrice>
          <VAT>76.04</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>380.21</ExtendedPrice>
        </Product>
        <Product id=""M0413602"">
          <WebLineItemNO>22</WebLineItemNO>
          <SAPLineItemNO>22</SAPLineItemNO>
          <Description>TURBOMATRIX HEADSPACE SAMPLER</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>7320.31</AdjustedUnitPrice>
          <VAT>2487.44</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>12437.21</ExtendedPrice>
        </Product>
        <Product id=""M0413650"">
          <WebLineItemNO>23</WebLineItemNO>
          <SAPLineItemNO>23</SAPLineItemNO>
          <Description>SYSTEM-TURBOMATRIX THERMAL DESORBER</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>14373.97</AdjustedUnitPrice>
          <VAT>4884.27</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>24421.37</ExtendedPrice>
        </Product>
        <Product id=""M0417035"">
          <WebLineItemNO>24</WebLineItemNO>
          <SAPLineItemNO>24</SAPLineItemNO>
          <Description>CABLE SOFTWARE COMMUNICATION</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>62.15</AdjustedUnitPrice>
          <VAT>24.86</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>124.30</ExtendedPrice>
        </Product>
        <Product id=""09404922"">
          <WebLineItemNO>25</WebLineItemNO>
          <SAPLineItemNO>25</SAPLineItemNO>
          <Description>NETWORK CARD</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>70.83</AdjustedUnitPrice>
          <VAT>14.17</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>70.83</ExtendedPrice>
        </Product>
        <Product id=""09406409"">
          <WebLineItemNO>26</WebLineItemNO>
          <SAPLineItemNO>26</SAPLineItemNO>
          <Description>PC-LENOVO M82(WIN7-64BIT) TOWER USA</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>634.12</AdjustedUnitPrice>
          <VAT>126.82</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>634.12</ExtendedPrice>
        </Product>
        <Product id=""N6470012"">
          <WebLineItemNO>27</WebLineItemNO>
          <SAPLineItemNO>27</SAPLineItemNO>
          <Description>MARATHON FILAMENT GC/MS</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>188.43</AdjustedUnitPrice>
          <VAT>37.69</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>188.43</ExtendedPrice>
        </Product>
        <Product id=""N6520245"">
          <WebLineItemNO>28</WebLineItemNO>
          <SAPLineItemNO>28</SAPLineItemNO>
          <Description>S/W UPGRADE TURBOMASS NIST 2011</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>763.08</AdjustedUnitPrice>
          <VAT>152.62</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>763.08</ExtendedPrice>
        </Product>
        <Product id=""W1033612"">
          <WebLineItemNO>29</WebLineItemNO>
          <SAPLineItemNO>29</SAPLineItemNO>
          <Description>NICKEL SAMPLER FOR NEXION</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>276.63</AdjustedUnitPrice>
          <VAT>55.33</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>276.63</ExtendedPrice>
        </Product>
        <Product id=""W1026356"">
          <WebLineItemNO>30</WebLineItemNO>
          <SAPLineItemNO>30</SAPLineItemNO>
          <Description>NICKEL SKIMMER FOR NEXION</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>263.94</AdjustedUnitPrice>
          <VAT>52.79</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>263.94</ExtendedPrice>
        </Product>
        <Product id=""REGDELMAS"">
          <WebLineItemNO>31</WebLineItemNO>
          <SAPLineItemNO>31</SAPLineItemNO>
          <Description>Frais de Livraison</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>1500.05</AdjustedUnitPrice>
          <VAT>300.01</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>1500.05</ExtendedPrice>
        </Product>
        <Product id=""PELENW764FRA"">
          <WebLineItemNO>32</WebLineItemNO>
          <SAPLineItemNO>32</SAPLineItemNO>
          <Description>LENOVO THINKCENTRE M92p TOWER</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>534.56</AdjustedUnitPrice>
          <VAT>106.91</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>534.56</ExtendedPrice>
        </Product>
        <Product id=""N8140002"">
          <WebLineItemNO>33</WebLineItemNO>
          <SAPLineItemNO>33</SAPLineItemNO>
          <Description>FINAL ASSY-NEXION-300X ICP-MS</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>61261.20</AdjustedUnitPrice>
          <VAT>12252.23</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>61261.20</ExtendedPrice>
        </Product>
        <Product id=""N8140501"">
          <WebLineItemNO>34</WebLineItemNO>
          <SAPLineItemNO>34</SAPLineItemNO>
          <Description>Installation Kit for NexION X</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""N8145002"">
          <WebLineItemNO>35</WebLineItemNO>
          <SAPLineItemNO>35</SAPLineItemNO>
          <Description>Vacuum Pump-SV40BI Fomblin NexION</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
        <Product id=""W1033677"">
          <WebLineItemNO>36</WebLineItemNO>
          <SAPLineItemNO>36</SAPLineItemNO>
          <Description>ASSY TOP LEVEL 300X</Description>
          <Quantity>0.000</Quantity>
          <AdjustedUnitPrice>0.00</AdjustedUnitPrice>
          <VAT>0.00</VAT>
          <ShippingPoint>EU04</ShippingPoint>
          <ExpectedShipDate></ExpectedShipDate>
          <Status>A</Status>
          <Carrier></Carrier>
          <TrackingNO></TrackingNO>
          <PromotionalDiscount>0.00</PromotionalDiscount>
          <IsCourse>N</IsCourse>
          <ShipmentRoute/>
          <ReceivedAtMIT></ReceivedAtMIT>
          <ReleasedFromMIT></ReleasedFromMIT>
          <PickedUpFromMIT></PickedUpFromMIT>
          <ShipmentCreatedOn></ShipmentCreatedOn>
          <IssuedDate/>
          <ExtendedPrice>0.00</ExtendedPrice>
        </Product>
      </ItemList>
      <TotalPrice>238561.19999999995</TotalPrice>
      <OrderType>ZGO</OrderType>
      <DeliveryCharges>.00</DeliveryCharges>
      <HandlingCharges>0.0</HandlingCharges>
      <OrderLevelTax>35300.0</OrderLevelTax>
      <Currency>EUR</Currency>
      <BillTo id=""4614829"">
        <BillToAttention></BillToAttention>
        <Name1>SARL FME</Name1>
        <Name2>BP 30085</Name2>
        <Name3></Name3>
        <Name4></Name4>
        <RADIndicator>False</RADIndicator>
        <MarkedForDeletion></MarkedForDeletion>
        <Address>
          <Street>1 RUE DE ROTTERDAM</Street>
          <POBox></POBox>
          <POBoxCity></POBoxCity>
          <City>VANDOEUVRE LES NANCY CEDEX</City>
          <District></District>
          <Country>France</Country>
          <Fax></Fax>
          <PostalCode>54503</PostalCode>
          <Region>FR</Region>
          <CityCode></CityCode>
          <Telephone qualifier=""Daytime"">0383540291 M</Telephone>
        </Address>
      </BillTo>
      <ShipTo id=""100687507"">
        <ShipToAttention>Monsieur FRANCK MOKARIAN</ShipToAttention>
        <Name1>SARL FME</Name1>
        <Name2></Name2>
        <Name3></Name3>
        <Name4></Name4>
        <RADIndicator>False</RADIndicator>
        <MarkedForDeletion></MarkedForDeletion>
        <Address>
          <Street>36 RUE GENERAL THIRY</Street>
          <POBox></POBox>
          <POBoxCity></POBoxCity>
          <City>NEUVES MAISON</City>
          <District></District>
          <Country>France</Country>
          <Fax></Fax>
          <PostalCode>54230</PostalCode>
          <Region>FR</Region>
          <CityCode></CityCode>
          <Telephone qualifier=""Daytime""></Telephone>
        </Address>
      </ShipTo>
      <PONumber/>
      <CreditCardNumber></CreditCardNumber>
      <CreditCardType></CreditCardType>
      <TelephoneNumber></TelephoneNumber>
      <AdditionalInfo>&lt;br/&gt;&lt;br/&gt;&lt;br/&gt;&lt;br/&gt;Contact person: Franck MOKARIAN, 03 83 54 02 91 &lt;br/&gt;&lt;br/&gt;&lt;br/&gt;&lt;br/&gt;</AdditionalInfo>
      <SpecialHandlingInstructions></SpecialHandlingInstructions>
      <EstShipDate>20140618</EstShipDate>
      <CustomerAcceptDate>20140616</CustomerAcceptDate>
      <ExpectedDeliveryDate>20140725</ExpectedDeliveryDate>

      <CreditStatus/>
      <DeliveryBlock/>
    </OrderDetailResponseHeader>
    <ErrorReturn>
      <Timestamp></Timestamp>
      <ErrorNumber></ErrorNumber>
      <Error></Error>
      <ErrorType></ErrorType>
    </ErrorReturn>
  </Body>
</OrderDetailResponse>";
            return response;
        }
        
        public static OrderInfoWebServiceResponse GetOrderInfoWebServiceResponse()
        {
            
            OrderInfoWebServiceResponse response=new OrderInfoWebServiceResponse();
            response.xmlResponse=@"<?xml version=""1.0""?>
<!DOCTYPE OrderSummaryOutput SYSTEM ""OrderSummaryOutput.dtd"">
<OrderSummaryResponse>
  <Header>
    <Version value=""001"">001</Version>
    <Sender>
      <LogicalID>SF</LogicalID>
      <Task>DisplayOrderSummary</Task>
    </Sender>
  </Header>
  <Body Error=""F"">
    <OrderSummaryResponseHeader>
      <Order>
        <DateOfPlacingOrder>20121119</DateOfPlacingOrder>
        <OrderStatus>C</OrderStatus>
        <PurchaseOrderID>354005969</PurchaseOrderID>
        <ShipTo>0100585228</ShipTo>
        <VAT>280.24</VAT>
        <OrderValue>3503.00</OrderValue>
        <ContactName></ContactName>
        <SAPOrderNum>30250762</SAPOrderNum>
        <Currency>CHF</Currency>
        <ShipToAttention>Marc Stauffer</ShipToAttention>
      </Order>
    </OrderSummaryResponseHeader>
    <ErrorReturn>
      <Timestamp></Timestamp>
      <ErrorNumber></ErrorNumber>
      <Error></Error>
      <ErrorType></ErrorType>
    </ErrorReturn>
  </Body>
</OrderSummaryResponse>";

            return response;
        }
        
        /// <summary>
        /// Gets Mock Order
        /// </summary>
        /// <returns></returns>
        public static Order GetExampleOrder()
        {
            return new Order()
            {
                OrderRequest = new WMService.Entities.Orders.OrderRequest()
                {
                    OrderRequestHeader = new WMService.Entities.Orders.OrderRequestHeader()
                    {
                        RequestDate = HEADER_REQUESTDATE,
                        RequestTime = HEADER_REQUESTTIME,
                        RequestType = HEADER_REQUESTTYPE,
                        FirstName = HEADER_FIRSTNAME,
                        LastName = HEADER_LASTNAME,
                        Address = HEADER_ADDRESS,
                        AptSuite = HEADER_APTSUITE,
                        City = HEADER_CITY,
                        State = HEADER_STATE,
                        Zip = HEADER_ZIP,
                        Telephone = HEADER_TELEPHONE,
                        Email = HEADER_EMAIL,
                        NumOfChildren = HEADER_NUMOFCHILDREN,
                        Questions = HEADER_QUESTIONS,
                        HeardAboutUs = HEADER_HEARDABOUTUS,
                        OrderID = HEADER_ORDERID
                    },
                    OrderRequestDetail = new WMService.Entities.Orders.OrderRequestDetail[1]
                    {
                        new WMService.Entities.Orders.OrderRequestDetail()
                        {
                            OrderItemID = DETAIL_ORDERITEMID,
                            OrderItemSequence = DETAIL_ORDERITEMSEQUENCE,
                            ItemID = DETAIL_ITEMID,
                            ItemPrice = DETAIL_ITEMPRICE,
                            FilterPaperNumber = DETAIL_FILTERPAPERNUMBER,
                            GiftWrapMessage = DETAIL_GIFTWRAPMESSAGE,
                            OrigFilterPaperNumber = DETAIL_ORIGFILTERPAPERNUMBER
                        }
                    }
                }
            };
        }

        /// <summary>
        /// Gets Mock Pediatrix
        /// </summary>
        /// <returns></returns>
        public static PediatrixService.Pediatrix GetExamplePediatrix()
        {
            // Initialize Order To Pediatrix Mapper which is used for OrderService objects
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestHeader, PediatrixService.OrderRequestHeader>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequestDetail,PediatrixService.OrderRequestDetail>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.OrderRequest, PediatrixService.OrderRequest>();
            Mapper.CreateMap<PKI.eBusiness.WMService.Entities.Orders.Order, PediatrixService.Pediatrix>();

            // Create Order object
            Order order = GetExampleOrder();

            // Map order to Pediatrix object
            PediatrixService.Pediatrix pedOrder = Mapper.Map<Order, PediatrixService.Pediatrix>(order);

            return pedOrder;
        }
        
        public static OrderInfoWebServiceRequest GetOrderInfoWebServiceRequest()
        {
            var orderInfoWebServiceRequest = new OrderInfoWebServiceRequest
            {
                xmlRequest = "xmlRequest"
            };
            return orderInfoWebServiceRequest;
        }
    }
}
