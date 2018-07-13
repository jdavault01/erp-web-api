using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;
using StoreFrontObject = PKI.eBusiness.WMService.Entities.StoreFront.DataObjects;

namespace PKI.eBusiness.WMService.Entities.Stubs.StoreFront
{

    public partial class ContactCreateRequest
    {
        public ContactCreateRequest()
        {
        }

        public ContactCreateRequest(StoreFrontObject.ContactCreateRequest request)
        {
            ContactCreateRequestHeader = new ContactCreateRequestHeader(request);
            ContactCreateRequestDetail = new ContactCreateRequestDetail(request);
            //var contactCreateRequestDetail = new ContactCreateRequestDetail(request);
            //var details = new ContactCreateRequestDetail[1];
            //details[0] = contactCreateRequestDetail;
            //ContactCreateRequestDetail = details;
        }

    }

    public partial class ContactCreateRequestHeader
    {
        public ContactCreateRequestHeader()
        {

        }
        public ContactCreateRequestHeader(StoreFrontObject.ContactCreateRequest request)
        {
            var dateTime3 = new Datetime3()
            {
                Year = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture),
                Month = DateTime.Now.Month.ToString(CultureInfo.InvariantCulture),
                Day = DateTime.Now.Day.ToString(CultureInfo.InvariantCulture)
            };
            this.Datetime = dateTime3;
            this.PartnerID = request.AccountNumber;
            this.SalesOrgID = request.SalesAreaInfo.SalesOrgId;
            this.DivisionID = request.SalesAreaInfo.DivisionId;
            this.DistChannelID = request.SalesAreaInfo.DistChannelId;

        }

        public ContactCreateRequestHeader(String accountNumber, DateTime date)
        {
            var dateTime3 = new Datetime3()
            {
                Year = date.Year.ToString(CultureInfo.InvariantCulture),
                Month = date.Month.ToString(CultureInfo.InvariantCulture),
                Day = date.Day.ToString(CultureInfo.InvariantCulture)
            };
        }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://npsv04.perkinelmer.com/services:StorefrontWebServices")]
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
            var year = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
            var mon = DateTime.Now.Month.ToString(CultureInfo.InvariantCulture);
            var day = DateTime.Now.Day.ToString(CultureInfo.InvariantCulture);
        }

        public Date(DateTime date)
        {
            var year = date.Year.ToString(CultureInfo.InvariantCulture);
            var mon = date.Month.ToString(CultureInfo.InvariantCulture);
            var day = date.Day.ToString(CultureInfo.InvariantCulture);
        }


    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://npsv04.perkinelmer.com/services:StorefrontWebServices")]

    public partial class ContactCreateRequestDetail
    {
        public ContactCreateRequestDetail(StoreFrontObject.ContactCreateRequest request)
        {
            FirstName = request.FirstName;
            LastName = request.LastName;
            Email = request.Email;
            Source = "Web";
            SalesOrgID = request.SalesAreaInfo.SalesOrgId;
            DivisionID = request.SalesAreaInfo.DivisionId;
            DistChannelID = request.SalesAreaInfo.DistChannelId;
        }
    }


    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://npsv04.perkinelmer.com/services:StorefrontWebServices")]
    public class Response
    {
        [DataMember]
        public ResponseHeader ContactCreateResponseHeader { get; set; }

        [DataMember]
        public Contact[] ContactCreateResponseDetail { get; set; }

        [DataMember]
        public Error[] ErrorReturn { get; set; }

    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://npsv04.perkinelmer.com/services:StorefrontWebServices")]
    public struct ResponseHeader
    {
        [DataMember]
        public string PartnerID { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://npsv04.perkinelmer.com/services:StorefrontWebServices")]
    public struct Contact
    {
        [DataMember]
        public string ContactNameID { get; set; }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2634.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://npsv04.perkinelmer.com/services:StorefrontWebServices")]
    public struct Error
    {
        [DataMember]
        public string Timestamp { get; set; }
    }

}
