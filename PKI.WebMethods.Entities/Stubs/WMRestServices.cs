using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.Entities.Stubs.StoreFront
{
    [DataContract]
    public class ContactCreateWebServiceRequest
    {
        [DataMember]
        public Request ContactCreateRequest { get; set; }
    }

    [DataContract]
    public class Request
    {
        [DataMember]
        public RequestHeader ContactCreateRequestHeader { get; set; }
        [DataMember]
        public RequestDetail ContactCreateRequestDetail { get; set; }

        public Request(ContactCreateRequest request)
        {
            ContactCreateRequestHeader = new RequestHeader(request.AccountNumber);
            ContactCreateRequestDetail = new RequestDetail(request);
        }

    }

    public class RequestHeader
    {
        [DataMember]
        public Date Datetime { get; set; }
        [DataMember]
        public string PartnerID { get; set; }

        public RequestHeader(String accountNumber)
        {
            this.Datetime = new Date(DateTime.Now);
            this.PartnerID = accountNumber;
        }

        public RequestHeader(String accountNumber, DateTime date)
        {
            this.Datetime = new Date(date);
            this.PartnerID = accountNumber;
        }

    }

    public class Date
    {
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string Month { get; set; }
        [DataMember]
        public string Day { get; set; }

        public Date() 
        {
            var year = DateTime.Now.Year.ToString();
            var mon = DateTime.Now.Month.ToString();
            var day = DateTime.Now.Day.ToString();
        }

        public Date(DateTime date)
        {
            var year = date.Year.ToString();
            var mon = date.Month.ToString();
            var day = date.Day.ToString();
        }


    }

    public class RequestDetail
    {
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Source { get; set; }
        [DataMember]
        public string SalesOrgID { get; set; }
        [DataMember]
        public string DivisionID { get; set; }
        [DataMember]
        public string DistChannelID { get; set; }

        public RequestDetail(ContactCreateRequest request)
        {
            this.FirstName = request.FirstName;
            this.LastName = request.LastName;
            this.Email = request.Email;
            this.Source = "Web";
            this.SalesOrgID = request.SalesAreaInfo.SalesOrgId;
            this.DivisionID = request.SalesAreaInfo.DivisionId;
            this.DistChannelID = request.SalesAreaInfo.DistChannelId;
        }
    }

    [DataContract]
    public class ContactCreateWebServiceResponse
    {
        [DataMember]
        public Response ContactCreateResponse { get; set; }
    }

    [DataContract]
    public class Response
    {
        [DataMember]
        public ResponseHeader ContactCreateResponseHeader { get; set; }

        [DataMember]
        public Contact[] ContactCreateResponseDetail { get; set; }

        [DataMember]
        public Error[] ErrorReturn { get; set; }

    }

    public struct ResponseHeader
    {
        [DataMember]
        public string PartnerID { get; set; }
    }

    public struct Contact
    {
        [DataMember]
        public string ContactNameID { get; set; }
    }

    public struct Error
    {
        [DataMember]
        public string Timestamp { get; set; }
    }

}
