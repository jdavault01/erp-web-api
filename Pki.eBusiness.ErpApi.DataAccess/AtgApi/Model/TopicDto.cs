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
    /// TopicDto
    /// </summary>
    [DataContract]
    public partial class TopicDto :  IEquatable<TopicDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopicDto" /> class.
        /// </summary>
        /// <param name="Category">Category.</param>
        /// <param name="PdfDetails">PdfDetails.</param>
        public TopicDto(CategoryDto Category = default(CategoryDto), PDFDetailDto PdfDetails = default(PDFDetailDto))
        {
            this.Category = Category;
            this.PdfDetails = PdfDetails;
        }
        
        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name="category", EmitDefaultValue=false)]
        public CategoryDto Category { get; set; }

        /// <summary>
        /// Gets or Sets PdfDetails
        /// </summary>
        [DataMember(Name="pdfDetails", EmitDefaultValue=false)]
        public PDFDetailDto PdfDetails { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TopicDto {\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  PdfDetails: ").Append(PdfDetails).Append("\n");
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
            return this.Equals(input as TopicDto);
        }

        /// <summary>
        /// Returns true if TopicDto instances are equal
        /// </summary>
        /// <param name="input">Instance of TopicDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TopicDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Category == input.Category ||
                    (this.Category != null &&
                    this.Category.Equals(input.Category))
                ) && 
                (
                    this.PdfDetails == input.PdfDetails ||
                    (this.PdfDetails != null &&
                    this.PdfDetails.Equals(input.PdfDetails))
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
                if (this.Category != null)
                    hashCode = hashCode * 59 + this.Category.GetHashCode();
                if (this.PdfDetails != null)
                    hashCode = hashCode * 59 + this.PdfDetails.GetHashCode();
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
