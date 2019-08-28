using Microsoft.Extensions.Logging;
using Pki.eBusiness.ErpApi.Contract.BL;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.Entities.DataObjects;

namespace Pki.eBusiness.ErpApi.Business.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IERPRestGateway _erpGateway;
        private readonly ILogger _logger;

        private const string NO_PRICE_RESPONSE = "No Price Respnose";
        public CompanyService(IWebMethodClient webMethodsClient, IERPRestGateway erpGateway, ILogger<CompanyService> logger)
        {
            _erpGateway = erpGateway;
            _logger = logger;
        }

        public CompanyContactsResponse GetCompanyContacts(CompanyContactsRequest companyContactRequest)
        {
            return _erpGateway.CompanyContacts(companyContactRequest);
        }

        public CompanyAddressesResponse GetCompanyAddresses(CompanyAddressesRequest companyAddressesRequest)
        {
            return _erpGateway.CompanyAddresses(companyAddressesRequest);
        }

        public CompanyInfoResponse GetCompanyName(CompanyInfoRequest companyInfoRequest)
        {
            return _erpGateway.CompanyInfo(companyInfoRequest);
        }
    }
}
