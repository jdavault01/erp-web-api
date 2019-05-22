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
    /// SortOptionDto
    /// </summary>
    [DataContract]
    public partial class SortOptionDto :  IEquatable<SortOptionDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SortOptionDto" /> class.
        /// </summary>
        /// <param name="URL">URL.</param>
        /// <param name="ContentPath">ContentPath.</param>
        /// <param name="Label">Label.</param>
        /// <param name="NavigationState">NavigationState.</param>
        /// <param name="Selected">Selected.</param>
        public SortOptionDto(string URL = default(string), string ContentPath = default(string), string Label = default(string), string NavigationState = default(string), bool? Selected = default(bool?))
        {
            this.URL = URL;
            this.ContentPath = ContentPath;
            this.Label = Label;
            this.NavigationState = NavigationState;
            this.Selected = Selected;
        }
        
        /// <summary>
        /// Gets or Sets URL
        /// </summary>
        [DataMember(Name="URL", EmitDefaultValue=false)]
        public string URL { get; set; }

        /// <summary>
        /// Gets or Sets ContentPath
        /// </summary>
        [DataMember(Name="contentPath", EmitDefaultValue=false)]
        public string ContentPath { get; set; }

        /// <summary>
        /// Gets or Sets Label
        /// </summary>
        [DataMember(Name="label", EmitDefaultValue=false)]
        public string Label { get; set; }

        /// <summary>
        /// Gets or Sets NavigationState
        /// </summary>
        [DataMember(Name="navigationState", EmitDefaultValue=false)]
        public string NavigationState { get; set; }

        /// <summary>
        /// Gets or Sets Selected
        /// </summary>
        [DataMember(Name="selected", EmitDefaultValue=false)]
        public bool? Selected { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SortOptionDto {\n");
            sb.Append("  URL: ").Append(URL).Append("\n");
            sb.Append("  ContentPath: ").Append(ContentPath).Append("\n");
            sb.Append("  Label: ").Append(Label).Append("\n");
            sb.Append("  NavigationState: ").Append(NavigationState).Append("\n");
            sb.Append("  Selected: ").Append(Selected).Append("\n");
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
            return this.Equals(input as SortOptionDto);
        }

        /// <summary>
        /// Returns true if SortOptionDto instances are equal
        /// </summary>
        /// <param name="input">Instance of SortOptionDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SortOptionDto input)
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
                    this.ContentPath == input.ContentPath ||
                    (this.ContentPath != null &&
                    this.ContentPath.Equals(input.ContentPath))
                ) && 
                (
                    this.Label == input.Label ||
                    (this.Label != null &&
                    this.Label.Equals(input.Label))
                ) && 
                (
                    this.NavigationState == input.NavigationState ||
                    (this.NavigationState != null &&
                    this.NavigationState.Equals(input.NavigationState))
                ) && 
                (
                    this.Selected == input.Selected ||
                    (this.Selected != null &&
                    this.Selected.Equals(input.Selected))
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
                if (this.ContentPath != null)
                    hashCode = hashCode * 59 + this.ContentPath.GetHashCode();
                if (this.Label != null)
                    hashCode = hashCode * 59 + this.Label.GetHashCode();
                if (this.NavigationState != null)
                    hashCode = hashCode * 59 + this.NavigationState.GetHashCode();
                if (this.Selected != null)
                    hashCode = hashCode * 59 + this.Selected.GetHashCode();
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
