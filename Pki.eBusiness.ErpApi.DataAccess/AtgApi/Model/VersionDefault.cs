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
    /// VersionDefault
    /// </summary>
    [DataContract]
    public partial class VersionDefault :  IEquatable<VersionDefault>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VersionDefault" /> class.
        /// </summary>
        /// <param name="Catalog">Catalog.</param>
        public VersionDefault(MetadataCatalogDefault Catalog = default(MetadataCatalogDefault))
        {
            this.Catalog = Catalog;
        }
        
        /// <summary>
        /// Gets or Sets Version
        /// </summary>
        [DataMember(Name="version", EmitDefaultValue=false)]
        public string Version { get; private set; }

        /// <summary>
        /// Gets or Sets Lifecycle
        /// </summary>
        [DataMember(Name="lifecycle", EmitDefaultValue=false)]
        public string Lifecycle { get; private set; }

        /// <summary>
        /// Gets or Sets IsLatest
        /// </summary>
        [DataMember(Name="isLatest", EmitDefaultValue=false)]
        public string IsLatest { get; private set; }

        /// <summary>
        /// Gets or Sets TerminationDate
        /// </summary>
        [DataMember(Name="terminationDate", EmitDefaultValue=false)]
        public string TerminationDate { get; private set; }

        /// <summary>
        /// Gets or Sets Catalog
        /// </summary>
        [DataMember(Name="catalog", EmitDefaultValue=false)]
        public MetadataCatalogDefault Catalog { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VersionDefault {\n");
            sb.Append("  Version: ").Append(Version).Append("\n");
            sb.Append("  Lifecycle: ").Append(Lifecycle).Append("\n");
            sb.Append("  IsLatest: ").Append(IsLatest).Append("\n");
            sb.Append("  TerminationDate: ").Append(TerminationDate).Append("\n");
            sb.Append("  Catalog: ").Append(Catalog).Append("\n");
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
            return this.Equals(input as VersionDefault);
        }

        /// <summary>
        /// Returns true if VersionDefault instances are equal
        /// </summary>
        /// <param name="input">Instance of VersionDefault to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VersionDefault input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Version == input.Version ||
                    (this.Version != null &&
                    this.Version.Equals(input.Version))
                ) && 
                (
                    this.Lifecycle == input.Lifecycle ||
                    (this.Lifecycle != null &&
                    this.Lifecycle.Equals(input.Lifecycle))
                ) && 
                (
                    this.IsLatest == input.IsLatest ||
                    (this.IsLatest != null &&
                    this.IsLatest.Equals(input.IsLatest))
                ) && 
                (
                    this.TerminationDate == input.TerminationDate ||
                    (this.TerminationDate != null &&
                    this.TerminationDate.Equals(input.TerminationDate))
                ) && 
                (
                    this.Catalog == input.Catalog ||
                    (this.Catalog != null &&
                    this.Catalog.Equals(input.Catalog))
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
                if (this.Version != null)
                    hashCode = hashCode * 59 + this.Version.GetHashCode();
                if (this.Lifecycle != null)
                    hashCode = hashCode * 59 + this.Lifecycle.GetHashCode();
                if (this.IsLatest != null)
                    hashCode = hashCode * 59 + this.IsLatest.GetHashCode();
                if (this.TerminationDate != null)
                    hashCode = hashCode * 59 + this.TerminationDate.GetHashCode();
                if (this.Catalog != null)
                    hashCode = hashCode * 59 + this.Catalog.GetHashCode();
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
