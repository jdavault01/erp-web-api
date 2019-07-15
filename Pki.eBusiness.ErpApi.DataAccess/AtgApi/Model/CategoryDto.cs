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
    /// CategoryDto
    /// </summary>
    [DataContract]
    public partial class CategoryDto :  IEquatable<CategoryDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryDto" /> class.
        /// </summary>
        /// <param name="URL">URL.</param>
        /// <param name="CategoryBanner">CategoryBanner.</param>
        /// <param name="CategoryName">CategoryName.</param>
        /// <param name="Description">Description.</param>
        /// <param name="ExternalURL">ExternalURL.</param>
        /// <param name="Gated">Gated.</param>
        /// <param name="LogoDescription">LogoDescription.</param>
        /// <param name="LongDescription">LongDescription.</param>
        /// <param name="M3DImagePath">M3DImagePath.</param>
        /// <param name="Name">Name.</param>
        /// <param name="Pdg">Pdg.</param>
        /// <param name="RequestMoreDescription">RequestMoreDescription.</param>
        /// <param name="RequestMoreUrl">RequestMoreUrl.</param>
        /// <param name="Section">Section.</param>
        /// <param name="SectionsDescriptionSolution">SectionsDescriptionSolution.</param>
        /// <param name="SectionsNameSolution">SectionsNameSolution.</param>
        /// <param name="SeoURL">SeoURL.</param>
        /// <param name="Slideshows">Slideshows.</param>
        /// <param name="Target">Target.</param>
        /// <param name="TemplateId">TemplateId.</param>
        /// <param name="TemplateType">TemplateType.</param>
        /// <param name="Title">Title.</param>
        /// <param name="WebDisplayName">WebDisplayName.</param>
        /// <param name="ChildCategory">ChildCategory.</param>
        /// <param name="ChildProducts">ChildProducts.</param>
        /// <param name="Sections">Sections.</param>
        /// <param name="TabSections">TabSections.</param>
        /// <param name="BlogSections">BlogSections.</param>
        /// <param name="FeaturedSections">FeaturedSections.</param>
        /// <param name="Images">Images.</param>
        /// <param name="Videos">Videos.</param>
        /// <param name="ImageDetails">ImageDetails.</param>
        /// <param name="InfographicImage">InfographicImage.</param>
        /// <param name="SeoAttributes">SeoAttributes.</param>
        /// <param name="SocialShareAttributes">SocialShareAttributes.</param>
        /// <param name="VideoList">VideoList.</param>
        /// <param name="ImageList">ImageList.</param>
        /// <param name="SectionList">SectionList.</param>
        /// <param name="CallToActionDetails">CallToActionDetails.</param>
        /// <param name="SecondaryBannerImageList">SecondaryBannerImageList.</param>
        /// <param name="TitleChildCategory">TitleChildCategory.</param>
        public CategoryDto(string URL = default(string), bool? CategoryBanner = default(bool?), string CategoryName = default(string), string Description = default(string), bool? ExternalURL = default(bool?), bool? Gated = default(bool?), string LogoDescription = default(string), string LongDescription = default(string), string M3DImagePath = default(string), string Name = default(string), bool? Pdg = default(bool?), string RequestMoreDescription = default(string), string RequestMoreUrl = default(string), bool? Section = default(bool?), string SectionsDescriptionSolution = default(string), string SectionsNameSolution = default(string), string SeoURL = default(string), string Slideshows = default(string), string Target = default(string), string TemplateId = default(string), string TemplateType = default(string), string Title = default(string), string WebDisplayName = default(string), List<CategoryDto> ChildCategory = default(List<CategoryDto>), List<ProductDto> ChildProducts = default(List<ProductDto>), List<SectionDto> Sections = default(List<SectionDto>), List<SectionDto> TabSections = default(List<SectionDto>), List<SectionDto> BlogSections = default(List<SectionDto>), List<SectionDto> FeaturedSections = default(List<SectionDto>), List<ImageDto> Images = default(List<ImageDto>), List<VideoDto> Videos = default(List<VideoDto>), ImageDto ImageDetails = default(ImageDto), ImageDto InfographicImage = default(ImageDto), SeoAttributesDto SeoAttributes = default(SeoAttributesDto), SocialShareAttributesDto SocialShareAttributes = default(SocialShareAttributesDto), List<VideoDto> VideoList = default(List<VideoDto>), List<ImageDto> ImageList = default(List<ImageDto>), List<SectionDto> SectionList = default(List<SectionDto>), List<CallToActionDto> CallToActionDetails = default(List<CallToActionDto>), List<ImageDto> SecondaryBannerImageList = default(List<ImageDto>), List<CategoryDto> TitleChildCategory = default(List<CategoryDto>))
        {
            this.URL = URL;
            this.CategoryBanner = CategoryBanner;
            this.CategoryName = CategoryName;
            this.Description = Description;
            this.ExternalURL = ExternalURL;
            this.Gated = Gated;
            this.LogoDescription = LogoDescription;
            this.LongDescription = LongDescription;
            this.M3DImagePath = M3DImagePath;
            this.Name = Name;
            this.Pdg = Pdg;
            this.RequestMoreDescription = RequestMoreDescription;
            this.RequestMoreUrl = RequestMoreUrl;
            this.Section = Section;
            this.SectionsDescriptionSolution = SectionsDescriptionSolution;
            this.SectionsNameSolution = SectionsNameSolution;
            this.SeoURL = SeoURL;
            this.Slideshows = Slideshows;
            this.Target = Target;
            this.TemplateId = TemplateId;
            this.TemplateType = TemplateType;
            this.Title = Title;
            this.WebDisplayName = WebDisplayName;
            this.ChildCategory = ChildCategory;
            this.ChildProducts = ChildProducts;
            this.Sections = Sections;
            this.TabSections = TabSections;
            this.BlogSections = BlogSections;
            this.FeaturedSections = FeaturedSections;
            this.Images = Images;
            this.Videos = Videos;
            this.ImageDetails = ImageDetails;
            this.InfographicImage = InfographicImage;
            this.SeoAttributes = SeoAttributes;
            this.SocialShareAttributes = SocialShareAttributes;
            this.VideoList = VideoList;
            this.ImageList = ImageList;
            this.SectionList = SectionList;
            this.CallToActionDetails = CallToActionDetails;
            this.SecondaryBannerImageList = SecondaryBannerImageList;
            this.TitleChildCategory = TitleChildCategory;
        }
        
        /// <summary>
        /// Gets or Sets URL
        /// </summary>
        [DataMember(Name="URL", EmitDefaultValue=false)]
        public string URL { get; set; }

        /// <summary>
        /// Gets or Sets CategoryBanner
        /// </summary>
        [DataMember(Name="categoryBanner", EmitDefaultValue=false)]
        public bool? CategoryBanner { get; set; }

        /// <summary>
        /// Gets or Sets CategoryName
        /// </summary>
        [DataMember(Name="categoryName", EmitDefaultValue=false)]
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets ExternalURL
        /// </summary>
        [DataMember(Name="externalURL", EmitDefaultValue=false)]
        public bool? ExternalURL { get; set; }

        /// <summary>
        /// Gets or Sets Gated
        /// </summary>
        [DataMember(Name="gated", EmitDefaultValue=false)]
        public bool? Gated { get; set; }

        /// <summary>
        /// Gets or Sets LogoDescription
        /// </summary>
        [DataMember(Name="logoDescription", EmitDefaultValue=false)]
        public string LogoDescription { get; set; }

        /// <summary>
        /// Gets or Sets LongDescription
        /// </summary>
        [DataMember(Name="longDescription", EmitDefaultValue=false)]
        public string LongDescription { get; set; }

        /// <summary>
        /// Gets or Sets M3DImagePath
        /// </summary>
        [DataMember(Name="m3DImagePath", EmitDefaultValue=false)]
        public string M3DImagePath { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Pdg
        /// </summary>
        [DataMember(Name="pdg", EmitDefaultValue=false)]
        public bool? Pdg { get; set; }

        /// <summary>
        /// Gets or Sets RequestMoreDescription
        /// </summary>
        [DataMember(Name="requestMoreDescription", EmitDefaultValue=false)]
        public string RequestMoreDescription { get; set; }

        /// <summary>
        /// Gets or Sets RequestMoreUrl
        /// </summary>
        [DataMember(Name="requestMoreUrl", EmitDefaultValue=false)]
        public string RequestMoreUrl { get; set; }

        /// <summary>
        /// Gets or Sets Section
        /// </summary>
        [DataMember(Name="section", EmitDefaultValue=false)]
        public bool? Section { get; set; }

        /// <summary>
        /// Gets or Sets SectionsDescriptionSolution
        /// </summary>
        [DataMember(Name="sectionsDescriptionSolution", EmitDefaultValue=false)]
        public string SectionsDescriptionSolution { get; set; }

        /// <summary>
        /// Gets or Sets SectionsNameSolution
        /// </summary>
        [DataMember(Name="sectionsNameSolution", EmitDefaultValue=false)]
        public string SectionsNameSolution { get; set; }

        /// <summary>
        /// Gets or Sets SeoURL
        /// </summary>
        [DataMember(Name="seoURL", EmitDefaultValue=false)]
        public string SeoURL { get; set; }

        /// <summary>
        /// Gets or Sets Slideshows
        /// </summary>
        [DataMember(Name="slideshows", EmitDefaultValue=false)]
        public string Slideshows { get; set; }

        /// <summary>
        /// Gets or Sets Target
        /// </summary>
        [DataMember(Name="target", EmitDefaultValue=false)]
        public string Target { get; set; }

        /// <summary>
        /// Gets or Sets TemplateId
        /// </summary>
        [DataMember(Name="templateId", EmitDefaultValue=false)]
        public string TemplateId { get; set; }

        /// <summary>
        /// Gets or Sets TemplateType
        /// </summary>
        [DataMember(Name="templateType", EmitDefaultValue=false)]
        public string TemplateType { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        [DataMember(Name="title", EmitDefaultValue=false)]
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets WebDisplayName
        /// </summary>
        [DataMember(Name="webDisplayName", EmitDefaultValue=false)]
        public string WebDisplayName { get; set; }

        /// <summary>
        /// Gets or Sets ChildCategory
        /// </summary>
        [DataMember(Name="childCategory", EmitDefaultValue=false)]
        public List<CategoryDto> ChildCategory { get; set; }

        /// <summary>
        /// Gets or Sets ChildProducts
        /// </summary>
        [DataMember(Name="childProducts", EmitDefaultValue=false)]
        public List<ProductDto> ChildProducts { get; set; }

        /// <summary>
        /// Gets or Sets Sections
        /// </summary>
        [DataMember(Name="sections", EmitDefaultValue=false)]
        public List<SectionDto> Sections { get; set; }

        /// <summary>
        /// Gets or Sets TabSections
        /// </summary>
        [DataMember(Name="tabSections", EmitDefaultValue=false)]
        public List<SectionDto> TabSections { get; set; }

        /// <summary>
        /// Gets or Sets BlogSections
        /// </summary>
        [DataMember(Name="blogSections", EmitDefaultValue=false)]
        public List<SectionDto> BlogSections { get; set; }

        /// <summary>
        /// Gets or Sets FeaturedSections
        /// </summary>
        [DataMember(Name="featuredSections", EmitDefaultValue=false)]
        public List<SectionDto> FeaturedSections { get; set; }

        /// <summary>
        /// Gets or Sets Images
        /// </summary>
        [DataMember(Name="images", EmitDefaultValue=false)]
        public List<ImageDto> Images { get; set; }

        /// <summary>
        /// Gets or Sets Videos
        /// </summary>
        [DataMember(Name="videos", EmitDefaultValue=false)]
        public List<VideoDto> Videos { get; set; }

        /// <summary>
        /// Gets or Sets ImageDetails
        /// </summary>
        [DataMember(Name="imageDetails", EmitDefaultValue=false)]
        public ImageDto ImageDetails { get; set; }

        /// <summary>
        /// Gets or Sets InfographicImage
        /// </summary>
        [DataMember(Name="infographicImage", EmitDefaultValue=false)]
        public ImageDto InfographicImage { get; set; }

        /// <summary>
        /// Gets or Sets SeoAttributes
        /// </summary>
        [DataMember(Name="SeoAttributes", EmitDefaultValue=false)]
        public SeoAttributesDto SeoAttributes { get; set; }

        /// <summary>
        /// Gets or Sets SocialShareAttributes
        /// </summary>
        [DataMember(Name="socialShareAttributes", EmitDefaultValue=false)]
        public SocialShareAttributesDto SocialShareAttributes { get; set; }

        /// <summary>
        /// Gets or Sets VideoList
        /// </summary>
        [DataMember(Name="videoList", EmitDefaultValue=false)]
        public List<VideoDto> VideoList { get; set; }

        /// <summary>
        /// Gets or Sets ImageList
        /// </summary>
        [DataMember(Name="imageList", EmitDefaultValue=false)]
        public List<ImageDto> ImageList { get; set; }

        /// <summary>
        /// Gets or Sets SectionList
        /// </summary>
        [DataMember(Name="sectionList", EmitDefaultValue=false)]
        public List<SectionDto> SectionList { get; set; }

        /// <summary>
        /// Gets or Sets CallToActionDetails
        /// </summary>
        [DataMember(Name="callToActionDetails", EmitDefaultValue=false)]
        public List<CallToActionDto> CallToActionDetails { get; set; }

        /// <summary>
        /// Gets or Sets SecondaryBannerImageList
        /// </summary>
        [DataMember(Name="secondaryBannerImageList", EmitDefaultValue=false)]
        public List<ImageDto> SecondaryBannerImageList { get; set; }

        /// <summary>
        /// Gets or Sets TitleChildCategory
        /// </summary>
        [DataMember(Name="titleChildCategory", EmitDefaultValue=false)]
        public List<CategoryDto> TitleChildCategory { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class CategoryDto {\n");
            sb.Append("  URL: ").Append(URL).Append("\n");
            sb.Append("  CategoryBanner: ").Append(CategoryBanner).Append("\n");
            sb.Append("  CategoryName: ").Append(CategoryName).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  ExternalURL: ").Append(ExternalURL).Append("\n");
            sb.Append("  Gated: ").Append(Gated).Append("\n");
            sb.Append("  LogoDescription: ").Append(LogoDescription).Append("\n");
            sb.Append("  LongDescription: ").Append(LongDescription).Append("\n");
            sb.Append("  M3DImagePath: ").Append(M3DImagePath).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Pdg: ").Append(Pdg).Append("\n");
            sb.Append("  RequestMoreDescription: ").Append(RequestMoreDescription).Append("\n");
            sb.Append("  RequestMoreUrl: ").Append(RequestMoreUrl).Append("\n");
            sb.Append("  Section: ").Append(Section).Append("\n");
            sb.Append("  SectionsDescriptionSolution: ").Append(SectionsDescriptionSolution).Append("\n");
            sb.Append("  SectionsNameSolution: ").Append(SectionsNameSolution).Append("\n");
            sb.Append("  SeoURL: ").Append(SeoURL).Append("\n");
            sb.Append("  Slideshows: ").Append(Slideshows).Append("\n");
            sb.Append("  Target: ").Append(Target).Append("\n");
            sb.Append("  TemplateId: ").Append(TemplateId).Append("\n");
            sb.Append("  TemplateType: ").Append(TemplateType).Append("\n");
            sb.Append("  Title: ").Append(Title).Append("\n");
            sb.Append("  WebDisplayName: ").Append(WebDisplayName).Append("\n");
            sb.Append("  ChildCategory: ").Append(ChildCategory).Append("\n");
            sb.Append("  ChildProducts: ").Append(ChildProducts).Append("\n");
            sb.Append("  Sections: ").Append(Sections).Append("\n");
            sb.Append("  TabSections: ").Append(TabSections).Append("\n");
            sb.Append("  BlogSections: ").Append(BlogSections).Append("\n");
            sb.Append("  FeaturedSections: ").Append(FeaturedSections).Append("\n");
            sb.Append("  Images: ").Append(Images).Append("\n");
            sb.Append("  Videos: ").Append(Videos).Append("\n");
            sb.Append("  ImageDetails: ").Append(ImageDetails).Append("\n");
            sb.Append("  InfographicImage: ").Append(InfographicImage).Append("\n");
            sb.Append("  SeoAttributes: ").Append(SeoAttributes).Append("\n");
            sb.Append("  SocialShareAttributes: ").Append(SocialShareAttributes).Append("\n");
            sb.Append("  VideoList: ").Append(VideoList).Append("\n");
            sb.Append("  ImageList: ").Append(ImageList).Append("\n");
            sb.Append("  SectionList: ").Append(SectionList).Append("\n");
            sb.Append("  CallToActionDetails: ").Append(CallToActionDetails).Append("\n");
            sb.Append("  SecondaryBannerImageList: ").Append(SecondaryBannerImageList).Append("\n");
            sb.Append("  TitleChildCategory: ").Append(TitleChildCategory).Append("\n");
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
            return this.Equals(input as CategoryDto);
        }

        /// <summary>
        /// Returns true if CategoryDto instances are equal
        /// </summary>
        /// <param name="input">Instance of CategoryDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(CategoryDto input)
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
                    this.CategoryBanner == input.CategoryBanner ||
                    (this.CategoryBanner != null &&
                    this.CategoryBanner.Equals(input.CategoryBanner))
                ) && 
                (
                    this.CategoryName == input.CategoryName ||
                    (this.CategoryName != null &&
                    this.CategoryName.Equals(input.CategoryName))
                ) && 
                (
                    this.Description == input.Description ||
                    (this.Description != null &&
                    this.Description.Equals(input.Description))
                ) && 
                (
                    this.ExternalURL == input.ExternalURL ||
                    (this.ExternalURL != null &&
                    this.ExternalURL.Equals(input.ExternalURL))
                ) && 
                (
                    this.Gated == input.Gated ||
                    (this.Gated != null &&
                    this.Gated.Equals(input.Gated))
                ) && 
                (
                    this.LogoDescription == input.LogoDescription ||
                    (this.LogoDescription != null &&
                    this.LogoDescription.Equals(input.LogoDescription))
                ) && 
                (
                    this.LongDescription == input.LongDescription ||
                    (this.LongDescription != null &&
                    this.LongDescription.Equals(input.LongDescription))
                ) && 
                (
                    this.M3DImagePath == input.M3DImagePath ||
                    (this.M3DImagePath != null &&
                    this.M3DImagePath.Equals(input.M3DImagePath))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Pdg == input.Pdg ||
                    (this.Pdg != null &&
                    this.Pdg.Equals(input.Pdg))
                ) && 
                (
                    this.RequestMoreDescription == input.RequestMoreDescription ||
                    (this.RequestMoreDescription != null &&
                    this.RequestMoreDescription.Equals(input.RequestMoreDescription))
                ) && 
                (
                    this.RequestMoreUrl == input.RequestMoreUrl ||
                    (this.RequestMoreUrl != null &&
                    this.RequestMoreUrl.Equals(input.RequestMoreUrl))
                ) && 
                (
                    this.Section == input.Section ||
                    (this.Section != null &&
                    this.Section.Equals(input.Section))
                ) && 
                (
                    this.SectionsDescriptionSolution == input.SectionsDescriptionSolution ||
                    (this.SectionsDescriptionSolution != null &&
                    this.SectionsDescriptionSolution.Equals(input.SectionsDescriptionSolution))
                ) && 
                (
                    this.SectionsNameSolution == input.SectionsNameSolution ||
                    (this.SectionsNameSolution != null &&
                    this.SectionsNameSolution.Equals(input.SectionsNameSolution))
                ) && 
                (
                    this.SeoURL == input.SeoURL ||
                    (this.SeoURL != null &&
                    this.SeoURL.Equals(input.SeoURL))
                ) && 
                (
                    this.Slideshows == input.Slideshows ||
                    (this.Slideshows != null &&
                    this.Slideshows.Equals(input.Slideshows))
                ) && 
                (
                    this.Target == input.Target ||
                    (this.Target != null &&
                    this.Target.Equals(input.Target))
                ) && 
                (
                    this.TemplateId == input.TemplateId ||
                    (this.TemplateId != null &&
                    this.TemplateId.Equals(input.TemplateId))
                ) && 
                (
                    this.TemplateType == input.TemplateType ||
                    (this.TemplateType != null &&
                    this.TemplateType.Equals(input.TemplateType))
                ) && 
                (
                    this.Title == input.Title ||
                    (this.Title != null &&
                    this.Title.Equals(input.Title))
                ) && 
                (
                    this.WebDisplayName == input.WebDisplayName ||
                    (this.WebDisplayName != null &&
                    this.WebDisplayName.Equals(input.WebDisplayName))
                ) && 
                (
                    this.ChildCategory == input.ChildCategory ||
                    this.ChildCategory != null &&
                    this.ChildCategory.SequenceEqual(input.ChildCategory)
                ) && 
                (
                    this.ChildProducts == input.ChildProducts ||
                    this.ChildProducts != null &&
                    this.ChildProducts.SequenceEqual(input.ChildProducts)
                ) && 
                (
                    this.Sections == input.Sections ||
                    this.Sections != null &&
                    this.Sections.SequenceEqual(input.Sections)
                ) && 
                (
                    this.TabSections == input.TabSections ||
                    this.TabSections != null &&
                    this.TabSections.SequenceEqual(input.TabSections)
                ) && 
                (
                    this.BlogSections == input.BlogSections ||
                    this.BlogSections != null &&
                    this.BlogSections.SequenceEqual(input.BlogSections)
                ) && 
                (
                    this.FeaturedSections == input.FeaturedSections ||
                    this.FeaturedSections != null &&
                    this.FeaturedSections.SequenceEqual(input.FeaturedSections)
                ) && 
                (
                    this.Images == input.Images ||
                    this.Images != null &&
                    this.Images.SequenceEqual(input.Images)
                ) && 
                (
                    this.Videos == input.Videos ||
                    this.Videos != null &&
                    this.Videos.SequenceEqual(input.Videos)
                ) && 
                (
                    this.ImageDetails == input.ImageDetails ||
                    (this.ImageDetails != null &&
                    this.ImageDetails.Equals(input.ImageDetails))
                ) && 
                (
                    this.InfographicImage == input.InfographicImage ||
                    (this.InfographicImage != null &&
                    this.InfographicImage.Equals(input.InfographicImage))
                ) && 
                (
                    this.SeoAttributes == input.SeoAttributes ||
                    (this.SeoAttributes != null &&
                    this.SeoAttributes.Equals(input.SeoAttributes))
                ) && 
                (
                    this.SocialShareAttributes == input.SocialShareAttributes ||
                    (this.SocialShareAttributes != null &&
                    this.SocialShareAttributes.Equals(input.SocialShareAttributes))
                ) && 
                (
                    this.VideoList == input.VideoList ||
                    this.VideoList != null &&
                    this.VideoList.SequenceEqual(input.VideoList)
                ) && 
                (
                    this.ImageList == input.ImageList ||
                    this.ImageList != null &&
                    this.ImageList.SequenceEqual(input.ImageList)
                ) && 
                (
                    this.SectionList == input.SectionList ||
                    this.SectionList != null &&
                    this.SectionList.SequenceEqual(input.SectionList)
                ) && 
                (
                    this.CallToActionDetails == input.CallToActionDetails ||
                    this.CallToActionDetails != null &&
                    this.CallToActionDetails.SequenceEqual(input.CallToActionDetails)
                ) && 
                (
                    this.SecondaryBannerImageList == input.SecondaryBannerImageList ||
                    this.SecondaryBannerImageList != null &&
                    this.SecondaryBannerImageList.SequenceEqual(input.SecondaryBannerImageList)
                ) && 
                (
                    this.TitleChildCategory == input.TitleChildCategory ||
                    this.TitleChildCategory != null &&
                    this.TitleChildCategory.SequenceEqual(input.TitleChildCategory)
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
                if (this.CategoryBanner != null)
                    hashCode = hashCode * 59 + this.CategoryBanner.GetHashCode();
                if (this.CategoryName != null)
                    hashCode = hashCode * 59 + this.CategoryName.GetHashCode();
                if (this.Description != null)
                    hashCode = hashCode * 59 + this.Description.GetHashCode();
                if (this.ExternalURL != null)
                    hashCode = hashCode * 59 + this.ExternalURL.GetHashCode();
                if (this.Gated != null)
                    hashCode = hashCode * 59 + this.Gated.GetHashCode();
                if (this.LogoDescription != null)
                    hashCode = hashCode * 59 + this.LogoDescription.GetHashCode();
                if (this.LongDescription != null)
                    hashCode = hashCode * 59 + this.LongDescription.GetHashCode();
                if (this.M3DImagePath != null)
                    hashCode = hashCode * 59 + this.M3DImagePath.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Pdg != null)
                    hashCode = hashCode * 59 + this.Pdg.GetHashCode();
                if (this.RequestMoreDescription != null)
                    hashCode = hashCode * 59 + this.RequestMoreDescription.GetHashCode();
                if (this.RequestMoreUrl != null)
                    hashCode = hashCode * 59 + this.RequestMoreUrl.GetHashCode();
                if (this.Section != null)
                    hashCode = hashCode * 59 + this.Section.GetHashCode();
                if (this.SectionsDescriptionSolution != null)
                    hashCode = hashCode * 59 + this.SectionsDescriptionSolution.GetHashCode();
                if (this.SectionsNameSolution != null)
                    hashCode = hashCode * 59 + this.SectionsNameSolution.GetHashCode();
                if (this.SeoURL != null)
                    hashCode = hashCode * 59 + this.SeoURL.GetHashCode();
                if (this.Slideshows != null)
                    hashCode = hashCode * 59 + this.Slideshows.GetHashCode();
                if (this.Target != null)
                    hashCode = hashCode * 59 + this.Target.GetHashCode();
                if (this.TemplateId != null)
                    hashCode = hashCode * 59 + this.TemplateId.GetHashCode();
                if (this.TemplateType != null)
                    hashCode = hashCode * 59 + this.TemplateType.GetHashCode();
                if (this.Title != null)
                    hashCode = hashCode * 59 + this.Title.GetHashCode();
                if (this.WebDisplayName != null)
                    hashCode = hashCode * 59 + this.WebDisplayName.GetHashCode();
                if (this.ChildCategory != null)
                    hashCode = hashCode * 59 + this.ChildCategory.GetHashCode();
                if (this.ChildProducts != null)
                    hashCode = hashCode * 59 + this.ChildProducts.GetHashCode();
                if (this.Sections != null)
                    hashCode = hashCode * 59 + this.Sections.GetHashCode();
                if (this.TabSections != null)
                    hashCode = hashCode * 59 + this.TabSections.GetHashCode();
                if (this.BlogSections != null)
                    hashCode = hashCode * 59 + this.BlogSections.GetHashCode();
                if (this.FeaturedSections != null)
                    hashCode = hashCode * 59 + this.FeaturedSections.GetHashCode();
                if (this.Images != null)
                    hashCode = hashCode * 59 + this.Images.GetHashCode();
                if (this.Videos != null)
                    hashCode = hashCode * 59 + this.Videos.GetHashCode();
                if (this.ImageDetails != null)
                    hashCode = hashCode * 59 + this.ImageDetails.GetHashCode();
                if (this.InfographicImage != null)
                    hashCode = hashCode * 59 + this.InfographicImage.GetHashCode();
                if (this.SeoAttributes != null)
                    hashCode = hashCode * 59 + this.SeoAttributes.GetHashCode();
                if (this.SocialShareAttributes != null)
                    hashCode = hashCode * 59 + this.SocialShareAttributes.GetHashCode();
                if (this.VideoList != null)
                    hashCode = hashCode * 59 + this.VideoList.GetHashCode();
                if (this.ImageList != null)
                    hashCode = hashCode * 59 + this.ImageList.GetHashCode();
                if (this.SectionList != null)
                    hashCode = hashCode * 59 + this.SectionList.GetHashCode();
                if (this.CallToActionDetails != null)
                    hashCode = hashCode * 59 + this.CallToActionDetails.GetHashCode();
                if (this.SecondaryBannerImageList != null)
                    hashCode = hashCode * 59 + this.SecondaryBannerImageList.GetHashCode();
                if (this.TitleChildCategory != null)
                    hashCode = hashCode * 59 + this.TitleChildCategory.GetHashCode();
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