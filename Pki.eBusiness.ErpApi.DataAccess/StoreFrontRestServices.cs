using System;
using System.Globalization;
using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;

namespace Pki.eBusiness.ErpApi.DataAccess
{
    
    public partial class ContactCreateRequest
    {
        
        ContactCreateRequestHeader ContactCreateRequestHeader;
        
        ContactCreateRequestDetail ContactCreateRequestDetail;
        public ContactCreateRequest() { }

        public ContactCreateRequest(Entities.DataObjects.ContactCreateRequest request)
        {
            ContactCreateRequestHeader = new ContactCreateRequestHeader(request);
            ContactCreateRequestDetail = new ContactCreateRequestDetail(request);
        }

    }

    
    public partial class ContactCreateWebServiceRequest
    {
        
        public ContactCreateRequest ContactCreateRequest { get; set; }

        public ContactCreateWebServiceRequest() { }

        public ContactCreateWebServiceRequest (ContactCreateRequest contactCreateRequest)
        {
            ContactCreateRequest = contactCreateRequest;
        }
    }

    
    public partial class ContactCreateRequestHeader
    {
        
        public string PartnerID { get; set; }
        
        public string SalesOrgID { get; set; }
        
        public string DivisionID { get; set; }
        
        public string DistChannelID { get; set; }
        
        public Datetime Datetime { get; set; }
        public ContactCreateRequestHeader() { }
        public ContactCreateRequestHeader(Entities.DataObjects.ContactCreateRequest request)
        {
            var datetime3 = new Datetime()
            {
                Year = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture),
                Month = DateTime.Now.Month.ToString(CultureInfo.InvariantCulture),
                Day = DateTime.Now.Day.ToString(CultureInfo.InvariantCulture)
            };
            Datetime = datetime3;
            PartnerID = request.AccountNumber;
            SalesOrgID = request.SalesAreaInfo.SalesOrgId;
            DivisionID = request.SalesAreaInfo.DivisionId;
            DistChannelID = request.SalesAreaInfo.DistChannelId;

        }
    }

    
    public partial class ContactCreateRequestDetail
    {
        
        public string FirstName {get; set; }
        
        public string LastName {get; set; }
        
        public string Email { get; set; }
        
        public string Title { get; set; }
        
        public string Role { get; set; }
        
        public string Source { get; set; }
        
        public string SalesOrgID  { get; set; }
        
        public string DivisionID  { get; set; }
        
        public string DistChannelID { get; set; }
        
        public string ContactNameID { get; set; }
        
        Telephone[] Telephone { get; set; }

        public ContactCreateRequestDetail(Entities.DataObjects.ContactCreateRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
            Source = SourceType.Web.ToString();
            SalesOrgID = request.SalesAreaInfo.SalesOrgId;
            DivisionID = request.SalesAreaInfo.DivisionId;
            DistChannelID = request.SalesAreaInfo.DistChannelId;
        }
    }

    
    public partial class ContactCreateWebServiceResponse
    {
        
        public ContactCreateResponse ContactCreateResponse { get; set; }
    }


    
    public class ContactCreateResponse
    {
        
        public ContactCreateResponseHeader ContactCreateResponseHeader { get; set; }

        
        public ContactCreateResponseDetail[] ContactCreateResponseDetail { get; set; }

        
        public ErrorReturn[] ErrorReturn { get; set; }

    }

    
    public partial class ContactCreateResponseHeader
    {
        
        public string PartnerID { get; set; }
    }

    
    public partial class ContactCreateResponseDetail
    {
        
        public string ContactNameID { get; set; }

    }

    
    public partial class ErrorReturn
    {
        
        public string Timestamp { get; set; }
        
        public string ErrorNumber { get; set; }
        
        public string Error { get; set; }
        
        public string ErrorType { get; set; }
        
        public string ErrorDump { get; set; }
        
        public string InernalErrorNumber { get; set; }
        
        public string User { get; set; }
    }

    public enum SourceType
    {
        Web,
        Other
    }

 }
