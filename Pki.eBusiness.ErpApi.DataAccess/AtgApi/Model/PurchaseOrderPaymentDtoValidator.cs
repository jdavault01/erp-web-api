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
    /// PurchaseOrderPaymentDtoValidator
    /// </summary>
    [DataContract]
    public partial class PurchaseOrderPaymentDtoValidator :  IEquatable<PurchaseOrderPaymentDtoValidator>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderPaymentDtoValidator" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected PurchaseOrderPaymentDtoValidator() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderPaymentDtoValidator" /> class.
        /// </summary>
        /// <param name="PurchaseOrderNumber">PurchaseOrderNumber (required).</param>
        /// <param name="PaymentType">PaymentType.</param>
        /// <param name="BillToAddress">BillToAddress.</param>
        public PurchaseOrderPaymentDtoValidator(string PurchaseOrderNumber = default(string), string PaymentType = default(string), AddressDtoValidator BillToAddress = default(AddressDtoValidator))
        {
            // to ensure "PurchaseOrderNumber" is required (not null)
            if (PurchaseOrderNumber == null)
            {
                throw new InvalidDataException("PurchaseOrderNumber is a required property for PurchaseOrderPaymentDtoValidator and cannot be null");
            }
            else
            {
                this.PurchaseOrderNumber = PurchaseOrderNumber;
            }
            this.PaymentType = PaymentType;
            this.BillToAddress = BillToAddress;
        }
        
        /// <summary>
        /// Gets or Sets PurchaseOrderNumber
        /// </summary>
        [DataMember(Name="purchaseOrderNumber", EmitDefaultValue=false)]
        public string PurchaseOrderNumber { get; set; }

        /// <summary>
        /// Gets or Sets PaymentType
        /// </summary>
        [DataMember(Name="paymentType", EmitDefaultValue=false)]
        public string PaymentType { get; set; }

        /// <summary>
        /// Gets or Sets BillToAddress
        /// </summary>
        [DataMember(Name="billToAddress", EmitDefaultValue=false)]
        public AddressDtoValidator BillToAddress { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PurchaseOrderPaymentDtoValidator {\n");
            sb.Append("  PurchaseOrderNumber: ").Append(PurchaseOrderNumber).Append("\n");
            sb.Append("  PaymentType: ").Append(PaymentType).Append("\n");
            sb.Append("  BillToAddress: ").Append(BillToAddress).Append("\n");
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
            return this.Equals(input as PurchaseOrderPaymentDtoValidator);
        }

        /// <summary>
        /// Returns true if PurchaseOrderPaymentDtoValidator instances are equal
        /// </summary>
        /// <param name="input">Instance of PurchaseOrderPaymentDtoValidator to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PurchaseOrderPaymentDtoValidator input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.PurchaseOrderNumber == input.PurchaseOrderNumber ||
                    (this.PurchaseOrderNumber != null &&
                    this.PurchaseOrderNumber.Equals(input.PurchaseOrderNumber))
                ) && 
                (
                    this.PaymentType == input.PaymentType ||
                    (this.PaymentType != null &&
                    this.PaymentType.Equals(input.PaymentType))
                ) && 
                (
                    this.BillToAddress == input.BillToAddress ||
                    (this.BillToAddress != null &&
                    this.BillToAddress.Equals(input.BillToAddress))
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
                if (this.PurchaseOrderNumber != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderNumber.GetHashCode();
                if (this.PaymentType != null)
                    hashCode = hashCode * 59 + this.PaymentType.GetHashCode();
                if (this.BillToAddress != null)
                    hashCode = hashCode * 59 + this.BillToAddress.GetHashCode();
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