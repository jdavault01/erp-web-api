using System;
using System.Collections.Generic;
using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;
using Pki.eBusiness.ErpApi.Entities.Account;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Partner = Pki.eBusiness.ErpApi.Entities.Account.Partner;
using SimplePartnerRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.SimplePartnerRequest;
using StorefrontPartnerRequest = Pki.eBusiness.ErpApi.Entities.DataObjects.PartnerRequest;
using PartnerResponse = Pki.eBusiness.ErpApi.Entities.DataObjects.PartnerResponse;

namespace Pki.eBusiness.ErpApi.DataAccess.Extensions
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

        public static PartnerResponse ToPartnerResponse(this PartnerWebServiceResponse1 response)
        {
            var result = new PartnerClientResponse();
            if (response.PartnerResponse.ErrorReturn != null && response.PartnerResponse.ErrorReturn[0] != null)
            {
                result.PartnerResponse = new PartnerResponse
                {
                    ErrorMessage = response.PartnerResponse.ErrorReturn[0].Error
                };
                return result.PartnerResponse;
            }

            result.PartnerResponse = new PartnerResponse
            {
                ERPHierarchyNumber = response?.PartnerResponse?.PartnerResponseHeader?.ERPHierarchyNumber,
                ERPHierarchyName = response?.PartnerResponse?.PartnerResponseHeader?.ERPHierarchyName,
            };
            result.PartnerResponse.Partners = new List<Partner>();
            if (response?.PartnerResponse?.PartnerResponseDetail != null)
            {
                foreach (var detail in response.PartnerResponse.PartnerResponseDetail)
                {
                    //var partnerResponseDetail = new PartnerResponseDetail();
                    PartnerType partnerType;
                    Enum.TryParse(detail.PartnerType, out partnerType);

                    var partner = new Partner
                    {
                        PartnerId = detail.PartnerID,
                        PartnerType = partnerType,
                        RadIndicator = detail.Partner[0].RADIndicator?.ToLower() == "true",
                        FirstName = detail.Partner[0].Name1 + " " + detail.Partner[0].Name2,
                        Street = detail.Partner[0].Address.Street,
                        City = detail.Partner[0].Address.City,
                        District = detail.Partner[0].Address.District,
                        Country = detail.Partner[0].Address.Country,
                        Fax = detail.Partner[0].Address.Fax,
                        PostalCode = detail.Partner[0].Address.PostalCode,
                        Region = detail.Partner[0].Address.Region,
                        State = detail.Partner[0].Address.Region,
                        Telephone = detail.Partner[0].Address.Telephone[0].Text?[0]
                    };

                    result.PartnerResponse.Partners.Add(partner);
                }
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

        //public static ContactCreateWebServiceRequest ToWmContactCreateRequest(this Pki.eBusiness.ErpApi.Entities.DataObjects.ContactCreateClientRequest request)
        //{
        //    return new ContactCreateServiceRequest(request).Request;
        //}

        //public static Pki.eBusiness.ErpApi.Entities.DataObjects.ContactCreateClientResponse ToContactCreateResponse(this ContactCreateWebServiceResponse response)
        //{
        //    var result = new ContactCreateClientResponse(response.ContactCreateResponse.ContactCreateResponseDetail[0].ContactNameID);
        //    return result;
        //}
    }
}
