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
    /// SiteConfigDto
    /// </summary>
    [DataContract]
    public partial class SiteConfigDto :  IEquatable<SiteConfigDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteConfigDto" /> class.
        /// </summary>
        /// <param name="EcommerceEnabled">EcommerceEnabled.</param>
        /// <param name="Id">Id.</param>
        public SiteConfigDto(bool? EcommerceEnabled = default(bool?), string Id = default(string))
        {
            this.EcommerceEnabled = EcommerceEnabled;
            this.Id = Id;
        }
        
        /// <summary>
        /// Gets or Sets EcommerceEnabled
        /// </summary>
        [DataMember(Name="ecommerceEnabled", EmitDefaultValue=false)]
        public bool? EcommerceEnabled { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SiteConfigDto {\n");
            sb.Append("  EcommerceEnabled: ").Append(EcommerceEnabled).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
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
            return this.Equals(input as SiteConfigDto);
        }

        /// <summary>
        /// Returns true if SiteConfigDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SiteConfigDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SiteConfigDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EcommerceEnabled == input.EcommerceEnabled ||
                    (this.EcommerceEnabled != null &&
                    this.EcommerceEnabled.Equals(input.EcommerceEnabled))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
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
                if (this.EcommerceEnabled != null)
                    hashCode = hashCode * 59 + this.EcommerceEnabled.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
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
