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
    /// SuggestedCategoryContentDto
    /// </summary>
    [DataContract]
    public partial class SuggestedCategoryContentDto :  IEquatable<SuggestedCategoryContentDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuggestedCategoryContentDto" /> class.
        /// </summary>
        /// <param name="Image">Image.</param>
        /// <param name="SuggestedCategories">SuggestedCategories.</param>
        public SuggestedCategoryContentDto(ImageDto Image = default(ImageDto), List<SuggestedCategoriesDto> SuggestedCategories = default(List<SuggestedCategoriesDto>))
        {
            this.Image = Image;
            this.SuggestedCategories = SuggestedCategories;
        }
        
        /// <summary>
        /// Gets or Sets Image
        /// </summary>
        [DataMember(Name="image", EmitDefaultValue=false)]
        public ImageDto Image { get; set; }

        /// <summary>
        /// Gets or Sets SuggestedCategories
        /// </summary>
        [DataMember(Name="suggestedCategories", EmitDefaultValue=false)]
        public List<SuggestedCategoriesDto> SuggestedCategories { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SuggestedCategoryContentDto {\n");
            sb.Append("  Image: ").Append(Image).Append("\n");
            sb.Append("  SuggestedCategories: ").Append(SuggestedCategories).Append("\n");
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
            return this.Equals(input as SuggestedCategoryContentDto);
        }

        /// <summary>
        /// Returns true if SuggestedCategoryContentDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SuggestedCategoryContentDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SuggestedCategoryContentDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Image == input.Image ||
                    (this.Image != null &&
                    this.Image.Equals(input.Image))
                ) && 
                (
                    this.SuggestedCategories == input.SuggestedCategories ||
                    this.SuggestedCategories != null &&
                    this.SuggestedCategories.SequenceEqual(input.SuggestedCategories)
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
                if (this.Image != null)
                    hashCode = hashCode * 59 + this.Image.GetHashCode();
                if (this.SuggestedCategories != null)
                    hashCode = hashCode * 59 + this.SuggestedCategories.GetHashCode();
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
