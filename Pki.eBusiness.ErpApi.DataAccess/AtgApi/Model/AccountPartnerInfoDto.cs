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
    /// AccountPartnerInfoDto
    /// </summary>
    [DataContract]
    public partial class AccountPartnerInfoDto :  IEquatable<AccountPartnerInfoDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountPartnerInfoDto" /> class.
        /// </summary>
        /// <param name="Active">Active.</param>
        /// <param name="ErpHierarchyNumber">ErpHierarchyNumber.</param>
        /// <param name="ShipTo">ShipTo.</param>
        /// <param name="BillTos">BillTos.</param>
        public AccountPartnerInfoDto(bool? Active = default(bool?), Object ErpHierarchyNumber = default(Object), AddressDto ShipTo = default(AddressDto), List<AddressDto> BillTos = default(List<AddressDto>))
        {
            this.Active = Active;
            this.ErpHierarchyNumber = ErpHierarchyNumber;
            this.ShipTo = ShipTo;
            this.BillTos = BillTos;
        }
        
        /// <summary>
        /// Gets or Sets Active
        /// </summary>
        [DataMember(Name="active", EmitDefaultValue=false)]
        public bool? Active { get; set; }

        /// <summary>
        /// Gets or Sets ErpHierarchyNumber
        /// </summary>
        [DataMember(Name="erpHierarchyNumber", EmitDefaultValue=false)]
        public Object ErpHierarchyNumber { get; set; }

        /// <summary>
        /// Gets or Sets ShipTo
        /// </summary>
        [DataMember(Name="shipTo", EmitDefaultValue=false)]
        public AddressDto ShipTo { get; set; }

        /// <summary>
        /// Gets or Sets BillTos
        /// </summary>
        [DataMember(Name="billTos", EmitDefaultValue=false)]
        public List<AddressDto> BillTos { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AccountPartnerInfoDto {\n");
            sb.Append("  Active: ").Append(Active).Append("\n");
            sb.Append("  ErpHierarchyNumber: ").Append(ErpHierarchyNumber).Append("\n");
            sb.Append("  ShipTo: ").Append(ShipTo).Append("\n");
            sb.Append("  BillTos: ").Append(BillTos).Append("\n");
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
            return this.Equals(input as AccountPartnerInfoDto);
        }

        /// <summary>
        /// Returns true if AccountPartnerInfoDto instances are equal
        /// </summary>
        /// <param name="input">Instance of AccountPartnerInfoDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AccountPartnerInfoDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Active == input.Active ||
                    (this.Active != null &&
                    this.Active.Equals(input.Active))
                ) && 
                (
                    this.ErpHierarchyNumber == input.ErpHierarchyNumber ||
                    (this.ErpHierarchyNumber != null &&
                    this.ErpHierarchyNumber.Equals(input.ErpHierarchyNumber))
                ) && 
                (
                    this.ShipTo == input.ShipTo ||
                    (this.ShipTo != null &&
                    this.ShipTo.Equals(input.ShipTo))
                ) && 
                (
                    this.BillTos == input.BillTos ||
                    this.BillTos != null &&
                    this.BillTos.SequenceEqual(input.BillTos)
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
                if (this.Active != null)
                    hashCode = hashCode * 59 + this.Active.GetHashCode();
                if (this.ErpHierarchyNumber != null)
                    hashCode = hashCode * 59 + this.ErpHierarchyNumber.GetHashCode();
                if (this.ShipTo != null)
                    hashCode = hashCode * 59 + this.ShipTo.GetHashCode();
                if (this.BillTos != null)
                    hashCode = hashCode * 59 + this.BillTos.GetHashCode();
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