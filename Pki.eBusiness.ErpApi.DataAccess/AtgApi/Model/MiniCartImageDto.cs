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
    /// MiniCartImageDto
    /// </summary>
    [DataContract]
    public partial class MiniCartImageDto :  IEquatable<MiniCartImageDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MiniCartImageDto" /> class.
        /// </summary>
        /// <param name="AltText">AltText.</param>
        /// <param name="Name">Name.</param>
        public MiniCartImageDto(string AltText = default(string), string Name = default(string))
        {
            this.AltText = AltText;
            this.Name = Name;
        }
        
        /// <summary>
        /// Gets or Sets AltText
        /// </summary>
        [DataMember(Name="altText", EmitDefaultValue=false)]
        public string AltText { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class MiniCartImageDto {\n");
            sb.Append("  AltText: ").Append(AltText).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
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
            return this.Equals(input as MiniCartImageDto);
        }

        /// <summary>
        /// Returns true if MiniCartImageDto instances are equal
        /// </summary>
        /// <param name="input">Instance of MiniCartImageDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(MiniCartImageDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.AltText == input.AltText ||
                    (this.AltText != null &&
                    this.AltText.Equals(input.AltText))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
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
                if (this.AltText != null)
                    hashCode = hashCode * 59 + this.AltText.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
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
