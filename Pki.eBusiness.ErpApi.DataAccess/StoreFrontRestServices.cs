using System;
using System.Globalization;
using System.Runtime.Serialization;
using Pki.eBusiness.ErpApi.DataAccess.StoreFrontWebServices;

namespace Pki.eBusiness.ErpApi.DataAccess
{

    [DataContract]
    public partial class ContactCreateRequest
    {
        [DataMember]
        ContactCreateRequestHeader ContactCreateRequestHeader;
        [DataMember]
        ContactCreateRequestDetail ContactCreateRequestDetail;
        public ContactCreateRequest() { }

        public ContactCreateRequest(Entities.DataObjects.ContactCreateRequest request)
        {
            ContactCreateRequestHeader = new ContactCreateRequestHeader(request);
            ContactCreateRequestDetail = new ContactCreateRequestDetail(request);
        }

    }


    [DataContract]
    public partial class ContactCreateWebServiceRequest
    {
        [DataMember]
        public ContactCreateRequest ContactCreateRequest { get; set; }

        public ContactCreateWebServiceRequest() { }

        public ContactCreateWebServiceRequest (ContactCreateRequest contactCreateRequest)
        {
            ContactCreateRequest = contactCreateRequest;
        }
    }


    [DataContract]
    public partial class ContactCreateRequestHeader
    {
        [DataMember]
        public string PartnerID { get; set; }
        [DataMember]
        public string SalesOrgID { get; set; }
        [DataMember]
        public string DivisionID { get; set; }
        [DataMember]
        public string DistChannelID { get; set; }
        [DataMember]
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


    [DataContract]
    public partial class ContactCreateRequestDetail
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Role { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string SalesOrgID { get; set; }
        [DataMember]
        public string DivisionID { get; set; }
        [DataMember]
        public string DistChannelID { get; set; }
        [DataMember]
        public string ContactNameID { get; set; }
        [DataMember]
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

    [DataContract]
    public partial class ContactCreateWebServiceResponse
    {
        [DataMember]
        public ContactCreateResponse ContactCreateResponse { get; set; }
    }



    [DataContract]
    public class ContactCreateResponse
    {
        [DataMember]
        public ContactCreateResponseHeader ContactCreateResponseHeader { get; set; }

        [DataMember]
        public ContactCreateResponseDetail[] ContactCreateResponseDetail { get; set; }

        [DataMember]
        public ErrorReturn[] ErrorReturn { get; set; }

    }


    [DataContract]
    public partial class ContactCreateResponseHeader
    {
        [DataMember]
        public string PartnerID { get; set; }
    }


    [DataContract]
    public partial class ContactCreateResponseDetail
    {
        [DataMember]
        public string ContactNameID { get; set; }

    }


    [DataContract]
    public partial class ErrorReturn
    {
        [DataMember]
        public string Timestamp { get; set; }
        [DataMember]
        public string ErrorNumber { get; set; }
        [DataMember]
        public string Error { get; set; }
        [DataMember]
        public string ErrorType { get; set; }
        [DataMember]
        public string ErrorDump { get; set; }
        [DataMember]
        public string InernalErrorNumber { get; set; }
        [DataMember]
        public string User { get; set; }
    }

    public enum SourceType
    {
        Web,
        Other
    }

 }
