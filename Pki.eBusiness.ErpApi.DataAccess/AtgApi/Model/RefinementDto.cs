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
    /// RefinementDto
    /// </summary>
    [DataContract]
    public partial class RefinementDto :  IEquatable<RefinementDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RefinementDto" /> class.
        /// </summary>
        /// <param name="NValue">NValue.</param>
        /// <param name="URL">URL.</param>
        /// <param name="Count">Count.</param>
        /// <param name="Name">Name.</param>
        public RefinementDto(string NValue = default(string), string URL = default(string), int? Count = default(int?), string Name = default(string))
        {
            this.NValue = NValue;
            this.URL = URL;
            this.Count = Count;
            this.Name = Name;
        }
        
        /// <summary>
        /// Gets or Sets NValue
        /// </summary>
        [DataMember(Name="NValue", EmitDefaultValue=false)]
        public string NValue { get; set; }

        /// <summary>
        /// Gets or Sets URL
        /// </summary>
        [DataMember(Name="URL", EmitDefaultValue=false)]
        public string URL { get; set; }

        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [DataMember(Name="count", EmitDefaultValue=false)]
        public int? Count { get; set; }

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
            sb.Append("class RefinementDto {\n");
            sb.Append("  NValue: ").Append(NValue).Append("\n");
            sb.Append("  URL: ").Append(URL).Append("\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
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
            return this.Equals(input as RefinementDto);
        }

        /// <summary>
        /// Returns true if RefinementDto instances are equal
        /// </summary>
        /// <param name="input">Instance of RefinementDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RefinementDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.NValue == input.NValue ||
                    (this.NValue != null &&
                    this.NValue.Equals(input.NValue))
                ) && 
                (
                    this.URL == input.URL ||
                    (this.URL != null &&
                    this.URL.Equals(input.URL))
                ) && 
                (
                    this.Count == input.Count ||
                    (this.Count != null &&
                    this.Count.Equals(input.Count))
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
                if (this.NValue != null)
                    hashCode = hashCode * 59 + this.NValue.GetHashCode();
                if (this.URL != null)
                    hashCode = hashCode * 59 + this.URL.GetHashCode();
                if (this.Count != null)
                    hashCode = hashCode * 59 + this.Count.GetHashCode();
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
