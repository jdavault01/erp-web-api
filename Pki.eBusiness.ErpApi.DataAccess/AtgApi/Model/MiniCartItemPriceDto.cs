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
    /// MiniCartItemPriceDto
    /// </summary>
    [DataContract]
    public partial class MiniCartItemPriceDto :  IEquatable<MiniCartItemPriceDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiniCartItemPriceDto" /> class.
        /// </summary>
        /// <param name="AdjustedPrice">AdjustedPrice.</param>
        /// <param name="Currency">Currency.</param>
        /// <param name="UnitPrice">UnitPrice.</param>
        public MiniCartItemPriceDto(double? AdjustedPrice = default(double?), string Currency = default(string), double? UnitPrice = default(double?))
        {
            this.AdjustedPrice = AdjustedPrice;
            this.Currency = Currency;
            this.UnitPrice = UnitPrice;
        }
        
        /// <summary>
        /// Gets or Sets AdjustedPrice
        /// </summary>
        [DataMember(Name="adjustedPrice", EmitDefaultValue=false)]
        public double? AdjustedPrice { get; set; }

        /// <summary>
        /// Gets or Sets Currency
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue=false)]
        public string Currency { get; set; }

        /// <summary>
        /// Gets or Sets UnitPrice
        /// </summary>
        [DataMember(Name="unitPrice", EmitDefaultValue=false)]
        public double? UnitPrice { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MiniCartItemPriceDto {\n");
            sb.Append("  AdjustedPrice: ").Append(AdjustedPrice).Append("\n");
            sb.Append("  Currency: ").Append(Currency).Append("\n");
            sb.Append("  UnitPrice: ").Append(UnitPrice).Append("\n");
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
            return this.Equals(input as MiniCartItemPriceDto);
        }

        /// <summary>
        /// Returns true if MiniCartItemPriceDto instances are equal
        /// </summary>
        /// <param name="input">Instance of MiniCartItemPriceDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MiniCartItemPriceDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AdjustedPrice == input.AdjustedPrice ||
                    (this.AdjustedPrice != null &&
                    this.AdjustedPrice.Equals(input.AdjustedPrice))
                ) && 
                (
                    this.Currency == input.Currency ||
                    (this.Currency != null &&
                    this.Currency.Equals(input.Currency))
                ) && 
                (
                    this.UnitPrice == input.UnitPrice ||
                    (this.UnitPrice != null &&
                    this.UnitPrice.Equals(input.UnitPrice))
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
                if (this.AdjustedPrice != null)
                    hashCode = hashCode * 59 + this.AdjustedPrice.GetHashCode();
                if (this.Currency != null)
                    hashCode = hashCode * 59 + this.Currency.GetHashCode();
                if (this.UnitPrice != null)
                    hashCode = hashCode * 59 + this.UnitPrice.GetHashCode();
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
