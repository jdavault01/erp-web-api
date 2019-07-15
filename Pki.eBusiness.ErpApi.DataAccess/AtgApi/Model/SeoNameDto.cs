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
    /// SeoNameDto
    /// </summary>
    [DataContract]
    public partial class SeoNameDto :  IEquatable<SeoNameDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SeoNameDto" /> class.
        /// </summary>
        /// <param name="SeoName">SeoName.</param>
        public SeoNameDto(string SeoName = default(string))
        {
            this.SeoName = SeoName;
        }
        
        /// <summary>
        /// Gets or Sets SeoName
        /// </summary>
        [DataMember(Name="seoName", EmitDefaultValue=false)]
        public string SeoName { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SeoNameDto {\n");
            sb.Append("  SeoName: ").Append(SeoName).Append("\n");
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
            return this.Equals(input as SeoNameDto);
        }

        /// <summary>
        /// Returns true if SeoNameDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SeoNameDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SeoNameDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SeoName == input.SeoName ||
                    (this.SeoName != null &&
                    this.SeoName.Equals(input.SeoName))
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
                if (this.SeoName != null)
                    hashCode = hashCode * 59 + this.SeoName.GetHashCode();
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