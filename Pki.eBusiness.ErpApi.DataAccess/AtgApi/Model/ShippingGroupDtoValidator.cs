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
    /// ShippingGroupDtoValidator
    /// </summary>
    [DataContract]
    public partial class ShippingGroupDtoValidator :  IEquatable<ShippingGroupDtoValidator>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShippingGroupDtoValidator" /> class.
        /// </summary>
        /// <param name="DeliveryInstructions">DeliveryInstructions.</param>
        /// <param name="DeliveryStatus">DeliveryStatus.</param>
        /// <param name="InternalDeliveryInstructions">InternalDeliveryInstructions.</param>
        /// <param name="SplInstructions">SplInstructions.</param>
        /// <param name="SplInstructionsCategory">SplInstructionsCategory.</param>
        /// <param name="ShipToAddress">ShipToAddress.</param>
        public ShippingGroupDtoValidator(string DeliveryInstructions = default(string), string DeliveryStatus = default(string), string InternalDeliveryInstructions = default(string), string SplInstructions = default(string), string SplInstructionsCategory = default(string), AddressDtoValidator ShipToAddress = default(AddressDtoValidator))
        {
            this.DeliveryInstructions = DeliveryInstructions;
            this.DeliveryStatus = DeliveryStatus;
            this.InternalDeliveryInstructions = InternalDeliveryInstructions;
            this.SplInstructions = SplInstructions;
            this.SplInstructionsCategory = SplInstructionsCategory;
            this.ShipToAddress = ShipToAddress;
        }
        
        /// <summary>
        /// Gets or Sets DeliveryInstructions
        /// </summary>
        [DataMember(Name="deliveryInstructions", EmitDefaultValue=false)]
        public string DeliveryInstructions { get; set; }

        /// <summary>
        /// Gets or Sets DeliveryStatus
        /// </summary>
        [DataMember(Name="deliveryStatus", EmitDefaultValue=false)]
        public string DeliveryStatus { get; set; }

        /// <summary>
        /// Gets or Sets InternalDeliveryInstructions
        /// </summary>
        [DataMember(Name="internalDeliveryInstructions", EmitDefaultValue=false)]
        public string InternalDeliveryInstructions { get; set; }

        /// <summary>
        /// Gets or Sets SplInstructions
        /// </summary>
        [DataMember(Name="splInstructions", EmitDefaultValue=false)]
        public string SplInstructions { get; set; }

        /// <summary>
        /// Gets or Sets SplInstructionsCategory
        /// </summary>
        [DataMember(Name="splInstructionsCategory", EmitDefaultValue=false)]
        public string SplInstructionsCategory { get; set; }

        /// <summary>
        /// Gets or Sets ShipToAddress
        /// </summary>
        [DataMember(Name="shipToAddress", EmitDefaultValue=false)]
        public AddressDtoValidator ShipToAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ShippingGroupDtoValidator {\n");
            sb.Append("  DeliveryInstructions: ").Append(DeliveryInstructions).Append("\n");
            sb.Append("  DeliveryStatus: ").Append(DeliveryStatus).Append("\n");
            sb.Append("  InternalDeliveryInstructions: ").Append(InternalDeliveryInstructions).Append("\n");
            sb.Append("  SplInstructions: ").Append(SplInstructions).Append("\n");
            sb.Append("  SplInstructionsCategory: ").Append(SplInstructionsCategory).Append("\n");
            sb.Append("  ShipToAddress: ").Append(ShipToAddress).Append("\n");
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
            return this.Equals(input as ShippingGroupDtoValidator);
        }

        /// <summary>
        /// Returns true if ShippingGroupDtoValidator instances are equal
        /// </summary>
        /// <param name="input">Instance of ShippingGroupDtoValidator to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ShippingGroupDtoValidator input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DeliveryInstructions == input.DeliveryInstructions ||
                    (this.DeliveryInstructions != null &&
                    this.DeliveryInstructions.Equals(input.DeliveryInstructions))
                ) && 
                (
                    this.DeliveryStatus == input.DeliveryStatus ||
                    (this.DeliveryStatus != null &&
                    this.DeliveryStatus.Equals(input.DeliveryStatus))
                ) && 
                (
                    this.InternalDeliveryInstructions == input.InternalDeliveryInstructions ||
                    (this.InternalDeliveryInstructions != null &&
                    this.InternalDeliveryInstructions.Equals(input.InternalDeliveryInstructions))
                ) && 
                (
                    this.SplInstructions == input.SplInstructions ||
                    (this.SplInstructions != null &&
                    this.SplInstructions.Equals(input.SplInstructions))
                ) && 
                (
                    this.SplInstructionsCategory == input.SplInstructionsCategory ||
                    (this.SplInstructionsCategory != null &&
                    this.SplInstructionsCategory.Equals(input.SplInstructionsCategory))
                ) && 
                (
                    this.ShipToAddress == input.ShipToAddress ||
                    (this.ShipToAddress != null &&
                    this.ShipToAddress.Equals(input.ShipToAddress))
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
                if (this.DeliveryInstructions != null)
                    hashCode = hashCode * 59 + this.DeliveryInstructions.GetHashCode();
                if (this.DeliveryStatus != null)
                    hashCode = hashCode * 59 + this.DeliveryStatus.GetHashCode();
                if (this.InternalDeliveryInstructions != null)
                    hashCode = hashCode * 59 + this.InternalDeliveryInstructions.GetHashCode();
                if (this.SplInstructions != null)
                    hashCode = hashCode * 59 + this.SplInstructions.GetHashCode();
                if (this.SplInstructionsCategory != null)
                    hashCode = hashCode * 59 + this.SplInstructionsCategory.GetHashCode();
                if (this.ShipToAddress != null)
                    hashCode = hashCode * 59 + this.ShipToAddress.GetHashCode();
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
