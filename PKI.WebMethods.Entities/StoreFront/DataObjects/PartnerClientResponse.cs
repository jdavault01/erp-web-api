using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using PKI.eBusiness.WMService.Entities.StoreFront.Account;
using WebMethodsPartnerResponse1 = PKI.eBusiness.WMService.Entities.Stubs.StoreFront.PartnerWebServiceResponse1;

namespace PKI.eBusiness.WMService.Entities.StoreFront.DataObjects
{
    [DataContract]
    public class PartnerClientResponse : EntityBase
    {
        [DataMember]
        public PartnerResponse PartnerResponse { get; set; }

        public PartnerClientResponse(WebMethodsPartnerResponse1 response)
        {

            PartnerResponse = new PartnerResponse
            {
                PartnerResponseHeader = new PartnerResponseHeader()
                {
                    ERPHierarchyNumber = response.PartnerResponse.PartnerResponseHeader.ERPHierarchyNumber,
                    ERPHierarchyName = response.PartnerResponse.PartnerResponseHeader.ERPHierarchyName,
                },

            };
            PartnerResponse.PartnerResponseDetails = new List<PartnerResponseDetail>();
            foreach (var detail in response.PartnerResponse.PartnerResponseDetail)
            {
                var partnerResponseDetail = new PartnerResponseDetail();
                PartnerType partnerType;
                Enum.TryParse(detail.PartnerType, out partnerType);

                partnerResponseDetail.Partner = new Partner
                {
                    PartnerId = detail.PartnerID,
                    PartnerType = partnerType,
                    RadIndicator = detail.Partner[0].RADIndicator,
                    Name1 = detail.Partner[0].Name1,
                    Name2 = detail.Partner[0].Name2,
                    Name3 = detail.Partner[0].Name3,
                    Name4 = detail.Partner[0].Name4,
                    Addresses = new List<Address>()
                };


                var address = new Address
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
                PartnerResponse.PartnerResponseDetails.Add(partnerResponseDetail);
            }

        }

    }

    [DataContract]
    public class PartnerResponse : EntityBase
    {
        #region Private variables

        [DataMember]
        public PartnerResponseHeader PartnerResponseHeader { get; set; }

        [DataMember]
        public List<PartnerResponseDetail> PartnerResponseDetails { get; set; }

        #endregion // Private variables
    }
    /// <summary>
    /// Order Response Detail
    /// </summary>
    [DataContract]
    public class PartnerResponseDetail : EntityBase
    {
        #region Properties

        [DataMember]
        public Partner Partner { get; set; }

        #endregion // Properties

    }

    [DataContract]
    public class PartnerResponseHeader : EntityBase
    {
        #region Properties

        [DataMember]
        public string ERPHierarchyNumber { get; set; }

        [DataMember]
        public string ERPHierarchyName { get; set; }

        #endregion

    }

}
