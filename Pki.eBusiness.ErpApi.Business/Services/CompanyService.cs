using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;
using Pki.eBusiness.ErpApi.Logger;

namespace Pki.eBusiness.ErpApi.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IERPRestGateway _erpGateway;

        private const string NO_PRICE_RESPONSE = "No Price Respnose";

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        public CompanyService(IWebMethodClient webMethodsClient, IShopCommerceServiceGateway shopCommerceServiceAgent, IERPRestGateway erpGateway)
        {
            _erpGateway = erpGateway;
        }

        public CompanyContactsResponse GetCompanyContacts(CompanyContactsRequest companyContactRequest)
        {
            return _erpGateway.GetCompanyContacts(companyContactRequest);
        }

        public CompanyAddressesResponse GetCompanyAddresses(CompanyAddressesRequest companyAddressesRequest)
        {
            return _erpGateway.GetCompanyAddresses(companyAddressesRequest);
        }

        public CompanyInfoResponse GetCompanyName(CompanyInfoRequest companyInfoRequest)
        {
            return _erpGateway.GetCompanyInfo(companyInfoRequest);
        }
    }
}
