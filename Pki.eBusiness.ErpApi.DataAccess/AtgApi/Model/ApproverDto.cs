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
    /// ApproverDto
    /// </summary>
    [DataContract]
    public partial class ApproverDto :  IEquatable<ApproverDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApproverDto" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected ApproverDto() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApproverDto" /> class.
        /// </summary>
        /// <param name="EmailAddress">EmailAddress (required).</param>
        /// <param name="ApprovalType">ApprovalType (required).</param>
        /// <param name="ApprovalLevelTier">ApprovalLevelTier (required).</param>
        /// <param name="ApprovalMinimumCost">ApprovalMinimumCost.</param>
        /// <param name="Id">Id.</param>
        /// <param name="UserId">UserId.</param>
        public ApproverDto(string EmailAddress = default(string), string ApprovalType = default(string), int? ApprovalLevelTier = default(int?), double? ApprovalMinimumCost = default(double?), string Id = default(string), string UserId = default(string))
        {
            // to ensure "EmailAddress" is required (not null)
            if (EmailAddress == null)
            {
                throw new InvalidDataException("EmailAddress is a required property for ApproverDto and cannot be null");
            }
            else
            {
                this.EmailAddress = EmailAddress;
            }
            // to ensure "ApprovalType" is required (not null)
            if (ApprovalType == null)
            {
                throw new InvalidDataException("ApprovalType is a required property for ApproverDto and cannot be null");
            }
            else
            {
                this.ApprovalType = ApprovalType;
            }
            // to ensure "ApprovalLevelTier" is required (not null)
            if (ApprovalLevelTier == null)
            {
                throw new InvalidDataException("ApprovalLevelTier is a required property for ApproverDto and cannot be null");
            }
            else
            {
                this.ApprovalLevelTier = ApprovalLevelTier;
            }
            this.ApprovalMinimumCost = ApprovalMinimumCost;
            this.Id = Id;
            this.UserId = UserId;
        }
        
        /// <summary>
        /// Gets or Sets EmailAddress
        /// </summary>
        [DataMember(Name="emailAddress", EmitDefaultValue=false)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or Sets ApprovalType
        /// </summary>
        [DataMember(Name="approvalType", EmitDefaultValue=false)]
        public string ApprovalType { get; set; }

        /// <summary>
        /// Gets or Sets ApprovalLevelTier
        /// </summary>
        [DataMember(Name="approvalLevelTier", EmitDefaultValue=false)]
        public int? ApprovalLevelTier { get; set; }

        /// <summary>
        /// Gets or Sets ApprovalMinimumCost
        /// </summary>
        [DataMember(Name="approvalMinimumCost", EmitDefaultValue=false)]
        public double? ApprovalMinimumCost { get; set; }

        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets UserId
        /// </summary>
        [DataMember(Name="userId", EmitDefaultValue=false)]
        public string UserId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ApproverDto {\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
            sb.Append("  ApprovalType: ").Append(ApprovalType).Append("\n");
            sb.Append("  ApprovalLevelTier: ").Append(ApprovalLevelTier).Append("\n");
            sb.Append("  ApprovalMinimumCost: ").Append(ApprovalMinimumCost).Append("\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
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
            return this.Equals(input as ApproverDto);
        }

        /// <summary>
        /// Returns true if ApproverDto instances are equal
        /// </summary>
        /// <param name="input">Instance of ApproverDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ApproverDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.EmailAddress == input.EmailAddress ||
                    (this.EmailAddress != null &&
                    this.EmailAddress.Equals(input.EmailAddress))
                ) && 
                (
                    this.ApprovalType == input.ApprovalType ||
                    (this.ApprovalType != null &&
                    this.ApprovalType.Equals(input.ApprovalType))
                ) && 
                (
                    this.ApprovalLevelTier == input.ApprovalLevelTier ||
                    (this.ApprovalLevelTier != null &&
                    this.ApprovalLevelTier.Equals(input.ApprovalLevelTier))
                ) && 
                (
                    this.ApprovalMinimumCost == input.ApprovalMinimumCost ||
                    (this.ApprovalMinimumCost != null &&
                    this.ApprovalMinimumCost.Equals(input.ApprovalMinimumCost))
                ) && 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.UserId == input.UserId ||
                    (this.UserId != null &&
                    this.UserId.Equals(input.UserId))
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
                if (this.EmailAddress != null)
                    hashCode = hashCode * 59 + this.EmailAddress.GetHashCode();
                if (this.ApprovalType != null)
                    hashCode = hashCode * 59 + this.ApprovalType.GetHashCode();
                if (this.ApprovalLevelTier != null)
                    hashCode = hashCode * 59 + this.ApprovalLevelTier.GetHashCode();
                if (this.ApprovalMinimumCost != null)
                    hashCode = hashCode * 59 + this.ApprovalMinimumCost.GetHashCode();
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.UserId != null)
                    hashCode = hashCode * 59 + this.UserId.GetHashCode();
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
