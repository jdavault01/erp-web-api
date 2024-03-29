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
    /// NotificationRequestDto
    /// </summary>
    [DataContract]
    public partial class NotificationRequestDto :  IEquatable<NotificationRequestDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRequestDto" /> class.
        /// </summary>
        /// <param name="Country">Country.</param>
        /// <param name="LocaleId">LocaleId.</param>
        /// <param name="SubjectSubstitutionParameters">SubjectSubstitutionParameters.</param>
        /// <param name="TemplateType">TemplateType.</param>
        /// <param name="To">To.</param>
        public NotificationRequestDto(string Country = default(string), string LocaleId = default(string), List<string> SubjectSubstitutionParameters = default(List<string>), string TemplateType = default(string), string To = default(string))
        {
            this.Country = Country;
            this.LocaleId = LocaleId;
            this.SubjectSubstitutionParameters = SubjectSubstitutionParameters;
            this.TemplateType = TemplateType;
            this.To = To;
        }
        
        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        /// Gets or Sets LocaleId
        /// </summary>
        [DataMember(Name="localeId", EmitDefaultValue=false)]
        public string LocaleId { get; set; }

        /// <summary>
        /// Gets or Sets SubjectSubstitutionParameters
        /// </summary>
        [DataMember(Name="subjectSubstitutionParameters", EmitDefaultValue=false)]
        public List<string> SubjectSubstitutionParameters { get; set; }

        /// <summary>
        /// Gets or Sets TemplateType
        /// </summary>
        [DataMember(Name="templateType", EmitDefaultValue=false)]
        public string TemplateType { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name="to", EmitDefaultValue=false)]
        public string To { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NotificationRequestDto {\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
            sb.Append("  LocaleId: ").Append(LocaleId).Append("\n");
            sb.Append("  SubjectSubstitutionParameters: ").Append(SubjectSubstitutionParameters).Append("\n");
            sb.Append("  TemplateType: ").Append(TemplateType).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
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
            return this.Equals(input as NotificationRequestDto);
        }

        /// <summary>
        /// Returns true if NotificationRequestDto instances are equal
        /// </summary>
        /// <param name="input">Instance of NotificationRequestDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NotificationRequestDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
                ) && 
                (
                    this.LocaleId == input.LocaleId ||
                    (this.LocaleId != null &&
                    this.LocaleId.Equals(input.LocaleId))
                ) && 
                (
                    this.SubjectSubstitutionParameters == input.SubjectSubstitutionParameters ||
                    this.SubjectSubstitutionParameters != null &&
                    this.SubjectSubstitutionParameters.SequenceEqual(input.SubjectSubstitutionParameters)
                ) && 
                (
                    this.TemplateType == input.TemplateType ||
                    (this.TemplateType != null &&
                    this.TemplateType.Equals(input.TemplateType))
                ) && 
                (
                    this.To == input.To ||
                    (this.To != null &&
                    this.To.Equals(input.To))
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
                if (this.Country != null)
                    hashCode = hashCode * 59 + this.Country.GetHashCode();
                if (this.LocaleId != null)
                    hashCode = hashCode * 59 + this.LocaleId.GetHashCode();
                if (this.SubjectSubstitutionParameters != null)
                    hashCode = hashCode * 59 + this.SubjectSubstitutionParameters.GetHashCode();
                if (this.TemplateType != null)
                    hashCode = hashCode * 59 + this.TemplateType.GetHashCode();
                if (this.To != null)
                    hashCode = hashCode * 59 + this.To.GetHashCode();
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
