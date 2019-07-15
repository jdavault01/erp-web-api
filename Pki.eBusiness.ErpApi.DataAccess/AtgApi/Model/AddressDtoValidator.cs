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
    /// AddressDtoValidator
    /// </summary>
    [DataContract]
    public partial class AddressDtoValidator :  IEquatable<AddressDtoValidator>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressDtoValidator" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AddressDtoValidator() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressDtoValidator" /> class.
        /// </summary>
        /// <param name="FirstName">FirstName (required).</param>
        /// <param name="Address1">Address1 (required).</param>
        /// <param name="City">City (required).</param>
        /// <param name="PostalCode">PostalCode (required).</param>
        /// <param name="Address2">Address2.</param>
        /// <param name="Attention">Attention.</param>
        /// <param name="CompanyName">CompanyName.</param>
        /// <param name="Country">Country.</param>
        /// <param name="Fax">Fax.</param>
        /// <param name="Id">Id.</param>
        /// <param name="LastName">LastName.</param>
        /// <param name="PartnerId">PartnerId.</param>
        /// <param name="PartnerType">PartnerType.</param>
        /// <param name="Rad">Rad.</param>
        /// <param name="ServicePartType">ServicePartType.</param>
        /// <param name="State">State.</param>
        /// <param name="Telephone">Telephone.</param>
        public AddressDtoValidator(string FirstName = default(string), string Address1 = default(string), string City = default(string), string PostalCode = default(string), string Address2 = default(string), string Attention = default(string), string CompanyName = default(string), string Country = default(string), string Fax = default(string), string Id = default(string), string LastName = default(string), string PartnerId = default(string), string PartnerType = default(string), bool? Rad = default(bool?), string ServicePartType = default(string), string State = default(string), string Telephone = default(string))
        {
            // to ensure "FirstName" is required (not null)
            if (FirstName == null)
            {
                throw new InvalidDataException("FirstName is a required property for AddressDtoValidator and cannot be null");
            }
            else
            {
                this.FirstName = FirstName;
            }
            // to ensure "Address1" is required (not null)
            if (Address1 == null)
            {
                throw new InvalidDataException("Address1 is a required property for AddressDtoValidator and cannot be null");
            }
            else
            {
                this.Address1 = Address1;
            }
            // to ensure "City" is required (not null)
            if (City == null)
            {
                throw new InvalidDataException("City is a required property for AddressDtoValidator and cannot be null");
            }
            else
            {
                this.City = City;
            }
            // to ensure "PostalCode" is required (not null)
            if (PostalCode == null)
            {
                throw new InvalidDataException("PostalCode is a required property for AddressDtoValidator and cannot be null");
            }
            else
            {
                this.PostalCode = PostalCode;
            }
            this.Address2 = Address2;
            this.Attention = Attention;
            this.CompanyName = CompanyName;
            this.Country = Country;
            this.Fax = Fax;
            this.Id = Id;
            this.LastName = LastName;
            this.PartnerId = PartnerId;
            this.PartnerType = PartnerType;
            this.Rad = Rad;
            this.ServicePartType = ServicePartType;
            this.State = State;
            this.Telephone = Telephone;
        }
        
        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name="firstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets Address1
        /// </summary>
        [DataMember(Name="address1", EmitDefaultValue=false)]
        public string Address1 { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets PostalCode
        /// </summary>
        [DataMember(Name="postalCode", EmitDefaultValue=false)]
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or Sets Address2
        /// </summary>
        [DataMember(Name="address2", EmitDefaultValue=false)]
        public string Address2 { get; set; }

        /// <summary>
        /// Gets or Sets Attention
        /// </summary>
        [DataMember(Name="attention", EmitDefaultValue=false)]
        public string Attention { get; set; }

        /// <summary>
        /// Gets or Sets CompanyName
        /// </summary>
        [DataMember(Name="companyName", EmitDefaultValue=false)]
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets Fax
        /// </summary>
        [DataMember(Name="fax", EmitDefaultValue=false)]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name="lastName", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets PartnerId
        /// </summary>
        [DataMember(Name="partnerId", EmitDefaultValue=false)]
        public string PartnerId { get; set; }

        /// <summary>
        /// Gets or Sets PartnerType
        /// </summary>
        [DataMember(Name="partnerType", EmitDefaultValue=false)]
        public string PartnerType { get; set; }

        /// <summary>
        /// Gets or Sets Rad
        /// </summary>
        [DataMember(Name="rad", EmitDefaultValue=false)]
        public bool? Rad { get; set; }

        /// <summary>
        /// Gets or Sets ServicePartType
        /// </summary>
        [DataMember(Name="servicePartType", EmitDefaultValue=false)]
        public string ServicePartType { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets Telephone
        /// </summary>
        [DataMember(Name="telephone", EmitDefaultValue=false)]
        public string Telephone { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddressDtoValidator {\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  Address1: ").Append(Address1).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  PostalCode: ").Append(PostalCode).Append("\n");
            sb.Append("  Address2: ").Append(Address2).Append("\n");
            sb.Append("  Attention: ").Append(Attention).Append("\n");
            sb.Append("  CompanyName: ").Append(CompanyName).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  Fax: ").Append(Fax).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  PartnerId: ").Append(PartnerId).Append("\n");
            sb.Append("  PartnerType: ").Append(PartnerType).Append("\n");
            sb.Append("  Rad: ").Append(Rad).Append("\n");
            sb.Append("  ServicePartType: ").Append(ServicePartType).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Telephone: ").Append(Telephone).Append("\n");
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
            return this.Equals(input as AddressDtoValidator);
        }

        /// <summary>
        /// Returns true if AddressDtoValidator instances are equal
        /// </summary>
        /// <param name="input">Instance of AddressDtoValidator to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressDtoValidator input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.Address1 == input.Address1 ||
                    (this.Address1 != null &&
                    this.Address1.Equals(input.Address1))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.PostalCode == input.PostalCode ||
                    (this.PostalCode != null &&
                    this.PostalCode.Equals(input.PostalCode))
                ) && 
                (
                    this.Address2 == input.Address2 ||
                    (this.Address2 != null &&
                    this.Address2.Equals(input.Address2))
                ) && 
                (
                    this.Attention == input.Attention ||
                    (this.Attention != null &&
                    this.Attention.Equals(input.Attention))
                ) && 
                (
                    this.CompanyName == input.CompanyName ||
                    (this.CompanyName != null &&
                    this.CompanyName.Equals(input.CompanyName))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.Fax == input.Fax ||
                    (this.Fax != null &&
                    this.Fax.Equals(input.Fax))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.PartnerId == input.PartnerId ||
                    (this.PartnerId != null &&
                    this.PartnerId.Equals(input.PartnerId))
                ) && 
                (
                    this.PartnerType == input.PartnerType ||
                    (this.PartnerType != null &&
                    this.PartnerType.Equals(input.PartnerType))
                ) && 
                (
                    this.Rad == input.Rad ||
                    (this.Rad != null &&
                    this.Rad.Equals(input.Rad))
                ) && 
                (
                    this.ServicePartType == input.ServicePartType ||
                    (this.ServicePartType != null &&
                    this.ServicePartType.Equals(input.ServicePartType))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.Telephone == input.Telephone ||
                    (this.Telephone != null &&
                    this.Telephone.Equals(input.Telephone))
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
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.Address1 != null)
                    hashCode = hashCode * 59 + this.Address1.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.PostalCode != null)
                    hashCode = hashCode * 59 + this.PostalCode.GetHashCode();
                if (this.Address2 != null)
                    hashCode = hashCode * 59 + this.Address2.GetHashCode();
                if (this.Attention != null)
                    hashCode = hashCode * 59 + this.Attention.GetHashCode();
                if (this.CompanyName != null)
                    hashCode = hashCode * 59 + this.CompanyName.GetHashCode();
                if (this.Country != null)
                    hashCode = hashCode * 59 + this.Country.GetHashCode();
                if (this.Fax != null)
                    hashCode = hashCode * 59 + this.Fax.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                if (this.PartnerId != null)
                    hashCode = hashCode * 59 + this.PartnerId.GetHashCode();
                if (this.PartnerType != null)
                    hashCode = hashCode * 59 + this.PartnerType.GetHashCode();
                if (this.Rad != null)
                    hashCode = hashCode * 59 + this.Rad.GetHashCode();
                if (this.ServicePartType != null)
                    hashCode = hashCode * 59 + this.ServicePartType.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.Telephone != null)
                    hashCode = hashCode * 59 + this.Telephone.GetHashCode();
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