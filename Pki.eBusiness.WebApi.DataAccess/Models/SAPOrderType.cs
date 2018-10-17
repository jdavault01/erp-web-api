using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StorefrontCreateOrderRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.CreateOrderRequest;

namespace Pki.eBusiness.WebApi.DataAccess.Models
{
    public class SAPOrderType
    {
        public string CountryName { get; private set; }
        public bool IsDealer { get; private set; }
        public WebOrderType OrderType { get; private set; }
        public WebUserType UserType { get; private set; }
        public bool ContainsInstrument { get; private set; }
        public string PaymentType { get; private set; }
        private List<String> ZWESCountries = new List<string> { "Turkey", "Israel", "Croatia" };
        private List<String> EUCountries = new List<string> { "Austria", " Belgium", " Bulgaria", " Croatia", " Republic of Cyprus", " Czech Republic", " Denmark", " Estonia", " Finland", " France", " Germany", " Greece", " Hungary", " Ireland", "Italy", " Latvia", " Lithuania", " Luxembourg", " Malta", " Netherlands", " Poland", " Portugal", " Romania", " Slovakia", " Slovenia", " Spain", " Sweden", "UK" };

public SAPOrderType()
        {

        }
        public SAPOrderType(BaseOrderRequest clientRequest)
        {
            CountryName = clientRequest.CountryName;
            ContainsInstrument = clientRequest.ContainsInstrument;
            PaymentType = clientRequest.PaymentType;
            CountryName = clientRequest.CountryName;
            OrderType = (WebOrderType)(int)clientRequest.OrderType;
            UserType = (WebUserType)(int)clientRequest.UserType;
            IsDealer = UserType == WebUserType.Dealer;
        }

        public string GetOrderTypeCode()
        {
            if (OrderType == WebOrderType.Standard && PaymentType == "PO" && !ContainsInstrument)
                return "ZWEB";
            if (OrderType == WebOrderType.Standard && PaymentType == "CC" && !ContainsInstrument)
                return "ZWCC";
            if (OrderType == WebOrderType.Scheduled && PaymentType == "PO")
                return "ZWSA";
            if (OrderType == WebOrderType.Scheduled && PaymentType == "PO")
                return "ZWSC";
            if (OrderType == WebOrderType.Scheduled && CountryName.ToUpper() == "KOREA")
                return "ZWEX";
            if ((OrderType == WebOrderType.Scheduled && CountryName == "KOREA" && IsDealer) || ZWESCountries.Contains(CountryName, StringComparer.OrdinalIgnoreCase))
                return "ZWSA";
            if (ContainsInstrument && CountryName.ToUpper() != "CANADA" && !EUCountries.Contains(CountryName, StringComparer.OrdinalIgnoreCase))
                return "ZGNA";
            if (ContainsInstrument && PaymentType == "CC" && CountryName == "USA")
                return "ZWSA";
            if (ContainsInstrument && CountryName == "CANADA")
                return "ZGCA";
            if (ContainsInstrument && PaymentType == "CC" && CountryName == "CANADA")
                return "ZGCC";
            if (ContainsInstrument && CountryName != "ITALY" && EUCountries.Contains(CountryName, StringComparer.OrdinalIgnoreCase))
                return "ZGO";
            if (ContainsInstrument && CountryName != "ITALY")
                return "ZGEX";
            if (OrderType == WebOrderType.Scheduled && CountryName == "CHINA")
                return "ZWSV";

            return "ZWEB";
        }

    }

    public enum OrderType
    {
        ZWEB,
        ZWCC,
        ZWSA,
        ZWSC,
        ZWEX,
        ZWES,
        ZGNA,
        ZGCA,
        ZGCC,
        ZGO,
        ZGEX,
        ZWSV
    }

    public enum WebOrderType
    {
        Standard,
        Scheduled,
        MPO
    }

    public enum WebUserType
    {
        B2B,
        Dealer,
        Punchout
    }

}
