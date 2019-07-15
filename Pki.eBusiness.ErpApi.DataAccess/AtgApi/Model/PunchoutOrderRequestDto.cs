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
    /// PunchoutOrderRequestDto
    /// </summary>
    [DataContract]
    public partial class PunchoutOrderRequestDto :  IEquatable<PunchoutOrderRequestDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PunchoutOrderRequestDto" /> class.
        /// </summary>
        /// <param name="BrowserCookie">BrowserCookie.</param>
        /// <param name="Operation">Operation.</param>
        /// <param name="PayloadId">PayloadId.</param>
        /// <param name="PermitName">PermitName.</param>
        /// <param name="PermitNumber">PermitNumber.</param>
        /// <param name="Vendor">Vendor.</param>
        public PunchoutOrderRequestDto(string BrowserCookie = default(string), string Operation = default(string), string PayloadId = default(string), string PermitName = default(string), string PermitNumber = default(string), string Vendor = default(string))
        {
            this.BrowserCookie = BrowserCookie;
            this.Operation = Operation;
            this.PayloadId = PayloadId;
            this.PermitName = PermitName;
            this.PermitNumber = PermitNumber;
            this.Vendor = Vendor;
        }
        
        /// <summary>
        /// Gets or Sets BrowserCookie
        /// </summary>
        [DataMember(Name="browserCookie", EmitDefaultValue=false)]
        public string BrowserCookie { get; set; }

        /// <summary>
        /// Gets or Sets Operation
        /// </summary>
        [DataMember(Name="operation", EmitDefaultValue=false)]
        public string Operation { get; set; }

        /// <summary>
        /// Gets or Sets PayloadId
        /// </summary>
        [DataMember(Name="payloadId", EmitDefaultValue=false)]
        public string PayloadId { get; set; }

        /// <summary>
        /// Gets or Sets PermitName
        /// </summary>
        [DataMember(Name="permitName", EmitDefaultValue=false)]
        public string PermitName { get; set; }

        /// <summary>
        /// Gets or Sets PermitNumber
        /// </summary>
        [DataMember(Name="permitNumber", EmitDefaultValue=false)]
        public string PermitNumber { get; set; }

        /// <summary>
        /// Gets or Sets Vendor
        /// </summary>
        [DataMember(Name="vendor", EmitDefaultValue=false)]
        public string Vendor { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PunchoutOrderRequestDto {\n");
            sb.Append("  BrowserCookie: ").Append(BrowserCookie).Append("\n");
            sb.Append("  Operation: ").Append(Operation).Append("\n");
            sb.Append("  PayloadId: ").Append(PayloadId).Append("\n");
            sb.Append("  PermitName: ").Append(PermitName).Append("\n");
            sb.Append("  PermitNumber: ").Append(PermitNumber).Append("\n");
            sb.Append("  Vendor: ").Append(Vendor).Append("\n");
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
            return this.Equals(input as PunchoutOrderRequestDto);
        }

        /// <summary>
        /// Returns true if PunchoutOrderRequestDto instances are equal
        /// </summary>
        /// <param name="input">Instance of PunchoutOrderRequestDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PunchoutOrderRequestDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.BrowserCookie == input.BrowserCookie ||
                    (this.BrowserCookie != null &&
                    this.BrowserCookie.Equals(input.BrowserCookie))
                ) && 
                (
                    this.Operation == input.Operation ||
                    (this.Operation != null &&
                    this.Operation.Equals(input.Operation))
                ) && 
                (
                    this.PayloadId == input.PayloadId ||
                    (this.PayloadId != null &&
                    this.PayloadId.Equals(input.PayloadId))
                ) && 
                (
                    this.PermitName == input.PermitName ||
                    (this.PermitName != null &&
                    this.PermitName.Equals(input.PermitName))
                ) && 
                (
                    this.PermitNumber == input.PermitNumber ||
                    (this.PermitNumber != null &&
                    this.PermitNumber.Equals(input.PermitNumber))
                ) && 
                (
                    this.Vendor == input.Vendor ||
                    (this.Vendor != null &&
                    this.Vendor.Equals(input.Vendor))
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
                if (this.BrowserCookie != null)
                    hashCode = hashCode * 59 + this.BrowserCookie.GetHashCode();
                if (this.Operation != null)
                    hashCode = hashCode * 59 + this.Operation.GetHashCode();
                if (this.PayloadId != null)
                    hashCode = hashCode * 59 + this.PayloadId.GetHashCode();
                if (this.PermitName != null)
                    hashCode = hashCode * 59 + this.PermitName.GetHashCode();
                if (this.PermitNumber != null)
                    hashCode = hashCode * 59 + this.PermitNumber.GetHashCode();
                if (this.Vendor != null)
                    hashCode = hashCode * 59 + this.Vendor.GetHashCode();
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