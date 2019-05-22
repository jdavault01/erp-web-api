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
    /// UserCartCountDto
    /// </summary>
    [DataContract]
    public partial class UserCartCountDto :  IEquatable<UserCartCountDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserCartCountDto" /> class.
        /// </summary>
        /// <param name="CartCount">CartCount.</param>
        /// <param name="UserId">UserId.</param>
        public UserCartCountDto(int? CartCount = default(int?), string UserId = default(string))
        {
            this.CartCount = CartCount;
            this.UserId = UserId;
        }
        
        /// <summary>
        /// Gets or Sets CartCount
        /// </summary>
        [DataMember(Name="cartCount", EmitDefaultValue=false)]
        public int? CartCount { get; set; }

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
            sb.Append("class UserCartCountDto {\n");
            sb.Append("  CartCount: ").Append(CartCount).Append("\n");
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
            return this.Equals(input as UserCartCountDto);
        }

        /// <summary>
        /// Returns true if UserCartCountDto instances are equal
        /// </summary>
        /// <param name="input">Instance of UserCartCountDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(UserCartCountDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.CartCount == input.CartCount ||
                    (this.CartCount != null &&
                    this.CartCount.Equals(input.CartCount))
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
                if (this.CartCount != null)
                    hashCode = hashCode * 59 + this.CartCount.GetHashCode();
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
