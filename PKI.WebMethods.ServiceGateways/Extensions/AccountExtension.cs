using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Account = PKI.eBusiness.WMService.Entities.StoreFront.Account;
using DataObjects = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices;
using Address = PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices.Address;
using SimplePartnerRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.SimplePartnerRequest;
using StorefrontPartnerRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.PartnerRequest;
using ContactCreateRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.ContactCreateRequest;
using ContactCreateWebServiceResponse = PKI.eBusiness.WMService.ServiceGateways.ContactCreateWebServiceResponse;
using Partner = PKI.eBusiness.WMService.ServiceGateways.StoreFrontWebServices.Partner;

namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{
    public static class AccountExtension
    {
        //Will be decomissioned after cart project
        public static PartnerWebServiceRequest ToWmPartnerRequest(this StorefrontPartnerRequest request)
        {
            return new PartnerServiceRequest(request).WebServiceRequest;
        }

        public static PartnerWebServiceRequest ToWmPartnerRequest(this SimplePartnerRequest request)
        {
            return new PartnerServiceRequest(request).WebServiceRequest;
        }

        public static DataObjects.PartnerResponse ToPartnerResponse(this PartnerWebServiceResponse1 response)
        {
            var result = new DataObjects.PartnerClientResponse();
            result.PartnerResponse = new DataObjects.PartnerResponse
            {
                PartnerResponseHeader = new DataObjects.PartnerResponseHeader()
                {
                    ERPHierarchyNumber = response.PartnerResponse.PartnerResponseHeader.ERPHierarchyNumber,
                    ERPHierarchyName = response.PartnerResponse.PartnerResponseHeader.ERPHierarchyName,
                },

            };
            result.PartnerResponse.PartnerResponseDetails = new List<DataObjects.PartnerResponseDetail>();
            foreach (var detail in response.PartnerResponse.PartnerResponseDetail)
            {
                var partnerResponseDetail = new DataObjects.PartnerResponseDetail();
                Account.PartnerType partnerType;
                Enum.TryParse(detail.PartnerType, out partnerType);

                partnerResponseDetail.Partner = new Account.Partner
                {
                    PartnerId = detail.PartnerID,
                    PartnerType = partnerType,
                    RadIndicator = detail.Partner[0].RADIndicator,
                    Name1 = detail.Partner[0].Name1,
                    Name2 = detail.Partner[0].Name2,
                    Name3 = detail.Partner[0].Name3,
                    Name4 = detail.Partner[0].Name4,
                    Addresses = new List<Account.Address>()
                };


                var address = new Account.Address
                {
                    Street = detail.Partner[0].Address.Street,
                    POBox = detail.Partner[0].Address.POBox,
                    POBoxCity = detail.Partner[0].Address.POBoxCity,
                    City = detail.Partner[0].Address.City,
                    District = detail.Partner[0].Address.District,
                    Country = detail.Partner[0].Address.Country,
                    Fax = detail.Partner[0].Address.Fax,
                    PostalCode = detail.Partner[0].Address.PostalCode,
                    //Make as State instead of Region .. WM has it crossed
                    //Region = detail.Partner[0].Address.Region,
                    State = detail.Partner[0].Address.Region,
                    Telephone = detail.Partner[0].Address.Telephone[0].Text == null ? null : detail.Partner[0].Address.Telephone[0].Text.ToString()

                };

                partnerResponseDetail.Partner.Addresses.Add(address);
                result.PartnerResponse.PartnerResponseDetails.Add(partnerResponseDetail);
            }

            return result.PartnerResponse;
        }

        //public static ContactCreateWebServiceRequest ToWmContactCreateRequest(this ContactCreateRequest request)
        //{
        //    var result = new ContactCreateServiceRequest();
        //    var webServiceRequest = new ContactCreateWebServiceRequest();
        //    var contactCreateRequest = new ContactCreateRequest(request);
        //    webServiceRequest.ContactCreateRequest = contactCreateRequest;
        //    result.JsonRequest = JsonConvert.SerializeObject(webServiceRequest, Formatting.Indented);
        //    //ContactCreateRequest = webServiceRequest;
        //    return result.ContactCreateRequest;
        //}

        public static string ToWmContactCreateRequest(this DataObjects.ContactCreateRequest request)
        {
            return new ContactCreateServiceRequest(request).JsonRequest;
        }

        public static DataObjects.ContactCreateResponse ToContactCreateResponse(this ContactCreateWebServiceResponse response)
        {
            var result = new DataObjects.ContactCreateResponse(response.ContactCreateResponse.ContactCreateResponseDetail[0].ContactNameID);
            return result;
        }
    }
}
