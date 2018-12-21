/* 
 * eCommerce
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Pki.eBusiness.ErpApi.DataAccess.ErpApi.Model
{
    /// <summary>
    /// SimulateOrderRequestRootORDERITEMSIN
    /// </summary>
    
    public partial class SimulateOrderRequestRootORDERITEMSIN :  IEquatable<SimulateOrderRequestRootORDERITEMSIN>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulateOrderRequestRootORDERITEMSIN" /> class.
        /// </summary>
        /// <param name="ITM_NUMBER">ITM_NUMBER.</param>
        /// <param name="MATERIAL">MATERIAL.</param>
        /// <param name="REQ_QTY">REQ_QTY.</param>
        /// <param name="REQ_DATE">REQ_DATE.</param>
        public SimulateOrderRequestRootORDERITEMSIN(string ITM_NUMBER = default(string), string MATERIAL = default(string), string REQ_QTY = default(string), string REQ_DATE = default(string))
        {
            this.ITM_NUMBER = ITM_NUMBER;
            this.MATERIAL = MATERIAL;
            this.REQ_QTY = REQ_QTY;
            this.REQ_DATE = REQ_DATE;
        }
        
        /// <summary>
        /// Gets or Sets ITM_NUMBER
        /// </summary>
        [DataMember(Name="ITM_NUMBER", EmitDefaultValue=false)]
        public string ITM_NUMBER { get; set; }

        /// <summary>
        /// Gets or Sets MATERIAL
        /// </summary>
        [DataMember(Name="MATERIAL", EmitDefaultValue=false)]
        public string MATERIAL { get; set; }

        /// <summary>
        /// Gets or Sets REQ_QTY
        /// </summary>
        [DataMember(Name="REQ_QTY", EmitDefaultValue=false)]
        public string REQ_QTY { get; set; }

        /// <summary>
        /// Gets or Sets REQ_DATE
        /// </summary>
        [DataMember(Name="REQ_DATE", EmitDefaultValue=false)]
        public string REQ_DATE { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SimulateOrderRequestRootORDERITEMSIN {\n");
            sb.Append("  ITM_NUMBER: ").Append(ITM_NUMBER).Append("\n");
            sb.Append("  MATERIAL: ").Append(MATERIAL).Append("\n");
            sb.Append("  REQ_QTY: ").Append(REQ_QTY).Append("\n");
            sb.Append("  REQ_DATE: ").Append(REQ_DATE).Append("\n");
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
            return this.Equals(input as SimulateOrderRequestRootORDERITEMSIN);
        }

        /// <summary>
        /// Returns true if SimulateOrderRequestRootORDERITEMSIN instances are equal
        /// </summary>
        /// <param name="input">Instance of SimulateOrderRequestRootORDERITEMSIN to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimulateOrderRequestRootORDERITEMSIN input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ITM_NUMBER == input.ITM_NUMBER ||
                    (this.ITM_NUMBER != null &&
                    this.ITM_NUMBER.Equals(input.ITM_NUMBER))
                ) && 
                (
                    this.MATERIAL == input.MATERIAL ||
                    (this.MATERIAL != null &&
                    this.MATERIAL.Equals(input.MATERIAL))
                ) && 
                (
                    this.REQ_QTY == input.REQ_QTY ||
                    (this.REQ_QTY != null &&
                    this.REQ_QTY.Equals(input.REQ_QTY))
                ) && 
                (
                    this.REQ_DATE == input.REQ_DATE ||
                    (this.REQ_DATE != null &&
                    this.REQ_DATE.Equals(input.REQ_DATE))
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
                if (this.ITM_NUMBER != null)
                    hashCode = hashCode * 59 + this.ITM_NUMBER.GetHashCode();
                if (this.MATERIAL != null)
                    hashCode = hashCode * 59 + this.MATERIAL.GetHashCode();
                if (this.REQ_QTY != null)
                    hashCode = hashCode * 59 + this.REQ_QTY.GetHashCode();
                if (this.REQ_DATE != null)
                    hashCode = hashCode * 59 + this.REQ_DATE.GetHashCode();
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
