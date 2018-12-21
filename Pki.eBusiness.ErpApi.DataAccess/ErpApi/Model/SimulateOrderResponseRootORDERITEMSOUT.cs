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
    /// SimulateOrderResponseRootORDERITEMSOUT
    /// </summary>
    
    public partial class SimulateOrderResponseRootORDERITEMSOUT :  IEquatable<SimulateOrderResponseRootORDERITEMSOUT>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulateOrderResponseRootORDERITEMSOUT" /> class.
        /// </summary>
        /// <param name="ITM_NUMBER">ITM_NUMBER.</param>
        /// <param name="PO_ITM_NO">PO_ITM_NO.</param>
        /// <param name="MATERIAL">MATERIAL.</param>
        /// <param name="MAT_ENTRD">MAT_ENTRD.</param>
        /// <param name="SHORT_TEXT">SHORT_TEXT.</param>
        /// <param name="NET_VALUE">NET_VALUE.</param>
        /// <param name="CURRENCY">CURRENCY.</param>
        /// <param name="SUBTOTAL1">SUBTOTAL1.</param>
        /// <param name="SUBTOTAL2">SUBTOTAL2.</param>
        /// <param name="SUBTOTAL3">SUBTOTAL3.</param>
        /// <param name="SUBTOTAL4">SUBTOTAL4.</param>
        /// <param name="SUBTOTAL5">SUBTOTAL5.</param>
        /// <param name="SUBTOTAL6">SUBTOTAL6.</param>
        /// <param name="TX_DOC_CUR">TX_DOC_CUR.</param>
        /// <param name="NETVALUE1">NETVALUE1.</param>
        public SimulateOrderResponseRootORDERITEMSOUT(string ITM_NUMBER = default(string), string PO_ITM_NO = default(string), string MATERIAL = default(string), string MAT_ENTRD = default(string), string SHORT_TEXT = default(string), string NET_VALUE = default(string), string CURRENCY = default(string), double? SUBTOTAL1 = default(double?), double? SUBTOTAL2 = default(double?), double? SUBTOTAL3 = default(double?), double? SUBTOTAL4 = default(double?), double? SUBTOTAL5 = default(double?), double? SUBTOTAL6 = default(double?), double? TX_DOC_CUR = default(double?), double? NETVALUE1 = default(double?), double? REQ_QTY = default(double?), string SHIP_POINT = default(string))
        {
            this.ITM_NUMBER = ITM_NUMBER;
            this.PO_ITM_NO = PO_ITM_NO;
            this.MATERIAL = MATERIAL;
            this.MAT_ENTRD = MAT_ENTRD;
            this.SHORT_TEXT = SHORT_TEXT;
            this.NET_VALUE = NET_VALUE;
            this.CURRENCY = CURRENCY;
            this.SUBTOTAL1 = SUBTOTAL1;
            this.SUBTOTAL2 = SUBTOTAL2;
            this.SUBTOTAL3 = SUBTOTAL3;
            this.SUBTOTAL4 = SUBTOTAL4;
            this.SUBTOTAL5 = SUBTOTAL5;
            this.SUBTOTAL6 = SUBTOTAL6;
            this.TX_DOC_CUR = TX_DOC_CUR;
            this.NETVALUE1 = NETVALUE1;
            this.REQ_QTY = REQ_QTY;
            this.SHIP_POINT = SHIP_POINT;
        }


        [DataMember(Name = "SHIP_POINT", EmitDefaultValue = false)]
        public string SHIP_POINT { get; set; }

        /// <summary>
        /// Gets or Sets ITM_NUMBER
        /// </summary>
        [DataMember(Name="ITM_NUMBER", EmitDefaultValue=false)]
        public string ITM_NUMBER { get; set; }

        [DataMember(Name = "REQ_QTY", EmitDefaultValue = false)]
        public double? REQ_QTY { get; set; }


        /// <summary>
        /// Gets or Sets PO_ITM_NO
        /// </summary>
        [DataMember(Name="PO_ITM_NO", EmitDefaultValue=false)]
        public string PO_ITM_NO { get; set; }

        /// <summary>
        /// Gets or Sets MATERIAL
        /// </summary>
        [DataMember(Name="MATERIAL", EmitDefaultValue=false)]
        public string MATERIAL { get; set; }

        /// <summary>
        /// Gets or Sets MAT_ENTRD
        /// </summary>
        [DataMember(Name="MAT_ENTRD", EmitDefaultValue=false)]
        public string MAT_ENTRD { get; set; }

        /// <summary>
        /// Gets or Sets SHORT_TEXT
        /// </summary>
        [DataMember(Name="SHORT_TEXT", EmitDefaultValue=false)]
        public string SHORT_TEXT { get; set; }

        /// <summary>
        /// Gets or Sets NET_VALUE
        /// </summary>
        [DataMember(Name="NET_VALUE", EmitDefaultValue=false)]
        public string NET_VALUE { get; set; }

        /// <summary>
        /// Gets or Sets CURRENCY
        /// </summary>
        [DataMember(Name="CURRENCY", EmitDefaultValue=false)]
        public string CURRENCY { get; set; }

        /// <summary>
        /// Gets or Sets SUBTOTAL1
        /// </summary>
        [DataMember(Name="SUBTOTAL1", EmitDefaultValue=false)]
        public double? SUBTOTAL1 { get; set; }

        /// <summary>
        /// Gets or Sets SUBTOTAL2
        /// </summary>
        [DataMember(Name="SUBTOTAL2", EmitDefaultValue=false)]
        public double? SUBTOTAL2 { get; set; }

        /// <summary>
        /// Gets or Sets SUBTOTAL3
        /// </summary>
        [DataMember(Name="SUBTOTAL3", EmitDefaultValue=false)]
        public double? SUBTOTAL3 { get; set; }

        /// <summary>
        /// Gets or Sets SUBTOTAL4
        /// </summary>
        [DataMember(Name="SUBTOTAL4", EmitDefaultValue=false)]
        public double? SUBTOTAL4 { get; set; }

        /// <summary>
        /// Gets or Sets SUBTOTAL5
        /// </summary>
        [DataMember(Name="SUBTOTAL5", EmitDefaultValue=false)]
        public double? SUBTOTAL5 { get; set; }

        /// <summary>
        /// Gets or Sets SUBTOTAL6
        /// </summary>
        [DataMember(Name="SUBTOTAL6", EmitDefaultValue=false)]
        public double? SUBTOTAL6 { get; set; }

        /// <summary>
        /// Gets or Sets TX_DOC_CUR
        /// </summary>
        [DataMember(Name="TX_DOC_CUR", EmitDefaultValue=false)]
        public double? TX_DOC_CUR { get; set; }

        /// <summary>
        /// Gets or Sets NETVALUE1
        /// </summary>
        [DataMember(Name="NET_VALUE1", EmitDefaultValue=false)]
        public double? NETVALUE1 { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SimulateOrderResponseRootORDERITEMSOUT {\n");
            sb.Append("  ITM_NUMBER: ").Append(ITM_NUMBER).Append("\n");
            sb.Append("  PO_ITM_NO: ").Append(PO_ITM_NO).Append("\n");
            sb.Append("  MATERIAL: ").Append(MATERIAL).Append("\n");
            sb.Append("  MAT_ENTRD: ").Append(MAT_ENTRD).Append("\n");
            sb.Append("  SHORT_TEXT: ").Append(SHORT_TEXT).Append("\n");
            sb.Append("  NET_VALUE: ").Append(NET_VALUE).Append("\n");
            sb.Append("  CURRENCY: ").Append(CURRENCY).Append("\n");
            sb.Append("  SUBTOTAL1: ").Append(SUBTOTAL1).Append("\n");
            sb.Append("  SUBTOTAL2: ").Append(SUBTOTAL2).Append("\n");
            sb.Append("  SUBTOTAL3: ").Append(SUBTOTAL3).Append("\n");
            sb.Append("  SUBTOTAL4: ").Append(SUBTOTAL4).Append("\n");
            sb.Append("  SUBTOTAL5: ").Append(SUBTOTAL5).Append("\n");
            sb.Append("  SUBTOTAL6: ").Append(SUBTOTAL6).Append("\n");
            sb.Append("  TX_DOC_CUR: ").Append(TX_DOC_CUR).Append("\n");
            sb.Append("  NETVALUE1: ").Append(NETVALUE1).Append("\n");
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
            return this.Equals(input as SimulateOrderResponseRootORDERITEMSOUT);
        }

        /// <summary>
        /// Returns true if SimulateOrderResponseRootORDERITEMSOUT instances are equal
        /// </summary>
        /// <param name="input">Instance of SimulateOrderResponseRootORDERITEMSOUT to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimulateOrderResponseRootORDERITEMSOUT input)
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
                    this.PO_ITM_NO == input.PO_ITM_NO ||
                    (this.PO_ITM_NO != null &&
                    this.PO_ITM_NO.Equals(input.PO_ITM_NO))
                ) && 
                (
                    this.MATERIAL == input.MATERIAL ||
                    (this.MATERIAL != null &&
                    this.MATERIAL.Equals(input.MATERIAL))
                ) && 
                (
                    this.MAT_ENTRD == input.MAT_ENTRD ||
                    (this.MAT_ENTRD != null &&
                    this.MAT_ENTRD.Equals(input.MAT_ENTRD))
                ) && 
                (
                    this.SHORT_TEXT == input.SHORT_TEXT ||
                    (this.SHORT_TEXT != null &&
                    this.SHORT_TEXT.Equals(input.SHORT_TEXT))
                ) && 
                (
                    this.NET_VALUE == input.NET_VALUE ||
                    (this.NET_VALUE != null &&
                    this.NET_VALUE.Equals(input.NET_VALUE))
                ) && 
                (
                    this.CURRENCY == input.CURRENCY ||
                    (this.CURRENCY != null &&
                    this.CURRENCY.Equals(input.CURRENCY))
                ) && 
                (
                    this.SUBTOTAL1 == input.SUBTOTAL1 ||
                    (this.SUBTOTAL1 != null &&
                    this.SUBTOTAL1.Equals(input.SUBTOTAL1))
                ) && 
                (
                    this.SUBTOTAL2 == input.SUBTOTAL2 ||
                    (this.SUBTOTAL2 != null &&
                    this.SUBTOTAL2.Equals(input.SUBTOTAL2))
                ) && 
                (
                    this.SUBTOTAL3 == input.SUBTOTAL3 ||
                    (this.SUBTOTAL3 != null &&
                    this.SUBTOTAL3.Equals(input.SUBTOTAL3))
                ) && 
                (
                    this.SUBTOTAL4 == input.SUBTOTAL4 ||
                    (this.SUBTOTAL4 != null &&
                    this.SUBTOTAL4.Equals(input.SUBTOTAL4))
                ) && 
                (
                    this.SUBTOTAL5 == input.SUBTOTAL5 ||
                    (this.SUBTOTAL5 != null &&
                    this.SUBTOTAL5.Equals(input.SUBTOTAL5))
                ) && 
                (
                    this.SUBTOTAL6 == input.SUBTOTAL6 ||
                    (this.SUBTOTAL6 != null &&
                    this.SUBTOTAL6.Equals(input.SUBTOTAL6))
                ) && 
                (
                    this.TX_DOC_CUR == input.TX_DOC_CUR ||
                    (this.TX_DOC_CUR != null &&
                    this.TX_DOC_CUR.Equals(input.TX_DOC_CUR))
                ) && 
                (
                    this.NETVALUE1 == input.NETVALUE1 ||
                    (this.NETVALUE1 != null &&
                    this.NETVALUE1.Equals(input.NETVALUE1))
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
                if (this.PO_ITM_NO != null)
                    hashCode = hashCode * 59 + this.PO_ITM_NO.GetHashCode();
                if (this.MATERIAL != null)
                    hashCode = hashCode * 59 + this.MATERIAL.GetHashCode();
                if (this.MAT_ENTRD != null)
                    hashCode = hashCode * 59 + this.MAT_ENTRD.GetHashCode();
                if (this.SHORT_TEXT != null)
                    hashCode = hashCode * 59 + this.SHORT_TEXT.GetHashCode();
                if (this.NET_VALUE != null)
                    hashCode = hashCode * 59 + this.NET_VALUE.GetHashCode();
                if (this.CURRENCY != null)
                    hashCode = hashCode * 59 + this.CURRENCY.GetHashCode();
                if (this.SUBTOTAL1 != null)
                    hashCode = hashCode * 59 + this.SUBTOTAL1.GetHashCode();
                if (this.SUBTOTAL2 != null)
                    hashCode = hashCode * 59 + this.SUBTOTAL2.GetHashCode();
                if (this.SUBTOTAL3 != null)
                    hashCode = hashCode * 59 + this.SUBTOTAL3.GetHashCode();
                if (this.SUBTOTAL4 != null)
                    hashCode = hashCode * 59 + this.SUBTOTAL4.GetHashCode();
                if (this.SUBTOTAL5 != null)
                    hashCode = hashCode * 59 + this.SUBTOTAL5.GetHashCode();
                if (this.SUBTOTAL6 != null)
                    hashCode = hashCode * 59 + this.SUBTOTAL6.GetHashCode();
                if (this.TX_DOC_CUR != null)
                    hashCode = hashCode * 59 + this.TX_DOC_CUR.GetHashCode();
                if (this.NETVALUE1 != null)
                    hashCode = hashCode * 59 + this.NETVALUE1.GetHashCode();
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
