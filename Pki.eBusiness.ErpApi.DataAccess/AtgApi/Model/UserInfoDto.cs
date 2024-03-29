/* 
 * ATG Store
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = Pki.eBusiness.ErpApi.DataAccess.Client.SwaggerDateConverter;

namespace Pki.eBusiness.ErpApi.DataAccess.Model
{
    /// <summary>
    /// UserInfoDto
    /// </summary>
    [DataContract]
    public partial class UserInfoDto :  IEquatable<UserInfoDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoDto" /> class.
        /// </summary>
        /// <param name="ActiveCountry">ActiveCountry.</param>
        /// <param name="ActiveLanguage">ActiveLanguage.</param>
        /// <param name="BillTo">BillTo.</param>
        /// <param name="ContactId">ContactId.</param>
        /// <param name="Email">Email.</param>
        /// <param name="ErpHierarchyNumber">ErpHierarchyNumber.</param>
        /// <param name="FirstName">FirstName.</param>
        /// <param name="IsActive">IsActive.</param>
        /// <param name="LastName">LastName.</param>
        /// <param name="LogonName">LogonName.</param>
        /// <param name="PunchoutCompanyCode">PunchoutCompanyCode.</param>
        /// <param name="ShipTo">ShipTo.</param>
        /// <param name="CompanyAddress">CompanyAddress.</param>
        /// <param name="AdditionalEmailNotifications">AdditionalEmailNotifications.</param>
        public UserInfoDto(string ActiveCountry = default(string), string ActiveLanguage = default(string), string BillTo = default(string), string ContactId = default(string), string Email = default(string), string ErpHierarchyNumber = default(string), string FirstName = default(string), int? IsActive = default(int?), string LastName = default(string), string LogonName = default(string), string PunchoutCompanyCode = default(string), string ShipTo = default(string), AddressDto CompanyAddress = default(AddressDto), List<AdditionalEmailNotificationDto> AdditionalEmailNotifications = default(List<AdditionalEmailNotificationDto>))
        {
            this.ActiveCountry = ActiveCountry;
            this.ActiveLanguage = ActiveLanguage;
            this.BillTo = BillTo;
            this.ContactId = ContactId;
            this.Email = Email;
            this.ErpHierarchyNumber = ErpHierarchyNumber;
            this.FirstName = FirstName;
            this.IsActive = IsActive;
            this.LastName = LastName;
            this.LogonName = LogonName;
            this.PunchoutCompanyCode = PunchoutCompanyCode;
            this.ShipTo = ShipTo;
            this.CompanyAddress = CompanyAddress;
            this.AdditionalEmailNotifications = AdditionalEmailNotifications;
        }
        
        /// <summary>
        /// Gets or Sets ActiveCountry
        /// </summary>
        [DataMember(Name="activeCountry", EmitDefaultValue=false)]
        public string ActiveCountry { get; set; }

        /// <summary>
        /// Gets or Sets ActiveLanguage
        /// </summary>
        [DataMember(Name="activeLanguage", EmitDefaultValue=false)]
        public string ActiveLanguage { get; set; }

        /// <summary>
        /// Gets or Sets BillTo
        /// </summary>
        [DataMember(Name="billTo", EmitDefaultValue=false)]
        public string BillTo { get; set; }

        /// <summary>
        /// Gets or Sets ContactId
        /// </summary>
        [DataMember(Name="contactId", EmitDefaultValue=false)]
        public string ContactId { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue=false)]
        public string Email { get; set; }

        /// <summary>
        /// Gets or Sets ErpHierarchyNumber
        /// </summary>
        [DataMember(Name="erpHierarchyNumber", EmitDefaultValue=false)]
        public string ErpHierarchyNumber { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name="firstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets IsActive
        /// </summary>
        [DataMember(Name="isActive", EmitDefaultValue=false)]
        public int? IsActive { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name="lastName", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets LogonName
        /// </summary>
        [DataMember(Name="logonName", EmitDefaultValue=false)]
        public string LogonName { get; set; }

        /// <summary>
        /// Gets or Sets PunchoutCompanyCode
        /// </summary>
        [DataMember(Name="punchoutCompanyCode", EmitDefaultValue=false)]
        public string PunchoutCompanyCode { get; set; }

        /// <summary>
        /// Gets or Sets ShipTo
        /// </summary>
        [DataMember(Name="shipTo", EmitDefaultValue=false)]
        public string ShipTo { get; set; }

        /// <summary>
        /// Gets or Sets CompanyAddress
        /// </summary>
        [DataMember(Name="companyAddress", EmitDefaultValue=false)]
        public AddressDto CompanyAddress { get; set; }

        /// <summary>
        /// Gets or Sets AdditionalEmailNotifications
        /// </summary>
        [DataMember(Name="additionalEmailNotifications", EmitDefaultValue=false)]
        public List<AdditionalEmailNotificationDto> AdditionalEmailNotifications { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class UserInfoDto {\n");
            sb.Append("  ActiveCountry: ").Append(ActiveCountry).Append("\n");
            sb.Append("  ActiveLanguage: ").Append(ActiveLanguage).Append("\n");
            sb.Append("  BillTo: ").Append(BillTo).Append("\n");
            sb.Append("  ContactId: ").Append(ContactId).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  ErpHierarchyNumber: ").Append(ErpHierarchyNumber).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  IsActive: ").Append(IsActive).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  LogonName: ").Append(LogonName).Append("\n");
            sb.Append("  PunchoutCompanyCode: ").Append(PunchoutCompanyCode).Append("\n");
            sb.Append("  ShipTo: ").Append(ShipTo).Append("\n");
            sb.Append("  CompanyAddress: ").Append(CompanyAddress).Append("\n");
            sb.Append("  AdditionalEmailNotifications: ").Append(AdditionalEmailNotifications).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as UserInfoDto);
        }

        /// <summary>
        /// Returns true if UserInfoDto instances are equal
        /// </summary>
        /// <param name="input">Instance of UserInfoDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserInfoDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ActiveCountry == input.ActiveCountry ||
                    (this.ActiveCountry != null &&
                    this.ActiveCountry.Equals(input.ActiveCountry))
                ) && 
                (
                    this.ActiveLanguage == input.ActiveLanguage ||
                    (this.ActiveLanguage != null &&
                    this.ActiveLanguage.Equals(input.ActiveLanguage))
                ) && 
                (
                    this.BillTo == input.BillTo ||
                    (this.BillTo != null &&
                    this.BillTo.Equals(input.BillTo))
                ) && 
                (
                    this.ContactId == input.ContactId ||
                    (this.ContactId != null &&
                    this.ContactId.Equals(input.ContactId))
                ) && 
                (
                    this.Email == input.Email ||
                    (this.Email != null &&
                    this.Email.Equals(input.Email))
                ) && 
                (
                    this.ErpHierarchyNumber == input.ErpHierarchyNumber ||
                    (this.ErpHierarchyNumber != null &&
                    this.ErpHierarchyNumber.Equals(input.ErpHierarchyNumber))
                ) && 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.IsActive == input.IsActive ||
                    (this.IsActive != null &&
                    this.IsActive.Equals(input.IsActive))
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.LogonName == input.LogonName ||
                    (this.LogonName != null &&
                    this.LogonName.Equals(input.LogonName))
                ) && 
                (
                    this.PunchoutCompanyCode == input.PunchoutCompanyCode ||
                    (this.PunchoutCompanyCode != null &&
                    this.PunchoutCompanyCode.Equals(input.PunchoutCompanyCode))
                ) && 
                (
                    this.ShipTo == input.ShipTo ||
                    (this.ShipTo != null &&
                    this.ShipTo.Equals(input.ShipTo))
                ) && 
                (
                    this.CompanyAddress == input.CompanyAddress ||
                    (this.CompanyAddress != null &&
                    this.CompanyAddress.Equals(input.CompanyAddress))
                ) && 
                (
                    this.AdditionalEmailNotifications == input.AdditionalEmailNotifications ||
                    this.AdditionalEmailNotifications != null &&
                    this.AdditionalEmailNotifications.SequenceEqual(input.AdditionalEmailNotifications)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.ActiveCountry != null)
                    hashCode = hashCode * 59 + this.ActiveCountry.GetHashCode();
                if (this.ActiveLanguage != null)
                    hashCode = hashCode * 59 + this.ActiveLanguage.GetHashCode();
                if (this.BillTo != null)
                    hashCode = hashCode * 59 + this.BillTo.GetHashCode();
                if (this.ContactId != null)
                    hashCode = hashCode * 59 + this.ContactId.GetHashCode();
                if (this.Email != null)
                    hashCode = hashCode * 59 + this.Email.GetHashCode();
                if (this.ErpHierarchyNumber != null)
                    hashCode = hashCode * 59 + this.ErpHierarchyNumber.GetHashCode();
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.IsActive != null)
                    hashCode = hashCode * 59 + this.IsActive.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                if (this.LogonName != null)
                    hashCode = hashCode * 59 + this.LogonName.GetHashCode();
                if (this.PunchoutCompanyCode != null)
                    hashCode = hashCode * 59 + this.PunchoutCompanyCode.GetHashCode();
                if (this.ShipTo != null)
                    hashCode = hashCode * 59 + this.ShipTo.GetHashCode();
                if (this.CompanyAddress != null)
                    hashCode = hashCode * 59 + this.CompanyAddress.GetHashCode();
                if (this.AdditionalEmailNotifications != null)
                    hashCode = hashCode * 59 + this.AdditionalEmailNotifications.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
