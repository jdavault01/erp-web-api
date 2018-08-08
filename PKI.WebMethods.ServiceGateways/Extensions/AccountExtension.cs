using ClientModels = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;
using ServiceModels = PKI.eBusiness.WMService.Entities.Stubs.StoreFront;
using SimplePartnerRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.SimplePartnerRequest;
using StorefrontPartnerRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.PartnerRequest;
using WebMethodsPartnerResponse1 = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.PartnerWebServiceResponse1;
using ContactCreateRequest = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects.ContactCreateRequest;
using ContactCreateWebServiceResponse = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.ContactCreateWebServiceResponse;

namespace PKI.eBusiness.WMService.ServiceGateways.Extensions
{
    public static class AccountExtension
    {
        //Will be decomissioned after cart project
        public static ServiceModels.PartnerWebServiceRequest ToWmPartnerRequest(this StorefrontPartnerRequest request)
        {
            return new PartnerServiceRequest(request).WebServiceRequest;
        }

        public static ServiceModels.PartnerWebServiceRequest ToWmPartnerRequest(this SimplePartnerRequest request)
        {
            return new PartnerServiceRequest(request).WebServiceRequest;
        }

        public static ClientModels.PartnerResponse ToPartnerResponse(this WebMethodsPartnerResponse1 response)
        {
            return new ClientModels.PartnerClientResponse(response).PartnerResponse;
        }

        //public static ServiceModels.ContactCreateWebServiceRequest ToWmContactCreateRequest(this ContactCreateRequest request)
        //{
        //    return new ContactCreateServiceRequest(request).ContactCreateRequest;
        //}

        public static string ToWmContactCreateRequest(this ContactCreateRequest request)
        {
            return new ContactCreateServiceRequest(request).JsonRequest;
        }

        public static ClientModels.ContactCreateResponse ToContactCreateResponse(this ContactCreateWebServiceResponse response)
        {
            return new ClientModels.ContactCreateClientResponse(response).ContactCreateResponse;
        }
    }
}
