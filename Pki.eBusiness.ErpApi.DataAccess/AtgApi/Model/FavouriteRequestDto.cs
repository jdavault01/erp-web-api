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
    /// FavouriteRequestDto
    /// </summary>
    [DataContract]
    public partial class FavouriteRequestDto :  IEquatable<FavouriteRequestDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FavouriteRequestDto" /> class.
        /// </summary>
        /// <param name="PartNumbers">PartNumbers.</param>
        public FavouriteRequestDto(List<Object> PartNumbers = default(List<Object>))
        {
            this.PartNumbers = PartNumbers;
        }
        
        /// <summary>
        /// Gets or Sets PartNumbers
        /// </summary>
        [DataMember(Name="partNumbers", EmitDefaultValue=false)]
        public List<Object> PartNumbers { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FavouriteRequestDto {\n");
            sb.Append("  PartNumbers: ").Append(PartNumbers).Append("\n");
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
            return this.Equals(input as FavouriteRequestDto);
        }

        /// <summary>
        /// Returns true if FavouriteRequestDto instances are equal
        /// </summary>
        /// <param name="input">Instance of FavouriteRequestDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FavouriteRequestDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PartNumbers == input.PartNumbers ||
                    this.PartNumbers != null &&
                    this.PartNumbers.SequenceEqual(input.PartNumbers)
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
                if (this.PartNumbers != null)
                    hashCode = hashCode * 59 + this.PartNumbers.GetHashCode();
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