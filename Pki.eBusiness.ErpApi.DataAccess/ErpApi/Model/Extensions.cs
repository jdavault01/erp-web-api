﻿using System;
using System.Collections.Generic;
using System.Linq;
using Pki.eBusiness.ErpApi.DataAccess.Extensions;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Entities.OrderLookUp.BasicRequest;
using Pki.eBusiness.ErpApi.Entities.Orders;

namespace Pki.eBusiness.ErpApi.DataAccess.ErpApi.Model
{

    public partial class PartnerLookupRequestRoot
    {
        protected const string SALES_DISTRIBUTION_CHANNEL = "01";
        protected const string SALES_DIVISION = "02";
        protected const string SAP_SHIP_TO = "WE";
        protected const string SAP_HIERARCHY_NUMBER = "1A";
        protected const string SAP_HIERARCHY_NAME = "KO";
        protected const string SAP_CONTACT = "AP";
        protected const string SAP_BILL_TO = "RG";
        protected const string SAP_DUPLICATE_BILL_TO = "RE";
        protected const string SAP_SOLD_TO = "AG";

        public PartnerLookupRequestRoot(SimplePartnerRequest req, Enumerations.AddressType addressType)
        {
            DISTR_CHAN = SALES_DISTRIBUTION_CHANNEL;
            DIVISION = SALES_DIVISION;
            PARTNER_IN = req.PartnerId;
            SALESORG = req.SalesAreaInfo.SalesOrgId;

            if (addressType == Enumerations.AddressType.BillTo)
            {
                PARTNER_ROLE_IN = SAP_DUPLICATE_BILL_TO;
                PARTNER_ROLE_OUT = SAP_BILL_TO;
            }
            else
            {
                PARTNER_ROLE_IN = SAP_SHIP_TO;
                PARTNER_ROLE_OUT = SAP_SHIP_TO;
            }
        }

        public PartnerLookupRequestRoot(SimplePartnerRequest req)
        {
            DISTR_CHAN = SALES_DISTRIBUTION_CHANNEL;
            DIVISION = SALES_DIVISION;
            PARTNER_IN = req.PartnerId;
            PARTNER_ROLE_IN = SAP_SHIP_TO;
            SALESORG = req.SalesAreaInfo.SalesOrgId;
        }

        
        public PartnerLookupRequestRoot(CompanyAddressesRequest req)
        {
            DISTR_CHAN = SALES_DISTRIBUTION_CHANNEL;
            DIVISION = SALES_DIVISION;
            PARTNER_IN = req.ShipTo;
            PARTNER_ROLE_IN = SAP_SHIP_TO;
            SALESORG = req.SalesOrg;
        }

        public PartnerLookupRequestRoot(CompanyInfoRequest req)
        {
            DISTR_CHAN = SALES_DISTRIBUTION_CHANNEL;
            DIVISION = SALES_DIVISION;
            PARTNER_IN = req.ERPHierarchyNumber;
            PARTNER_ROLE_IN = SAP_HIERARCHY_NUMBER;
            PARTNER_ROLE_OUT = SAP_HIERARCHY_NAME;
            SALESORG = req.SalesOrg;
        }

        public PartnerLookupRequestRoot(CompanyContactsRequest req)
        {
            DISTR_CHAN = SALES_DISTRIBUTION_CHANNEL;
            DIVISION = SALES_DIVISION;
            LASTNAME = req.Name == null ? string.Empty : req.Name.ToUpper();
            PARTNER_IN = req.ERPHierarchyNumber;
            PARTNER_ROLE_IN = SAP_HIERARCHY_NUMBER;
            PARTNER_ROLE_OUT = SAP_CONTACT;
            SALESORG = req.SalesOrg;
        }
    }

    public partial class PartnerLookupResponseRoot
    {
        protected const string SAP_CONTACT = "AP";
        protected const string SAP_BILL_TO = "RG";
        protected const string SAP_SHIP_TO = "WE";
        protected const string SAP_DUPLICATE_BILL_TO = "RE";
        protected const string SAP_SOLD_TO = "AG";
        protected const string SAP_HIERARCHY_NUMBER = "1A";
        protected const int LAST_NAME_IDX = 0;
        protected const int FIRST_NAME_IDX = 1;


        public Partner ToShipToAddressResponse(string partnerId)
        {
            return PARTNERS_OUT.Where(x => GetPartInfo(x, partnerId, null, SAP_SHIP_TO)).Select(GetPartnerDetails).Distinct().SingleOrDefault();
        }

        public Partner ToBillToAddressResponse(string partnerId)
        {
            return PARTNERS_OUT.Where(x => GetPartInfo(x, partnerId, null, SAP_BILL_TO)).Select(GetPartnerDetails).Distinct().SingleOrDefault();
        }

        public PartnerResponse ToPartnerResponse()
        {
            var hierarchyAddress = GetHierarchyAddress();
            var partners = PARTNERS_OUT.Where(RemoveContactsAndDuplicateBillTos).Select(GetPartnerDetails).ToList();
            var result = new PartnerResponse
            {
                ERPHierarchyName = ADDRESS_OUT.SingleOrDefault(i => i.ADDRNUMBER == hierarchyAddress).NAME1,
                ERPHierarchyNumber = PARTNERS_OUT.Where(i => i.PARTN_ROLE == SAP_HIERARCHY_NUMBER).First()?.CUSTOMER,
                Partners = partners
            };

            return result;
        }

        public CompanyInfoResponse ToCompanyInfoResponse()
        {
            var hierarchyAddress = GetHierarchyAddress();
            var ERPHierarchyName = ADDRESS_OUT.SingleOrDefault(i => i.ADDRNUMBER == hierarchyAddress).NAME1;
            var ERPHierarchyNumber = PARTNERS_OUT.Where(i => i.PARTN_ROLE == SAP_HIERARCHY_NUMBER).First()?.CUSTOMER;
            return new CompanyInfoResponse { ERPHierarchy = new ERPHierarchy(ERPHierarchyNumber, ERPHierarchyName) };
        }

        public CompanyContactsResponse ToCompanyContactsResponse(string name)
        {
            name = name.ToLower();
            var contactList = PARTNERS_OUT.Where(RemoveAllButContacts).Select(GetContactDetails).ToList();
            if (!String.IsNullOrEmpty(name))
            {
                contactList = contactList.Where(x => x.LastName.ToLower().Contains(name) || x.FirstName.ToLower().Contains(name)).ToList();
            }
            var result = new CompanyContactsResponse
            {
                ContactList = contactList
            };

            return result;
        }

        public CompanyAddressesResponse ToCompanyAddressesResponse(string shipTo, string billTo)
        {
            var billTos = PARTNERS_OUT.Where(x => GetPartInfo(x, shipTo, billTo, SAP_BILL_TO)).Select(GetPartnerDetails).Distinct().ToList();
            var shipTos = PARTNERS_OUT.Where(x => GetPartInfo(x, shipTo, billTo, SAP_SHIP_TO)).Select(GetPartnerDetails).Distinct().ToList();
            var soldTos = PARTNERS_OUT.Where(x => GetPartInfo(x, shipTo, billTo, SAP_SOLD_TO)).Select(GetPartnerDetails).Distinct().ToList();

            var result = new CompanyAddressesResponse
            {
                ShipTos = shipTos,
                BillTos = billTos,
                SoldTos = soldTos
            };

            return result;
        }

        private string GetHierarchyAddress()
        {
            return PARTNERS_OUT.SingleOrDefault(x => x.PARTN_ROLE == SAP_HIERARCHY_NUMBER).ADDRESS;
        }


        private static bool RemoveContactsAndDuplicateBillTos(PartnerLookupResponseRootPARTNERSOUT x)
        {
            return x.PARTN_ROLE != SAP_CONTACT && x.PARTN_ROLE != SAP_DUPLICATE_BILL_TO;
        }

        private static bool RemoveAllButContacts(PartnerLookupResponseRootPARTNERSOUT x)
        {
            return x.PARTN_ROLE == SAP_CONTACT && x.PARTN_ROLE != SAP_HIERARCHY_NUMBER;
        }

        private static bool GetPartInfo(PartnerLookupResponseRootPARTNERSOUT x, string shipTo, string billTo, string partnerType)
        {
           if (!string.IsNullOrEmpty(shipTo) && x.CUSTOMER == shipTo && (x.PARTN_ROLE == SAP_SHIP_TO || x.PARTN_ROLE == SAP_SOLD_TO) && partnerType == SAP_SHIP_TO)
             return true;

           if (!string.IsNullOrEmpty(billTo) && x.CUSTOMER == billTo && x.PARTN_ROLE == SAP_BILL_TO && partnerType == SAP_BILL_TO)
               return true;

           if (string.IsNullOrEmpty(billTo) && SAP_BILL_TO == partnerType && x.PARTN_ROLE == SAP_BILL_TO)
               return true;

           if (string.IsNullOrEmpty(shipTo) && SAP_SHIP_TO == partnerType && x.PARTN_ROLE == SAP_SHIP_TO)
               return true;

           return x.PARTN_ROLE == SAP_SOLD_TO && partnerType == SAP_SOLD_TO;
        }

        private bool RemoveContactsApplyFilters(PartnerLookupResponseRootPARTNERSOUT x, string shipTo, string billTo)
        {

            if (String.IsNullOrEmpty(shipTo) && String.IsNullOrEmpty(billTo))
                return x.PARTN_ROLE != SAP_CONTACT && x.PARTN_ROLE != SAP_HIERARCHY_NUMBER;
            else if (String.IsNullOrEmpty(billTo))
                return x.PARTN_ROLE != SAP_CONTACT && x.PARTN_ROLE != SAP_HIERARCHY_NUMBER &&
                       x.PARTN_ROLE != SAP_DUPLICATE_BILL_TO && x.PARENT_NO == shipTo;
            else
                return x.PARTN_ROLE != SAP_CONTACT && x.PARTN_ROLE != SAP_HIERARCHY_NUMBER &&
                       x.PARTN_ROLE != SAP_DUPLICATE_BILL_TO &&
                       (x.CUSTOMER == shipTo || (x.CUSTOMER == billTo && x.PARENT_NO == shipTo));
        }

        private PartnerLookupResponseRootADDRESSOUT GetAddress(PartnerLookupResponseRootPARTNERSOUT partnerItem)
        {
            return ADDRESS_OUT.FirstOrDefault(x => partnerItem.ADDRESS == x.ADDRNUMBER);

        }

        private PartnerLookupResponseRootADDRESSOUT GetContactAddresses(PartnerLookupResponseRootPARTNERSOUT partnerItem)
        {
            return ADDRESS_OUT.Where(x => partnerItem.ADDRESS == x.ADDRNUMBER && partnerItem.PARTN_ROLE == SAP_CONTACT).First();
        }

        private Contact GetContactDetails(PartnerLookupResponseRootPARTNERSOUT partnerOut)
        {
            var addressOut = GetContactAddresses(partnerOut);
            if (addressOut == null)
                return null;
            var contact = new Contact
            {
                Id = partnerOut.CUSTOMER,
                EmailAddress = String.IsNullOrEmpty(partnerOut.E_MAIL) ? "NO EMAIL ADDRESS IN SAP" : partnerOut.E_MAIL,
                LastName = String.IsNullOrEmpty(addressOut.NAME1) ? "NO LASTNAME FOUND IN SAP" : ParseName(addressOut.NAME1, LAST_NAME_IDX),
                FirstName = String.IsNullOrEmpty(addressOut.NAME1) ? "NO FIRSTNAME FOUND IN SAP" : ParseName(addressOut.NAME1, FIRST_NAME_IDX),
                ParentAccount = partnerOut.PARENT_NO
            };

            return contact;
        }

        private Partner GetPartnerDetails(PartnerLookupResponseRootPARTNERSOUT partnerOut)
        {
            var addressOut = GetAddress(partnerOut);
            if (addressOut == null)
                return null;

            var partner = new Partner
            {
                PartnerId = partnerOut.CUSTOMER,
                FirstName = addressOut.NAME1,
                CompanyName = addressOut.NAME1,
                Name1 = addressOut.NAME1,
                Name2 = addressOut.NAME2,
                Name3 = addressOut.NAME3,
                Name4 = addressOut.NAME4,
                City = addressOut.CITY1,
                Street = addressOut.STREET,
                State = addressOut.REGION,
                Region = addressOut.REGION,
                Country = addressOut.COUNTRY,
                PostalCode = addressOut.POST_CODE1,
                RadIndicator = partnerOut.RAD_FLAG == "True",
                PartnerType = GetPartnerType(partnerOut.PARTN_ROLE),
                Telephone = addressOut.TEL_NUMBER,
                Fax = addressOut.FAX_NUMBER
            };

            return partner;
        }

        private PartnerType GetPartnerType(string SAPType)
        {
            if (SAPType == SAP_HIERARCHY_NUMBER) return PartnerType.Hierarchy;
            if (SAPType == SAP_BILL_TO) return PartnerType.BillTo;
            if (SAPType == SAP_DUPLICATE_BILL_TO) return PartnerType.BillTo;
            if (SAPType == SAP_SOLD_TO) return PartnerType.SoldTo;
            if (SAPType == SAP_CONTACT) return PartnerType.ContactID;
            return PartnerType.ShipTo; //WE
        }

        private string ParseName(string name, int index)
        {
            char[] commaDelimited = { ',' };
            //If there is no Name,FirstName just return the whole name as the Name
            if (!name.Contains(",") && index == LAST_NAME_IDX)
                return name;
            if (!name.Contains(",") && index != LAST_NAME_IDX)
                return String.Empty;

            return name.Split(commaDelimited)[index];
        }

    }


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
            var result = new SimulateOrderErpResponse
            {
                PaymentTerms = PAYTEXT,
                INCOCode = SOLD_TO_PARTY?.First()?.INCOTERMS1 + " ",
                INCOTerms = SOLD_TO_PARTY?.First()?.INCOTERMS2,
                Currency = SOLD_TO_PARTY?.First()?.CURRENCY,
                ShippingCost =
                ZWEB_ORDER_STATUS.Sum(s => s.FREIGHT.ToDecimal() + s.HANDLING.ToDecimal())
            };
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
            //LANGUAGE = req.Language;
            COLLECT_NO = req.PromoCode;
            //We have not sent this in the past .. might not be rquired
            //PURCH_DATE = req.RequestedDate.ToString("yyyyMMdd");
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
