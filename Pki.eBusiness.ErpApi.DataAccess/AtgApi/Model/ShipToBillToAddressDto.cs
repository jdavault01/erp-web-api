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
    /// ShipToBillToAddressDto
    /// </summary>
    [DataContract]
    public partial class ShipToBillToAddressDto :  IEquatable<ShipToBillToAddressDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipToBillToAddressDto" /> class.
        /// </summary>
        /// <param name="ErpHierarchyNumber">ErpHierarchyNumber.</param>
        /// <param name="ShippingAddress">ShippingAddress.</param>
        /// <param name="BillingAddress">BillingAddress.</param>
        public ShipToBillToAddressDto(string ErpHierarchyNumber = default(string), AddressDto ShippingAddress = default(AddressDto), AddressDto BillingAddress = default(AddressDto))
        {
            this.ErpHierarchyNumber = ErpHierarchyNumber;
            this.ShippingAddress = ShippingAddress;
            this.BillingAddress = BillingAddress;
        }
        
        /// <summary>
        /// Gets or Sets ErpHierarchyNumber
        /// </summary>
        [DataMember(Name="erpHierarchyNumber", EmitDefaultValue=false)]
        public string ErpHierarchyNumber { get; set; }

        /// <summary>
        /// Gets or Sets ShippingAddress
        /// </summary>
        [DataMember(Name="shippingAddress", EmitDefaultValue=false)]
        public AddressDto ShippingAddress { get; set; }

        /// <summary>
        /// Gets or Sets BillingAddress
        /// </summary>
        [DataMember(Name="billingAddress", EmitDefaultValue=false)]
        public AddressDto BillingAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ShipToBillToAddressDto {\n");
            sb.Append("  ErpHierarchyNumber: ").Append(ErpHierarchyNumber).Append("\n");
            sb.Append("  ShippingAddress: ").Append(ShippingAddress).Append("\n");
            sb.Append("  BillingAddress: ").Append(BillingAddress).Append("\n");
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
            return this.Equals(input as ShipToBillToAddressDto);
        }

        /// <summary>
        /// Returns true if ShipToBillToAddressDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ShipToBillToAddressDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShipToBillToAddressDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ErpHierarchyNumber == input.ErpHierarchyNumber ||
                    (this.ErpHierarchyNumber != null &&
                    this.ErpHierarchyNumber.Equals(input.ErpHierarchyNumber))
                ) && 
                (
                    this.ShippingAddress == input.ShippingAddress ||
                    (this.ShippingAddress != null &&
                    this.ShippingAddress.Equals(input.ShippingAddress))
                ) && 
                (
                    this.BillingAddress == input.BillingAddress ||
                    (this.BillingAddress != null &&
                    this.BillingAddress.Equals(input.BillingAddress))
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
                if (this.ErpHierarchyNumber != null)
                    hashCode = hashCode * 59 + this.ErpHierarchyNumber.GetHashCode();
                if (this.ShippingAddress != null)
                    hashCode = hashCode * 59 + this.ShippingAddress.GetHashCode();
                if (this.BillingAddress != null)
                    hashCode = hashCode * 59 + this.BillingAddress.GetHashCode();
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