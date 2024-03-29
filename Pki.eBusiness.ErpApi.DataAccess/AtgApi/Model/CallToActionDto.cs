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
    /// CallToActionDto
    /// </summary>
    [DataContract]
    public partial class CallToActionDto :  IEquatable<CallToActionDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CallToActionDto" /> class.
        /// </summary>
        /// <param name="ButonText">ButonText.</param>
        /// <param name="Description">Description.</param>
        /// <param name="Heading">Heading.</param>
        /// <param name="Id">Id.</param>
        /// <param name="Link">Link.</param>
        public CallToActionDto(string ButonText = default(string), string Description = default(string), string Heading = default(string), string Id = default(string), string Link = default(string))
        {
            this.ButonText = ButonText;
            this.Description = Description;
            this.Heading = Heading;
            this.Id = Id;
            this.Link = Link;
        }
        
        /// <summary>
        /// Gets or Sets ButonText
        /// </summary>
        [DataMember(Name="butonText", EmitDefaultValue=false)]
        public string ButonText { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Heading
        /// </summary>
        [DataMember(Name="heading", EmitDefaultValue=false)]
        public string Heading { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Link
        /// </summary>
        [DataMember(Name="link", EmitDefaultValue=false)]
        public string Link { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CallToActionDto {\n");
            sb.Append("  ButonText: ").Append(ButonText).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Heading: ").Append(Heading).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Link: ").Append(Link).Append("\n");
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
            return this.Equals(input as CallToActionDto);
        }

        /// <summary>
        /// Returns true if CallToActionDto instances are equal
        /// </summary>
        /// <param name="input">Instance of CallToActionDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CallToActionDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ButonText == input.ButonText ||
                    (this.ButonText != null &&
                    this.ButonText.Equals(input.ButonText))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Heading == input.Heading ||
                    (this.Heading != null &&
                    this.Heading.Equals(input.Heading))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Link == input.Link ||
                    (this.Link != null &&
                    this.Link.Equals(input.Link))
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
                if (this.ButonText != null)
                    hashCode = hashCode * 59 + this.ButonText.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Heading != null)
                    hashCode = hashCode * 59 + this.Heading.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Link != null)
                    hashCode = hashCode * 59 + this.Link.GetHashCode();
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
