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
    /// SimulateOrderResponseRootMESSAGETABLE
    /// </summary>
    
    public partial class SimulateOrderResponseRootMESSAGETABLE :  IEquatable<SimulateOrderResponseRootMESSAGETABLE>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulateOrderResponseRootMESSAGETABLE" /> class.
        /// </summary>
        /// <param name="TYPE">TYPE.</param>
        /// <param name="ID">ID.</param>
        /// <param name="NUMBER">NUMBER.</param>
        /// <param name="MESSAGE">MESSAGE.</param>
        /// <param name="LOG_NO">LOG_NO.</param>
        /// <param name="LOG_MSG_NO">LOG_MSG_NO.</param>
        /// <param name="MESSAGEV1">MESSAGEV1.</param>
        /// <param name="MESSAGEV2">MESSAGEV2.</param>
        /// <param name="MESSAGEV3">MESSAGEV3.</param>
        /// <param name="MESSAGEV4">MESSAGEV4.</param>
        /// <param name="PARAMETER">PARAMETER.</param>
        /// <param name="ROW">ROW.</param>
        /// <param name="FIELD">FIELD.</param>
        /// <param name="SYSTEM">SYSTEM.</param>
        public SimulateOrderResponseRootMESSAGETABLE(string TYPE = default(string), string ID = default(string), string NUMBER = default(string), string MESSAGE = default(string), string LOG_NO = default(string), string LOG_MSG_NO = default(string), string MESSAGEV1 = default(string), string MESSAGEV2 = default(string), string MESSAGEV3 = default(string), string MESSAGEV4 = default(string), string PARAMETER = default(string), string ROW = default(string), string FIELD = default(string), string SYSTEM = default(string))
        {
            this.TYPE = TYPE;
            this.ID = ID;
            this.NUMBER = NUMBER;
            this.MESSAGE = MESSAGE;
            this.LOG_NO = LOG_NO;
            this.LOG_MSG_NO = LOG_MSG_NO;
            this.MESSAGEV1 = MESSAGEV1;
            this.MESSAGEV2 = MESSAGEV2;
            this.MESSAGEV3 = MESSAGEV3;
            this.MESSAGEV4 = MESSAGEV4;
            this.PARAMETER = PARAMETER;
            this.ROW = ROW;
            this.FIELD = FIELD;
            this.SYSTEM = SYSTEM;
        }
        
        /// <summary>
        /// Gets or Sets TYPE
        /// </summary>
        [DataMember(Name="TYPE", EmitDefaultValue=false)]
        public string TYPE { get; set; }

        /// <summary>
        /// Gets or Sets ID
        /// </summary>
        [DataMember(Name="ID", EmitDefaultValue=false)]
        public string ID { get; set; }

        /// <summary>
        /// Gets or Sets NUMBER
        /// </summary>
        [DataMember(Name="NUMBER", EmitDefaultValue=false)]
        public string NUMBER { get; set; }

        /// <summary>
        /// Gets or Sets MESSAGE
        /// </summary>
        [DataMember(Name="MESSAGE", EmitDefaultValue=false)]
        public string MESSAGE { get; set; }

        /// <summary>
        /// Gets or Sets LOG_NO
        /// </summary>
        [DataMember(Name="LOG_NO", EmitDefaultValue=false)]
        public string LOG_NO { get; set; }

        /// <summary>
        /// Gets or Sets LOG_MSG_NO
        /// </summary>
        [DataMember(Name="LOG_MSG_NO", EmitDefaultValue=false)]
        public string LOG_MSG_NO { get; set; }

        /// <summary>
        /// Gets or Sets MESSAGEV1
        /// </summary>
        [DataMember(Name="MESSAGE_V1", EmitDefaultValue=false)]
        public string MESSAGEV1 { get; set; }

        /// <summary>
        /// Gets or Sets MESSAGEV2
        /// </summary>
        [DataMember(Name="MESSAGE_V2", EmitDefaultValue=false)]
        public string MESSAGEV2 { get; set; }

        /// <summary>
        /// Gets or Sets MESSAGEV3
        /// </summary>
        [DataMember(Name="MESSAGE_V3", EmitDefaultValue=false)]
        public string MESSAGEV3 { get; set; }

        /// <summary>
        /// Gets or Sets MESSAGEV4
        /// </summary>
        [DataMember(Name="MESSAGE_V4", EmitDefaultValue=false)]
        public string MESSAGEV4 { get; set; }

        /// <summary>
        /// Gets or Sets PARAMETER
        /// </summary>
        [DataMember(Name="PARAMETER", EmitDefaultValue=false)]
        public string PARAMETER { get; set; }

        /// <summary>
        /// Gets or Sets ROW
        /// </summary>
        [DataMember(Name="ROW", EmitDefaultValue=false)]
        public string ROW { get; set; }

        /// <summary>
        /// Gets or Sets FIELD
        /// </summary>
        [DataMember(Name="FIELD", EmitDefaultValue=false)]
        public string FIELD { get; set; }

        /// <summary>
        /// Gets or Sets SYSTEM
        /// </summary>
        [DataMember(Name="SYSTEM", EmitDefaultValue=false)]
        public string SYSTEM { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SimulateOrderResponseRootMESSAGETABLE {\n");
            sb.Append("  TYPE: ").Append(TYPE).Append("\n");
            sb.Append("  ID: ").Append(ID).Append("\n");
            sb.Append("  NUMBER: ").Append(NUMBER).Append("\n");
            sb.Append("  MESSAGE: ").Append(MESSAGE).Append("\n");
            sb.Append("  LOG_NO: ").Append(LOG_NO).Append("\n");
            sb.Append("  LOG_MSG_NO: ").Append(LOG_MSG_NO).Append("\n");
            sb.Append("  MESSAGEV1: ").Append(MESSAGEV1).Append("\n");
            sb.Append("  MESSAGEV2: ").Append(MESSAGEV2).Append("\n");
            sb.Append("  MESSAGEV3: ").Append(MESSAGEV3).Append("\n");
            sb.Append("  MESSAGEV4: ").Append(MESSAGEV4).Append("\n");
            sb.Append("  PARAMETER: ").Append(PARAMETER).Append("\n");
            sb.Append("  ROW: ").Append(ROW).Append("\n");
            sb.Append("  FIELD: ").Append(FIELD).Append("\n");
            sb.Append("  SYSTEM: ").Append(SYSTEM).Append("\n");
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
            return this.Equals(input as SimulateOrderResponseRootMESSAGETABLE);
        }

        /// <summary>
        /// Returns true if SimulateOrderResponseRootMESSAGETABLE instances are equal
        /// </summary>
        /// <param name="input">Instance of SimulateOrderResponseRootMESSAGETABLE to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimulateOrderResponseRootMESSAGETABLE input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.TYPE == input.TYPE ||
                    (this.TYPE != null &&
                    this.TYPE.Equals(input.TYPE))
                ) && 
                (
                    this.ID == input.ID ||
                    (this.ID != null &&
                    this.ID.Equals(input.ID))
                ) && 
                (
                    this.NUMBER == input.NUMBER ||
                    (this.NUMBER != null &&
                    this.NUMBER.Equals(input.NUMBER))
                ) && 
                (
                    this.MESSAGE == input.MESSAGE ||
                    (this.MESSAGE != null &&
                    this.MESSAGE.Equals(input.MESSAGE))
                ) && 
                (
                    this.LOG_NO == input.LOG_NO ||
                    (this.LOG_NO != null &&
                    this.LOG_NO.Equals(input.LOG_NO))
                ) && 
                (
                    this.LOG_MSG_NO == input.LOG_MSG_NO ||
                    (this.LOG_MSG_NO != null &&
                    this.LOG_MSG_NO.Equals(input.LOG_MSG_NO))
                ) && 
                (
                    this.MESSAGEV1 == input.MESSAGEV1 ||
                    (this.MESSAGEV1 != null &&
                    this.MESSAGEV1.Equals(input.MESSAGEV1))
                ) && 
                (
                    this.MESSAGEV2 == input.MESSAGEV2 ||
                    (this.MESSAGEV2 != null &&
                    this.MESSAGEV2.Equals(input.MESSAGEV2))
                ) && 
                (
                    this.MESSAGEV3 == input.MESSAGEV3 ||
                    (this.MESSAGEV3 != null &&
                    this.MESSAGEV3.Equals(input.MESSAGEV3))
                ) && 
                (
                    this.MESSAGEV4 == input.MESSAGEV4 ||
                    (this.MESSAGEV4 != null &&
                    this.MESSAGEV4.Equals(input.MESSAGEV4))
                ) && 
                (
                    this.PARAMETER == input.PARAMETER ||
                    (this.PARAMETER != null &&
                    this.PARAMETER.Equals(input.PARAMETER))
                ) && 
                (
                    this.ROW == input.ROW ||
                    (this.ROW != null &&
                    this.ROW.Equals(input.ROW))
                ) && 
                (
                    this.FIELD == input.FIELD ||
                    (this.FIELD != null &&
                    this.FIELD.Equals(input.FIELD))
                ) && 
                (
                    this.SYSTEM == input.SYSTEM ||
                    (this.SYSTEM != null &&
                    this.SYSTEM.Equals(input.SYSTEM))
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
                if (this.TYPE != null)
                    hashCode = hashCode * 59 + this.TYPE.GetHashCode();
                if (this.ID != null)
                    hashCode = hashCode * 59 + this.ID.GetHashCode();
                if (this.NUMBER != null)
                    hashCode = hashCode * 59 + this.NUMBER.GetHashCode();
                if (this.MESSAGE != null)
                    hashCode = hashCode * 59 + this.MESSAGE.GetHashCode();
                if (this.LOG_NO != null)
                    hashCode = hashCode * 59 + this.LOG_NO.GetHashCode();
                if (this.LOG_MSG_NO != null)
                    hashCode = hashCode * 59 + this.LOG_MSG_NO.GetHashCode();
                if (this.MESSAGEV1 != null)
                    hashCode = hashCode * 59 + this.MESSAGEV1.GetHashCode();
                if (this.MESSAGEV2 != null)
                    hashCode = hashCode * 59 + this.MESSAGEV2.GetHashCode();
                if (this.MESSAGEV3 != null)
                    hashCode = hashCode * 59 + this.MESSAGEV3.GetHashCode();
                if (this.MESSAGEV4 != null)
                    hashCode = hashCode * 59 + this.MESSAGEV4.GetHashCode();
                if (this.PARAMETER != null)
                    hashCode = hashCode * 59 + this.PARAMETER.GetHashCode();
                if (this.ROW != null)
                    hashCode = hashCode * 59 + this.ROW.GetHashCode();
                if (this.FIELD != null)
                    hashCode = hashCode * 59 + this.FIELD.GetHashCode();
                if (this.SYSTEM != null)
                    hashCode = hashCode * 59 + this.SYSTEM.GetHashCode();
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
