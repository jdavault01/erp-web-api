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
    /// DiscontinuedPartNumbDto
    /// </summary>
    [DataContract]
    public partial class DiscontinuedPartNumbDto :  IEquatable<DiscontinuedPartNumbDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiscontinuedPartNumbDto" /> class.
        /// </summary>
        /// <param name="PartNumber">PartNumber.</param>
        /// <param name="PartNumberTitle">PartNumberTitle.</param>
        public DiscontinuedPartNumbDto(string PartNumber = default(string), string PartNumberTitle = default(string))
        {
            this.PartNumber = PartNumber;
            this.PartNumberTitle = PartNumberTitle;
        }
        
        /// <summary>
        /// Gets or Sets PartNumber
        /// </summary>
        [DataMember(Name="partNumber", EmitDefaultValue=false)]
        public string PartNumber { get; set; }

        /// <summary>
        /// Gets or Sets PartNumberTitle
        /// </summary>
        [DataMember(Name="partNumberTitle", EmitDefaultValue=false)]
        public string PartNumberTitle { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class DiscontinuedPartNumbDto {\n");
            sb.Append("  PartNumber: ").Append(PartNumber).Append("\n");
            sb.Append("  PartNumberTitle: ").Append(PartNumberTitle).Append("\n");
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
            return this.Equals(input as DiscontinuedPartNumbDto);
        }

        /// <summary>
        /// Returns true if DiscontinuedPartNumbDto instances are equal
        /// </summary>
        /// <param name="input">Instance of DiscontinuedPartNumbDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(DiscontinuedPartNumbDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PartNumber == input.PartNumber ||
                    (this.PartNumber != null &&
                    this.PartNumber.Equals(input.PartNumber))
                ) && 
                (
                    this.PartNumberTitle == input.PartNumberTitle ||
                    (this.PartNumberTitle != null &&
                    this.PartNumberTitle.Equals(input.PartNumberTitle))
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
                if (this.PartNumber != null)
                    hashCode = hashCode * 59 + this.PartNumber.GetHashCode();
                if (this.PartNumberTitle != null)
                    hashCode = hashCode * 59 + this.PartNumberTitle.GetHashCode();
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
