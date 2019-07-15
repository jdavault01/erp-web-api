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
    /// PriceAdjustmentDto
    /// </summary>
    [DataContract]
    public partial class PriceAdjustmentDto :  IEquatable<PriceAdjustmentDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PriceAdjustmentDto" /> class.
        /// </summary>
        /// <param name="Discount">Discount.</param>
        /// <param name="PercentageSavings">PercentageSavings.</param>
        /// <param name="PromoCode">PromoCode.</param>
        /// <param name="PromoDescription">PromoDescription.</param>
        /// <param name="Savings">Savings.</param>
        public PriceAdjustmentDto(double? Discount = default(double?), double? PercentageSavings = default(double?), string PromoCode = default(string), string PromoDescription = default(string), double? Savings = default(double?))
        {
            this.Discount = Discount;
            this.PercentageSavings = PercentageSavings;
            this.PromoCode = PromoCode;
            this.PromoDescription = PromoDescription;
            this.Savings = Savings;
        }
        
        /// <summary>
        /// Gets or Sets Discount
        /// </summary>
        [DataMember(Name="discount", EmitDefaultValue=false)]
        public double? Discount { get; set; }

        /// <summary>
        /// Gets or Sets PercentageSavings
        /// </summary>
        [DataMember(Name="percentageSavings", EmitDefaultValue=false)]
        public double? PercentageSavings { get; set; }

        /// <summary>
        /// Gets or Sets PromoCode
        /// </summary>
        [DataMember(Name="promoCode", EmitDefaultValue=false)]
        public string PromoCode { get; set; }

        /// <summary>
        /// Gets or Sets PromoDescription
        /// </summary>
        [DataMember(Name="promoDescription", EmitDefaultValue=false)]
        public string PromoDescription { get; set; }

        /// <summary>
        /// Gets or Sets Savings
        /// </summary>
        [DataMember(Name="savings", EmitDefaultValue=false)]
        public double? Savings { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PriceAdjustmentDto {\n");
            sb.Append("  Discount: ").Append(Discount).Append("\n");
            sb.Append("  PercentageSavings: ").Append(PercentageSavings).Append("\n");
            sb.Append("  PromoCode: ").Append(PromoCode).Append("\n");
            sb.Append("  PromoDescription: ").Append(PromoDescription).Append("\n");
            sb.Append("  Savings: ").Append(Savings).Append("\n");
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
            return this.Equals(input as PriceAdjustmentDto);
        }

        /// <summary>
        /// Returns true if PriceAdjustmentDto instances are equal
        /// </summary>
        /// <param name="input">Instance of PriceAdjustmentDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PriceAdjustmentDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Discount == input.Discount ||
                    (this.Discount != null &&
                    this.Discount.Equals(input.Discount))
                ) && 
                (
                    this.PercentageSavings == input.PercentageSavings ||
                    (this.PercentageSavings != null &&
                    this.PercentageSavings.Equals(input.PercentageSavings))
                ) && 
                (
                    this.PromoCode == input.PromoCode ||
                    (this.PromoCode != null &&
                    this.PromoCode.Equals(input.PromoCode))
                ) && 
                (
                    this.PromoDescription == input.PromoDescription ||
                    (this.PromoDescription != null &&
                    this.PromoDescription.Equals(input.PromoDescription))
                ) && 
                (
                    this.Savings == input.Savings ||
                    (this.Savings != null &&
                    this.Savings.Equals(input.Savings))
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
                if (this.Discount != null)
                    hashCode = hashCode * 59 + this.Discount.GetHashCode();
                if (this.PercentageSavings != null)
                    hashCode = hashCode * 59 + this.PercentageSavings.GetHashCode();
                if (this.PromoCode != null)
                    hashCode = hashCode * 59 + this.PromoCode.GetHashCode();
                if (this.PromoDescription != null)
                    hashCode = hashCode * 59 + this.PromoDescription.GetHashCode();
                if (this.Savings != null)
                    hashCode = hashCode * 59 + this.Savings.GetHashCode();
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