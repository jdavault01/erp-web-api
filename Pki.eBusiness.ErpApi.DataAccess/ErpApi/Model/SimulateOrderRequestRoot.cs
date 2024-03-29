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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace Pki.eBusiness.ErpApi.DataAccess.ErpApi.Model
{
    /// <summary>
    /// SimulateOrderRequestRoot
    /// </summary>
    
    public partial class SimulateOrderRequestRoot :  IEquatable<SimulateOrderRequestRoot>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulateOrderRequestRoot" /> class.
        /// </summary>
        /// <param name="ORDER_ITEMS_IN">ORDER_ITEMS_IN.</param>
        /// <param name="ORDER_PARTNERS">ORDER_PARTNERS.</param>
        /// <param name="ORDER_HEADER_IN">ORDER_HEADER_IN.</param>
        public SimulateOrderRequestRoot(List<SimulateOrderRequestRootORDERITEMSIN> ORDER_ITEMS_IN = default(List<SimulateOrderRequestRootORDERITEMSIN>), List<SimulateOrderRequestRootORDERPARTNERS> ORDER_PARTNERS = default(List<SimulateOrderRequestRootORDERPARTNERS>), List<SimulateOrderRequestRootORDERHEADERIN> ORDER_HEADER_IN = default(List<SimulateOrderRequestRootORDERHEADERIN>))
        {
            this.ORDER_ITEMS_IN = ORDER_ITEMS_IN;
            this.ORDER_PARTNERS = ORDER_PARTNERS;
            this.ORDER_HEADER_IN = ORDER_HEADER_IN;
        }
        
        /// <summary>
        /// Gets or Sets ORDER_ITEMS_IN
        /// </summary>
        [DataMember(Name="ORDER_ITEMS_IN", EmitDefaultValue=false)]
        public List<SimulateOrderRequestRootORDERITEMSIN> ORDER_ITEMS_IN { get; set; }

        /// <summary>
        /// Gets or Sets ORDER_PARTNERS
        /// </summary>
        [DataMember(Name="ORDER_PARTNERS", EmitDefaultValue=false)]
        public List<SimulateOrderRequestRootORDERPARTNERS> ORDER_PARTNERS { get; set; }

        /// <summary>
        /// Gets or Sets ORDER_HEADER_IN
        /// </summary>
        [DataMember(Name="ORDER_HEADER_IN", EmitDefaultValue=false)]
        public List<SimulateOrderRequestRootORDERHEADERIN> ORDER_HEADER_IN { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SimulateOrderRequestRoot {\n");
            sb.Append("  ORDER_ITEMS_IN: ").Append(ORDER_ITEMS_IN).Append("\n");
            sb.Append("  ORDER_PARTNERS: ").Append(ORDER_PARTNERS).Append("\n");
            sb.Append("  ORDER_HEADER_IN: ").Append(ORDER_HEADER_IN).Append("\n");
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
            return this.Equals(input as SimulateOrderRequestRoot);
        }

        /// <summary>
        /// Returns true if SimulateOrderRequestRoot instances are equal
        /// </summary>
        /// <param name="input">Instance of SimulateOrderRequestRoot to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimulateOrderRequestRoot input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ORDER_ITEMS_IN == input.ORDER_ITEMS_IN ||
                    this.ORDER_ITEMS_IN != null &&
                    this.ORDER_ITEMS_IN.SequenceEqual(input.ORDER_ITEMS_IN)
                ) && 
                (
                    this.ORDER_PARTNERS == input.ORDER_PARTNERS ||
                    this.ORDER_PARTNERS != null &&
                    this.ORDER_PARTNERS.SequenceEqual(input.ORDER_PARTNERS)
                ) && 
                (
                    this.ORDER_HEADER_IN == input.ORDER_HEADER_IN ||
                    this.ORDER_HEADER_IN != null &&
                    this.ORDER_HEADER_IN.SequenceEqual(input.ORDER_HEADER_IN)
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
                if (this.ORDER_ITEMS_IN != null)
                    hashCode = hashCode * 59 + this.ORDER_ITEMS_IN.GetHashCode();
                if (this.ORDER_PARTNERS != null)
                    hashCode = hashCode * 59 + this.ORDER_PARTNERS.GetHashCode();
                if (this.ORDER_HEADER_IN != null)
                    hashCode = hashCode * 59 + this.ORDER_HEADER_IN.GetHashCode();
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
