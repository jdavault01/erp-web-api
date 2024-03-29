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
    /// ImageDto
    /// </summary>
    [DataContract]
    public partial class ImageDto :  IEquatable<ImageDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageDto" /> class.
        /// </summary>
        /// <param name="URL">URL.</param>
        /// <param name="AltText">AltText.</param>
        /// <param name="Caption">Caption.</param>
        /// <param name="Description">Description.</param>
        /// <param name="Id">Id.</param>
        /// <param name="ImageName">ImageName.</param>
        /// <param name="Name">Name.</param>
        /// <param name="TargetLink">TargetLink.</param>
        public ImageDto(string URL = default(string), string AltText = default(string), string Caption = default(string), string Description = default(string), string Id = default(string), string ImageName = default(string), string Name = default(string), string TargetLink = default(string))
        {
            this.URL = URL;
            this.AltText = AltText;
            this.Caption = Caption;
            this.Description = Description;
            this.Id = Id;
            this.ImageName = ImageName;
            this.Name = Name;
            this.TargetLink = TargetLink;
        }
        
        /// <summary>
        /// Gets or Sets URL
        /// </summary>
        [DataMember(Name="URL", EmitDefaultValue=false)]
        public string URL { get; set; }

        /// <summary>
        /// Gets or Sets AltText
        /// </summary>
        [DataMember(Name="altText", EmitDefaultValue=false)]
        public string AltText { get; set; }

        /// <summary>
        /// Gets or Sets Caption
        /// </summary>
        [DataMember(Name="caption", EmitDefaultValue=false)]
        public string Caption { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets ImageName
        /// </summary>
        [DataMember(Name="imageName", EmitDefaultValue=false)]
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets TargetLink
        /// </summary>
        [DataMember(Name="targetLink", EmitDefaultValue=false)]
        public string TargetLink { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ImageDto {\n");
            sb.Append("  URL: ").Append(URL).Append("\n");
            sb.Append("  AltText: ").Append(AltText).Append("\n");
            sb.Append("  Caption: ").Append(Caption).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ImageName: ").Append(ImageName).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  TargetLink: ").Append(TargetLink).Append("\n");
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
            return this.Equals(input as ImageDto);
        }

        /// <summary>
        /// Returns true if ImageDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ImageDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ImageDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.URL == input.URL ||
                    (this.URL != null &&
                    this.URL.Equals(input.URL))
                ) && 
                (
                    this.AltText == input.AltText ||
                    (this.AltText != null &&
                    this.AltText.Equals(input.AltText))
                ) && 
                (
                    this.Caption == input.Caption ||
                    (this.Caption != null &&
                    this.Caption.Equals(input.Caption))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.ImageName == input.ImageName ||
                    (this.ImageName != null &&
                    this.ImageName.Equals(input.ImageName))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.TargetLink == input.TargetLink ||
                    (this.TargetLink != null &&
                    this.TargetLink.Equals(input.TargetLink))
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
                if (this.URL != null)
                    hashCode = hashCode * 59 + this.URL.GetHashCode();
                if (this.AltText != null)
                    hashCode = hashCode * 59 + this.AltText.GetHashCode();
                if (this.Caption != null)
                    hashCode = hashCode * 59 + this.Caption.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.ImageName != null)
                    hashCode = hashCode * 59 + this.ImageName.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.TargetLink != null)
                    hashCode = hashCode * 59 + this.TargetLink.GetHashCode();
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
