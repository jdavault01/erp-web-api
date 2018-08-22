﻿using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using StorefrontContactCreateRequest = Pki.eBusiness.WebApi.Entities.StoreFront.DataObjects.ContactCreateRequest;

namespace Pki.eBusiness.WebApi.DataAccess.Extensions
{
    [DataContract]
    public class ContactCreateServiceRequest
    {
        [DataMember]
        public ContactCreateWebServiceRequest ContactCreateRequest;
        [DataMember]
        public String JsonRequest { get; set; }

        public ContactCreateServiceRequest(StorefrontContactCreateRequest clientRequest)
        {
            var webServiceRequest = new ContactCreateWebServiceRequest();
            var contactCreateRequest = new ContactCreateRequest(clientRequest);
            webServiceRequest.ContactCreateRequest = contactCreateRequest;
            JsonRequest = JsonConvert.SerializeObject(webServiceRequest, Formatting.Indented);

        }
    }
}