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
    /// ProductDetailsContentItemDto
    /// </summary>
    [DataContract]
    public partial class ProductDetailsContentItemDto :  IEquatable<ProductDetailsContentItemDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductDetailsContentItemDto" /> class.
        /// </summary>
        /// <param name="SocialShareEnabled">SocialShareEnabled.</param>
        /// <param name="PromoContent">PromoContent.</param>
        /// <param name="Product">Product.</param>
        /// <param name="BreadCrumb">BreadCrumb.</param>
        /// <param name="SocialShareAttributes">SocialShareAttributes.</param>
        /// <param name="SEOAttributes">SEOAttributes.</param>
        /// <param name="AnalyticsAttributes">AnalyticsAttributes.</param>
        public ProductDetailsContentItemDto(bool? SocialShareEnabled = default(bool?), PromoContentDto PromoContent = default(PromoContentDto), ProductDto Product = default(ProductDto), BreadCrumbDto BreadCrumb = default(BreadCrumbDto), List<AttributesDto> SocialShareAttributes = default(List<AttributesDto>), List<AttributesDto> SEOAttributes = default(List<AttributesDto>), List<AttributesDto> AnalyticsAttributes = default(List<AttributesDto>))
        {
            this.SocialShareEnabled = SocialShareEnabled;
            this.PromoContent = PromoContent;
            this.Product = Product;
            this.BreadCrumb = BreadCrumb;
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
        /// Gets or Sets PromoContent
        /// </summary>
        [DataMember(Name="promoContent", EmitDefaultValue=false)]
        public PromoContentDto PromoContent { get; set; }

        /// <summary>
        /// Gets or Sets Product
        /// </summary>
        [DataMember(Name="product", EmitDefaultValue=false)]
        public ProductDto Product { get; set; }

        /// <summary>
        /// Gets or Sets BreadCrumb
        /// </summary>
        [DataMember(Name="breadCrumb", EmitDefaultValue=false)]
        public BreadCrumbDto BreadCrumb { get; set; }

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
            sb.Append("class ProductDetailsContentItemDto {\n");
            sb.Append("  SocialShareEnabled: ").Append(SocialShareEnabled).Append("\n");
            sb.Append("  PromoContent: ").Append(PromoContent).Append("\n");
            sb.Append("  Product: ").Append(Product).Append("\n");
            sb.Append("  BreadCrumb: ").Append(BreadCrumb).Append("\n");
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
            return this.Equals(input as ProductDetailsContentItemDto);
        }

        /// <summary>
        /// Returns true if ProductDetailsContentItemDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ProductDetailsContentItemDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ProductDetailsContentItemDto input)
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
                    this.PromoContent == input.PromoContent ||
                    (this.PromoContent != null &&
                    this.PromoContent.Equals(input.PromoContent))
                ) && 
                (
                    this.Product == input.Product ||
                    (this.Product != null &&
                    this.Product.Equals(input.Product))
                ) && 
                (
                    this.BreadCrumb == input.BreadCrumb ||
                    (this.BreadCrumb != null &&
                    this.BreadCrumb.Equals(input.BreadCrumb))
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
                if (this.PromoContent != null)
                    hashCode = hashCode * 59 + this.PromoContent.GetHashCode();
                if (this.Product != null)
                    hashCode = hashCode * 59 + this.Product.GetHashCode();
                if (this.BreadCrumb != null)
                    hashCode = hashCode * 59 + this.BreadCrumb.GetHashCode();
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
