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
    /// TypeAheadResponseDto
    /// </summary>
    [DataContract]
    public partial class TypeAheadResponseDto :  IEquatable<TypeAheadResponseDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TypeAheadResponseDto" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        public TypeAheadResponseDto()
        {
        }
        
        /// <summary>
        /// Gets or Sets ProductNumber
        /// </summary>
        [DataMember(Name="productNumber", EmitDefaultValue=false)]
        public string ProductNumber { get; private set; }

        /// <summary>
        /// Gets or Sets ProductName
        /// </summary>
        [DataMember(Name="productName", EmitDefaultValue=false)]
        public string ProductName { get; private set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TypeAheadResponseDto {\n");
            sb.Append("  ProductNumber: ").Append(ProductNumber).Append("\n");
            sb.Append("  ProductName: ").Append(ProductName).Append("\n");
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
            return this.Equals(input as TypeAheadResponseDto);
        }

        /// <summary>
        /// Returns true if TypeAheadResponseDto instances are equal
        /// </summary>
        /// <param name="input">Instance of TypeAheadResponseDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TypeAheadResponseDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ProductNumber == input.ProductNumber ||
                    (this.ProductNumber != null &&
                    this.ProductNumber.Equals(input.ProductNumber))
                ) && 
                (
                    this.ProductName == input.ProductName ||
                    (this.ProductName != null &&
                    this.ProductName.Equals(input.ProductName))
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
                if (this.ProductNumber != null)
                    hashCode = hashCode * 59 + this.ProductNumber.GetHashCode();
                if (this.ProductName != null)
                    hashCode = hashCode * 59 + this.ProductName.GetHashCode();
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