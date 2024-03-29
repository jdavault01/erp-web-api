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
    /// RefinementItemDto
    /// </summary>
    [DataContract]
    public partial class RefinementItemDto :  IEquatable<RefinementItemDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefinementItemDto" /> class.
        /// </summary>
        /// <param name="RefinementGroupName">RefinementGroupName.</param>
        /// <param name="RefinementValues">RefinementValues.</param>
        public RefinementItemDto(string RefinementGroupName = default(string), List<RefinementDto> RefinementValues = default(List<RefinementDto>))
        {
            this.RefinementGroupName = RefinementGroupName;
            this.RefinementValues = RefinementValues;
        }
        
        /// <summary>
        /// Gets or Sets RefinementGroupName
        /// </summary>
        [DataMember(Name="refinementGroupName", EmitDefaultValue=false)]
        public string RefinementGroupName { get; set; }

        /// <summary>
        /// Gets or Sets RefinementValues
        /// </summary>
        [DataMember(Name="refinementValues", EmitDefaultValue=false)]
        public List<RefinementDto> RefinementValues { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RefinementItemDto {\n");
            sb.Append("  RefinementGroupName: ").Append(RefinementGroupName).Append("\n");
            sb.Append("  RefinementValues: ").Append(RefinementValues).Append("\n");
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
            return this.Equals(input as RefinementItemDto);
        }

        /// <summary>
        /// Returns true if RefinementItemDto instances are equal
        /// </summary>
        /// <param name="input">Instance of RefinementItemDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RefinementItemDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.RefinementGroupName == input.RefinementGroupName ||
                    (this.RefinementGroupName != null &&
                    this.RefinementGroupName.Equals(input.RefinementGroupName))
                ) && 
                (
                    this.RefinementValues == input.RefinementValues ||
                    this.RefinementValues != null &&
                    this.RefinementValues.SequenceEqual(input.RefinementValues)
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
                if (this.RefinementGroupName != null)
                    hashCode = hashCode * 59 + this.RefinementGroupName.GetHashCode();
                if (this.RefinementValues != null)
                    hashCode = hashCode * 59 + this.RefinementValues.GetHashCode();
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
