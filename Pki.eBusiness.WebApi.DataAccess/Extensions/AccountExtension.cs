using System;
using System.Collections.Generic;
using Pki.eBusiness.WebApi.DataAccess.StoreFrontWebServices;
using Pki.eBusiness.WebApi.Entities.StoreFront.Account;
using Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects;
using SimplePartnerRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.SimplePartnerRequest;
using StorefrontPartnerRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.PartnerRequest;
using PartnerResponse = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.PartnerResponse;
using PartnerResponseDetail = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.PartnerResponseDetail;
using PartnerResponseHeader = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.PartnerResponseHeader;

namespace Pki.eBusiness.WebApi.DataAccess.Extensions
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
            result.PartnerResponse = new PartnerResponse
            {
                PartnerResponseHeader = new PartnerResponseHeader()
                {
                    ERPHierarchyNumber = response.PartnerResponse.PartnerResponseHeader.ERPHierarchyNumber,
                    ERPHierarchyName = response.PartnerResponse.PartnerResponseHeader.ERPHierarchyName,
                },

            };
            result.PartnerResponse.PartnerResponseDetails = new List<PartnerResponseDetail>();
            foreach (var detail in response.PartnerResponse.PartnerResponseDetail)
            {
                var partnerResponseDetail = new PartnerResponseDetail();
                PartnerType partnerType;
                Enum.TryParse(detail.PartnerType, out partnerType);

                partnerResponseDetail.Partner = new Pki.eBusiness.WebApi.Entities.StoreFront.Account.Partner
                {
                    PartnerId = detail.PartnerID,
                    PartnerType = partnerType,
                    RadIndicator = detail.Partner[0].RADIndicator,
                    Name1 = detail.Partner[0].Name1,
                    Name2 = detail.Partner[0].Name2,
                    Name3 = detail.Partner[0].Name3,
                    Name4 = detail.Partner[0].Name4,
                    Addresses = new List<Pki.eBusiness.WebApi.Entities.StoreFront.Account.Address>()
                };


                var address = new Pki.eBusiness.WebApi.Entities.StoreFront.Account.Address
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

        public static string ToWmContactCreateRequest(this Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.ContactCreateRequest request)
        {
            return new ContactCreateServiceRequest(request).JsonRequest;
        }

        public static Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.ContactCreateResponse ToContactCreateResponse(this ContactCreateWebServiceResponse response)
        {
            var result = new Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.ContactCreateResponse(response.ContactCreateResponse.ContactCreateResponseDetail[0].ContactNameID);
            return result;
        }
    }
}
