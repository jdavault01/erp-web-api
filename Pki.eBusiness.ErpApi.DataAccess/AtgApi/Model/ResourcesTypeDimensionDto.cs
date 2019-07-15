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
    /// ResourcesTypeDimensionDto
    /// </summary>
    [DataContract]
    public partial class ResourcesTypeDimensionDto :  IEquatable<ResourcesTypeDimensionDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourcesTypeDimensionDto" /> class.
        /// </summary>
        /// <param name="DimensionNValue">DimensionNValue.</param>
        /// <param name="DimensionName">DimensionName.</param>
        public ResourcesTypeDimensionDto(string DimensionNValue = default(string), string DimensionName = default(string))
        {
            this.DimensionNValue = DimensionNValue;
            this.DimensionName = DimensionName;
        }
        
        /// <summary>
        /// Gets or Sets DimensionNValue
        /// </summary>
        [DataMember(Name="dimensionNValue", EmitDefaultValue=false)]
        public string DimensionNValue { get; set; }

        /// <summary>
        /// Gets or Sets DimensionName
        /// </summary>
        [DataMember(Name="dimensionName", EmitDefaultValue=false)]
        public string DimensionName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResourcesTypeDimensionDto {\n");
            sb.Append("  DimensionNValue: ").Append(DimensionNValue).Append("\n");
            sb.Append("  DimensionName: ").Append(DimensionName).Append("\n");
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
            return this.Equals(input as ResourcesTypeDimensionDto);
        }

        /// <summary>
        /// Returns true if ResourcesTypeDimensionDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ResourcesTypeDimensionDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourcesTypeDimensionDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.DimensionNValue == input.DimensionNValue ||
                    (this.DimensionNValue != null &&
                    this.DimensionNValue.Equals(input.DimensionNValue))
                ) && 
                (
                    this.DimensionName == input.DimensionName ||
                    (this.DimensionName != null &&
                    this.DimensionName.Equals(input.DimensionName))
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
                if (this.DimensionNValue != null)
                    hashCode = hashCode * 59 + this.DimensionNValue.GetHashCode();
                if (this.DimensionName != null)
                    hashCode = hashCode * 59 + this.DimensionName.GetHashCode();
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