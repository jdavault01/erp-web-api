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
    /// ResourceLandingDto
    /// </summary>
    [DataContract]
    public partial class ResourceLandingDto :  IEquatable<ResourceLandingDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceLandingDto" /> class.
        /// </summary>
        /// <param name="SocialShareEnabled">SocialShareEnabled.</param>
        /// <param name="PopularTopic">PopularTopic.</param>
        /// <param name="BrowseTopicContents">BrowseTopicContents.</param>
        /// <param name="SocialShareAttributes">SocialShareAttributes.</param>
        /// <param name="SEOAttributes">SEOAttributes.</param>
        /// <param name="AnalyticsAttributes">AnalyticsAttributes.</param>
        public ResourceLandingDto(bool? SocialShareEnabled = default(bool?), PopularTopicsDto PopularTopic = default(PopularTopicsDto), List<BrowseTopicContentDto> BrowseTopicContents = default(List<BrowseTopicContentDto>), List<AttributesDto> SocialShareAttributes = default(List<AttributesDto>), List<AttributesDto> SEOAttributes = default(List<AttributesDto>), List<AttributesDto> AnalyticsAttributes = default(List<AttributesDto>))
        {
            this.SocialShareEnabled = SocialShareEnabled;
            this.PopularTopic = PopularTopic;
            this.BrowseTopicContents = BrowseTopicContents;
            this.SocialShareAttributes = SocialShareAttributes;
            this.SEOAttributes = SEOAttributes;
            this.AnalyticsAttributes = AnalyticsAttributes;
        }
        
        /// <summary>
        /// Gets or Sets SocialShareEnabled
        /// </summary>
        [DataMember(Name="socialShareEnabled", EmitDefaultValue=false)]
        public bool? SocialShareEnabled { get; set; }

        /// <summary>
        /// Gets or Sets PopularTopic
        /// </summary>
        [DataMember(Name="popularTopic", EmitDefaultValue=false)]
        public PopularTopicsDto PopularTopic { get; set; }

        /// <summary>
        /// Gets or Sets BrowseTopicContents
        /// </summary>
        [DataMember(Name="browseTopicContents", EmitDefaultValue=false)]
        public List<BrowseTopicContentDto> BrowseTopicContents { get; set; }

        /// <summary>
        /// Gets or Sets SocialShareAttributes
        /// </summary>
        [DataMember(Name="socialShareAttributes", EmitDefaultValue=false)]
        public List<AttributesDto> SocialShareAttributes { get; set; }

        /// <summary>
        /// Gets or Sets SEOAttributes
        /// </summary>
        [DataMember(Name="SEOAttributes", EmitDefaultValue=false)]
        public List<AttributesDto> SEOAttributes { get; set; }

        /// <summary>
        /// Gets or Sets AnalyticsAttributes
        /// </summary>
        [DataMember(Name="analyticsAttributes", EmitDefaultValue=false)]
        public List<AttributesDto> AnalyticsAttributes { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ResourceLandingDto {\n");
            sb.Append("  SocialShareEnabled: ").Append(SocialShareEnabled).Append("\n");
            sb.Append("  PopularTopic: ").Append(PopularTopic).Append("\n");
            sb.Append("  BrowseTopicContents: ").Append(BrowseTopicContents).Append("\n");
            sb.Append("  SocialShareAttributes: ").Append(SocialShareAttributes).Append("\n");
            sb.Append("  SEOAttributes: ").Append(SEOAttributes).Append("\n");
            sb.Append("  AnalyticsAttributes: ").Append(AnalyticsAttributes).Append("\n");
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
            return this.Equals(input as ResourceLandingDto);
        }

        /// <summary>
        /// Returns true if ResourceLandingDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ResourceLandingDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ResourceLandingDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.SocialShareEnabled == input.SocialShareEnabled ||
                    (this.SocialShareEnabled != null &&
                    this.SocialShareEnabled.Equals(input.SocialShareEnabled))
                ) && 
                (
                    this.PopularTopic == input.PopularTopic ||
                    (this.PopularTopic != null &&
                    this.PopularTopic.Equals(input.PopularTopic))
                ) && 
                (
                    this.BrowseTopicContents == input.BrowseTopicContents ||
                    this.BrowseTopicContents != null &&
                    this.BrowseTopicContents.SequenceEqual(input.BrowseTopicContents)
                ) && 
                (
                    this.SocialShareAttributes == input.SocialShareAttributes ||
                    this.SocialShareAttributes != null &&
                    this.SocialShareAttributes.SequenceEqual(input.SocialShareAttributes)
                ) && 
                (
                    this.SEOAttributes == input.SEOAttributes ||
                    this.SEOAttributes != null &&
                    this.SEOAttributes.SequenceEqual(input.SEOAttributes)
                ) && 
                (
                    this.AnalyticsAttributes == input.AnalyticsAttributes ||
                    this.AnalyticsAttributes != null &&
                    this.AnalyticsAttributes.SequenceEqual(input.AnalyticsAttributes)
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
                if (this.SocialShareEnabled != null)
                    hashCode = hashCode * 59 + this.SocialShareEnabled.GetHashCode();
                if (this.PopularTopic != null)
                    hashCode = hashCode * 59 + this.PopularTopic.GetHashCode();
                if (this.BrowseTopicContents != null)
                    hashCode = hashCode * 59 + this.BrowseTopicContents.GetHashCode();
                if (this.SocialShareAttributes != null)
                    hashCode = hashCode * 59 + this.SocialShareAttributes.GetHashCode();
                if (this.SEOAttributes != null)
                    hashCode = hashCode * 59 + this.SEOAttributes.GetHashCode();
                if (this.AnalyticsAttributes != null)
                    hashCode = hashCode * 59 + this.AnalyticsAttributes.GetHashCode();
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
