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
    /// OrderDto
    /// </summary>
    [DataContract]
    public partial class OrderDto :  IEquatable<OrderDto>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDto" /> class.
        /// </summary>
        /// <param name="ERPOrderNumber">ERPOrderNumber.</param>
        /// <param name="Count">Count.</param>
        /// <param name="CustomerEmail">CustomerEmail.</param>
        /// <param name="DateOrdered">DateOrdered.</param>
        /// <param name="Discontinued">Discontinued.</param>
        /// <param name="Fax">Fax.</param>
        /// <param name="FirstName">FirstName.</param>
        /// <param name="GrandTotal">GrandTotal.</param>
        /// <param name="IsInventoryNotPresent">IsInventoryNotPresent.</param>
        /// <param name="IsRad">IsRad.</param>
        /// <param name="IsSapDown">IsSapDown.</param>
        /// <param name="LastName">LastName.</param>
        /// <param name="LoginId">LoginId.</param>
        /// <param name="OrderId">OrderId.</param>
        /// <param name="OrderTotal">OrderTotal.</param>
        /// <param name="Phone">Phone.</param>
        /// <param name="QuoteNumber">QuoteNumber.</param>
        /// <param name="RemoveReplacement">RemoveReplacement.</param>
        /// <param name="Replacement">Replacement.</param>
        /// <param name="Salutation">Salutation.</param>
        /// <param name="State">State.</param>
        /// <param name="Status">Status.</param>
        /// <param name="SubmittedDate">SubmittedDate.</param>
        /// <param name="SubmittedUserEmail">SubmittedUserEmail.</param>
        /// <param name="SubmittedUserId">SubmittedUserId.</param>
        /// <param name="VatExempted">VatExempted.</param>
        /// <param name="WebOrderNumber">WebOrderNumber.</param>
        /// <param name="OrderSummary">OrderSummary.</param>
        /// <param name="ShippingGroup">ShippingGroup.</param>
        /// <param name="PurchaseOrderPayment">PurchaseOrderPayment.</param>
        /// <param name="CreditCardPayment">CreditCardPayment.</param>
        /// <param name="AdditionalEmailNotifications">AdditionalEmailNotifications.</param>
        /// <param name="TierApproverDetails">TierApproverDetails.</param>
        /// <param name="LineItems">LineItems.</param>
        public OrderDto(string ERPOrderNumber = default(string), int? Count = default(int?), string CustomerEmail = default(string), DateTime? DateOrdered = default(DateTime?), bool? Discontinued = default(bool?), string Fax = default(string), string FirstName = default(string), double? GrandTotal = default(double?), bool? IsInventoryNotPresent = default(bool?), bool? IsRad = default(bool?), bool? IsSapDown = default(bool?), string LastName = default(string), string LoginId = default(string), string OrderId = default(string), long? OrderTotal = default(long?), string Phone = default(string), string QuoteNumber = default(string), bool? RemoveReplacement = default(bool?), bool? Replacement = default(bool?), string Salutation = default(string), string State = default(string), string Status = default(string), DateTime? SubmittedDate = default(DateTime?), string SubmittedUserEmail = default(string), string SubmittedUserId = default(string), bool? VatExempted = default(bool?), string WebOrderNumber = default(string), OrderPriceDto OrderSummary = default(OrderPriceDto), ShippingGroupDto ShippingGroup = default(ShippingGroupDto), PurchaseOrderPaymentDto PurchaseOrderPayment = default(PurchaseOrderPaymentDto), CreditCardPaymentDto CreditCardPayment = default(CreditCardPaymentDto), AdditionalEmailAddressDto AdditionalEmailNotifications = default(AdditionalEmailAddressDto), List<TierApproverDetailsDto> TierApproverDetails = default(List<TierApproverDetailsDto>), List<CommerceItemDto> LineItems = default(List<CommerceItemDto>))
        {
            this.ERPOrderNumber = ERPOrderNumber;
            this.Count = Count;
            this.CustomerEmail = CustomerEmail;
            this.DateOrdered = DateOrdered;
            this.Discontinued = Discontinued;
            this.Fax = Fax;
            this.FirstName = FirstName;
            this.GrandTotal = GrandTotal;
            this.IsInventoryNotPresent = IsInventoryNotPresent;
            this.IsRad = IsRad;
            this.IsSapDown = IsSapDown;
            this.LastName = LastName;
            this.LoginId = LoginId;
            this.OrderId = OrderId;
            this.OrderTotal = OrderTotal;
            this.Phone = Phone;
            this.QuoteNumber = QuoteNumber;
            this.RemoveReplacement = RemoveReplacement;
            this.Replacement = Replacement;
            this.Salutation = Salutation;
            this.State = State;
            this.Status = Status;
            this.SubmittedDate = SubmittedDate;
            this.SubmittedUserEmail = SubmittedUserEmail;
            this.SubmittedUserId = SubmittedUserId;
            this.VatExempted = VatExempted;
            this.WebOrderNumber = WebOrderNumber;
            this.OrderSummary = OrderSummary;
            this.ShippingGroup = ShippingGroup;
            this.PurchaseOrderPayment = PurchaseOrderPayment;
            this.CreditCardPayment = CreditCardPayment;
            this.AdditionalEmailNotifications = AdditionalEmailNotifications;
            this.TierApproverDetails = TierApproverDetails;
            this.LineItems = LineItems;
        }
        
        /// <summary>
        /// Gets or Sets ERPOrderNumber
        /// </summary>
        [DataMember(Name="ERPOrderNumber", EmitDefaultValue=false)]
        public string ERPOrderNumber { get; set; }

        /// <summary>
        /// Gets or Sets Count
        /// </summary>
        [DataMember(Name="count", EmitDefaultValue=false)]
        public int? Count { get; set; }

        /// <summary>
        /// Gets or Sets CustomerEmail
        /// </summary>
        [DataMember(Name="customerEmail", EmitDefaultValue=false)]
        public string CustomerEmail { get; set; }

        /// <summary>
        /// Gets or Sets DateOrdered
        /// </summary>
        [DataMember(Name="dateOrdered", EmitDefaultValue=false)]
        public DateTime? DateOrdered { get; set; }

        /// <summary>
        /// Gets or Sets Discontinued
        /// </summary>
        [DataMember(Name="discontinued", EmitDefaultValue=false)]
        public bool? Discontinued { get; set; }

        /// <summary>
        /// Gets or Sets Fax
        /// </summary>
        [DataMember(Name="fax", EmitDefaultValue=false)]
        public string Fax { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name="firstName", EmitDefaultValue=false)]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or Sets GrandTotal
        /// </summary>
        [DataMember(Name="grandTotal", EmitDefaultValue=false)]
        public double? GrandTotal { get; set; }

        /// <summary>
        /// Gets or Sets IsInventoryNotPresent
        /// </summary>
        [DataMember(Name="isInventoryNotPresent", EmitDefaultValue=false)]
        public bool? IsInventoryNotPresent { get; set; }

        /// <summary>
        /// Gets or Sets IsRad
        /// </summary>
        [DataMember(Name="isRad", EmitDefaultValue=false)]
        public bool? IsRad { get; set; }

        /// <summary>
        /// Gets or Sets IsSapDown
        /// </summary>
        [DataMember(Name="isSapDown", EmitDefaultValue=false)]
        public bool? IsSapDown { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name="lastName", EmitDefaultValue=false)]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or Sets LoginId
        /// </summary>
        [DataMember(Name="loginId", EmitDefaultValue=false)]
        public string LoginId { get; set; }

        /// <summary>
        /// Gets or Sets OrderId
        /// </summary>
        [DataMember(Name="orderId", EmitDefaultValue=false)]
        public string OrderId { get; set; }

        /// <summary>
        /// Gets or Sets OrderTotal
        /// </summary>
        [DataMember(Name="orderTotal", EmitDefaultValue=false)]
        public long? OrderTotal { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue=false)]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or Sets QuoteNumber
        /// </summary>
        [DataMember(Name="quoteNumber", EmitDefaultValue=false)]
        public string QuoteNumber { get; set; }

        /// <summary>
        /// Gets or Sets RemoveReplacement
        /// </summary>
        [DataMember(Name="removeReplacement", EmitDefaultValue=false)]
        public bool? RemoveReplacement { get; set; }

        /// <summary>
        /// Gets or Sets Replacement
        /// </summary>
        [DataMember(Name="replacement", EmitDefaultValue=false)]
        public bool? Replacement { get; set; }

        /// <summary>
        /// Gets or Sets Salutation
        /// </summary>
        [DataMember(Name="salutation", EmitDefaultValue=false)]
        public string Salutation { get; set; }

        /// <summary>
        /// Gets or Sets State
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue=false)]
        public string State { get; set; }

        /// <summary>
        /// Gets or Sets Status
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue=false)]
        public string Status { get; set; }

        /// <summary>
        /// Gets or Sets SubmittedDate
        /// </summary>
        [DataMember(Name="submittedDate", EmitDefaultValue=false)]
        public DateTime? SubmittedDate { get; set; }

        /// <summary>
        /// Gets or Sets SubmittedUserEmail
        /// </summary>
        [DataMember(Name="submittedUserEmail", EmitDefaultValue=false)]
        public string SubmittedUserEmail { get; set; }

        /// <summary>
        /// Gets or Sets SubmittedUserId
        /// </summary>
        [DataMember(Name="submittedUserId", EmitDefaultValue=false)]
        public string SubmittedUserId { get; set; }

        /// <summary>
        /// Gets or Sets VatExempted
        /// </summary>
        [DataMember(Name="vatExempted", EmitDefaultValue=false)]
        public bool? VatExempted { get; set; }

        /// <summary>
        /// Gets or Sets WebOrderNumber
        /// </summary>
        [DataMember(Name="webOrderNumber", EmitDefaultValue=false)]
        public string WebOrderNumber { get; set; }

        /// <summary>
        /// Gets or Sets OrderSummary
        /// </summary>
        [DataMember(Name="orderSummary", EmitDefaultValue=false)]
        public OrderPriceDto OrderSummary { get; set; }

        /// <summary>
        /// Gets or Sets ShippingGroup
        /// </summary>
        [DataMember(Name="shippingGroup", EmitDefaultValue=false)]
        public ShippingGroupDto ShippingGroup { get; set; }

        /// <summary>
        /// Gets or Sets PurchaseOrderPayment
        /// </summary>
        [DataMember(Name="purchaseOrderPayment", EmitDefaultValue=false)]
        public PurchaseOrderPaymentDto PurchaseOrderPayment { get; set; }

        /// <summary>
        /// Gets or Sets CreditCardPayment
        /// </summary>
        [DataMember(Name="creditCardPayment", EmitDefaultValue=false)]
        public CreditCardPaymentDto CreditCardPayment { get; set; }

        /// <summary>
        /// Gets or Sets AdditionalEmailNotifications
        /// </summary>
        [DataMember(Name="additionalEmailNotifications", EmitDefaultValue=false)]
        public AdditionalEmailAddressDto AdditionalEmailNotifications { get; set; }

        /// <summary>
        /// Gets or Sets TierApproverDetails
        /// </summary>
        [DataMember(Name="tierApproverDetails", EmitDefaultValue=false)]
        public List<TierApproverDetailsDto> TierApproverDetails { get; set; }

        /// <summary>
        /// Gets or Sets LineItems
        /// </summary>
        [DataMember(Name="lineItems", EmitDefaultValue=false)]
        public List<CommerceItemDto> LineItems { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OrderDto {\n");
            sb.Append("  ERPOrderNumber: ").Append(ERPOrderNumber).Append("\n");
            sb.Append("  Count: ").Append(Count).Append("\n");
            sb.Append("  CustomerEmail: ").Append(CustomerEmail).Append("\n");
            sb.Append("  DateOrdered: ").Append(DateOrdered).Append("\n");
            sb.Append("  Discontinued: ").Append(Discontinued).Append("\n");
            sb.Append("  Fax: ").Append(Fax).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  GrandTotal: ").Append(GrandTotal).Append("\n");
            sb.Append("  IsInventoryNotPresent: ").Append(IsInventoryNotPresent).Append("\n");
            sb.Append("  IsRad: ").Append(IsRad).Append("\n");
            sb.Append("  IsSapDown: ").Append(IsSapDown).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  LoginId: ").Append(LoginId).Append("\n");
            sb.Append("  OrderId: ").Append(OrderId).Append("\n");
            sb.Append("  OrderTotal: ").Append(OrderTotal).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  QuoteNumber: ").Append(QuoteNumber).Append("\n");
            sb.Append("  RemoveReplacement: ").Append(RemoveReplacement).Append("\n");
            sb.Append("  Replacement: ").Append(Replacement).Append("\n");
            sb.Append("  Salutation: ").Append(Salutation).Append("\n");
            sb.Append("  State: ").Append(State).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  SubmittedDate: ").Append(SubmittedDate).Append("\n");
            sb.Append("  SubmittedUserEmail: ").Append(SubmittedUserEmail).Append("\n");
            sb.Append("  SubmittedUserId: ").Append(SubmittedUserId).Append("\n");
            sb.Append("  VatExempted: ").Append(VatExempted).Append("\n");
            sb.Append("  WebOrderNumber: ").Append(WebOrderNumber).Append("\n");
            sb.Append("  OrderSummary: ").Append(OrderSummary).Append("\n");
            sb.Append("  ShippingGroup: ").Append(ShippingGroup).Append("\n");
            sb.Append("  PurchaseOrderPayment: ").Append(PurchaseOrderPayment).Append("\n");
            sb.Append("  CreditCardPayment: ").Append(CreditCardPayment).Append("\n");
            sb.Append("  AdditionalEmailNotifications: ").Append(AdditionalEmailNotifications).Append("\n");
            sb.Append("  TierApproverDetails: ").Append(TierApproverDetails).Append("\n");
            sb.Append("  LineItems: ").Append(LineItems).Append("\n");
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
            return this.Equals(input as OrderDto);
        }

        /// <summary>
        /// Returns true if OrderDto instances are equal
        /// </summary>
        /// <param name="input">Instance of OrderDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OrderDto input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.ERPOrderNumber == input.ERPOrderNumber ||
                    (this.ERPOrderNumber != null &&
                    this.ERPOrderNumber.Equals(input.ERPOrderNumber))
                ) && 
                (
                    this.Count == input.Count ||
                    (this.Count != null &&
                    this.Count.Equals(input.Count))
                ) && 
                (
                    this.CustomerEmail == input.CustomerEmail ||
                    (this.CustomerEmail != null &&
                    this.CustomerEmail.Equals(input.CustomerEmail))
                ) && 
                (
                    this.DateOrdered == input.DateOrdered ||
                    (this.DateOrdered != null &&
                    this.DateOrdered.Equals(input.DateOrdered))
                ) && 
                (
                    this.Discontinued == input.Discontinued ||
                    (this.Discontinued != null &&
                    this.Discontinued.Equals(input.Discontinued))
                ) && 
                (
                    this.Fax == input.Fax ||
                    (this.Fax != null &&
                    this.Fax.Equals(input.Fax))
                ) && 
                (
                    this.FirstName == input.FirstName ||
                    (this.FirstName != null &&
                    this.FirstName.Equals(input.FirstName))
                ) && 
                (
                    this.GrandTotal == input.GrandTotal ||
                    (this.GrandTotal != null &&
                    this.GrandTotal.Equals(input.GrandTotal))
                ) && 
                (
                    this.IsInventoryNotPresent == input.IsInventoryNotPresent ||
                    (this.IsInventoryNotPresent != null &&
                    this.IsInventoryNotPresent.Equals(input.IsInventoryNotPresent))
                ) && 
                (
                    this.IsRad == input.IsRad ||
                    (this.IsRad != null &&
                    this.IsRad.Equals(input.IsRad))
                ) && 
                (
                    this.IsSapDown == input.IsSapDown ||
                    (this.IsSapDown != null &&
                    this.IsSapDown.Equals(input.IsSapDown))
                ) && 
                (
                    this.LastName == input.LastName ||
                    (this.LastName != null &&
                    this.LastName.Equals(input.LastName))
                ) && 
                (
                    this.LoginId == input.LoginId ||
                    (this.LoginId != null &&
                    this.LoginId.Equals(input.LoginId))
                ) && 
                (
                    this.OrderId == input.OrderId ||
                    (this.OrderId != null &&
                    this.OrderId.Equals(input.OrderId))
                ) && 
                (
                    this.OrderTotal == input.OrderTotal ||
                    (this.OrderTotal != null &&
                    this.OrderTotal.Equals(input.OrderTotal))
                ) && 
                (
                    this.Phone == input.Phone ||
                    (this.Phone != null &&
                    this.Phone.Equals(input.Phone))
                ) && 
                (
                    this.QuoteNumber == input.QuoteNumber ||
                    (this.QuoteNumber != null &&
                    this.QuoteNumber.Equals(input.QuoteNumber))
                ) && 
                (
                    this.RemoveReplacement == input.RemoveReplacement ||
                    (this.RemoveReplacement != null &&
                    this.RemoveReplacement.Equals(input.RemoveReplacement))
                ) && 
                (
                    this.Replacement == input.Replacement ||
                    (this.Replacement != null &&
                    this.Replacement.Equals(input.Replacement))
                ) && 
                (
                    this.Salutation == input.Salutation ||
                    (this.Salutation != null &&
                    this.Salutation.Equals(input.Salutation))
                ) && 
                (
                    this.State == input.State ||
                    (this.State != null &&
                    this.State.Equals(input.State))
                ) && 
                (
                    this.Status == input.Status ||
                    (this.Status != null &&
                    this.Status.Equals(input.Status))
                ) && 
                (
                    this.SubmittedDate == input.SubmittedDate ||
                    (this.SubmittedDate != null &&
                    this.SubmittedDate.Equals(input.SubmittedDate))
                ) && 
                (
                    this.SubmittedUserEmail == input.SubmittedUserEmail ||
                    (this.SubmittedUserEmail != null &&
                    this.SubmittedUserEmail.Equals(input.SubmittedUserEmail))
                ) && 
                (
                    this.SubmittedUserId == input.SubmittedUserId ||
                    (this.SubmittedUserId != null &&
                    this.SubmittedUserId.Equals(input.SubmittedUserId))
                ) && 
                (
                    this.VatExempted == input.VatExempted ||
                    (this.VatExempted != null &&
                    this.VatExempted.Equals(input.VatExempted))
                ) && 
                (
                    this.WebOrderNumber == input.WebOrderNumber ||
                    (this.WebOrderNumber != null &&
                    this.WebOrderNumber.Equals(input.WebOrderNumber))
                ) && 
                (
                    this.OrderSummary == input.OrderSummary ||
                    (this.OrderSummary != null &&
                    this.OrderSummary.Equals(input.OrderSummary))
                ) && 
                (
                    this.ShippingGroup == input.ShippingGroup ||
                    (this.ShippingGroup != null &&
                    this.ShippingGroup.Equals(input.ShippingGroup))
                ) && 
                (
                    this.PurchaseOrderPayment == input.PurchaseOrderPayment ||
                    (this.PurchaseOrderPayment != null &&
                    this.PurchaseOrderPayment.Equals(input.PurchaseOrderPayment))
                ) && 
                (
                    this.CreditCardPayment == input.CreditCardPayment ||
                    (this.CreditCardPayment != null &&
                    this.CreditCardPayment.Equals(input.CreditCardPayment))
                ) && 
                (
                    this.AdditionalEmailNotifications == input.AdditionalEmailNotifications ||
                    (this.AdditionalEmailNotifications != null &&
                    this.AdditionalEmailNotifications.Equals(input.AdditionalEmailNotifications))
                ) && 
                (
                    this.TierApproverDetails == input.TierApproverDetails ||
                    this.TierApproverDetails != null &&
                    this.TierApproverDetails.SequenceEqual(input.TierApproverDetails)
                ) && 
                (
                    this.LineItems == input.LineItems ||
                    this.LineItems != null &&
                    this.LineItems.SequenceEqual(input.LineItems)
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
                if (this.ERPOrderNumber != null)
                    hashCode = hashCode * 59 + this.ERPOrderNumber.GetHashCode();
                if (this.Count != null)
                    hashCode = hashCode * 59 + this.Count.GetHashCode();
                if (this.CustomerEmail != null)
                    hashCode = hashCode * 59 + this.CustomerEmail.GetHashCode();
                if (this.DateOrdered != null)
                    hashCode = hashCode * 59 + this.DateOrdered.GetHashCode();
                if (this.Discontinued != null)
                    hashCode = hashCode * 59 + this.Discontinued.GetHashCode();
                if (this.Fax != null)
                    hashCode = hashCode * 59 + this.Fax.GetHashCode();
                if (this.FirstName != null)
                    hashCode = hashCode * 59 + this.FirstName.GetHashCode();
                if (this.GrandTotal != null)
                    hashCode = hashCode * 59 + this.GrandTotal.GetHashCode();
                if (this.IsInventoryNotPresent != null)
                    hashCode = hashCode * 59 + this.IsInventoryNotPresent.GetHashCode();
                if (this.IsRad != null)
                    hashCode = hashCode * 59 + this.IsRad.GetHashCode();
                if (this.IsSapDown != null)
                    hashCode = hashCode * 59 + this.IsSapDown.GetHashCode();
                if (this.LastName != null)
                    hashCode = hashCode * 59 + this.LastName.GetHashCode();
                if (this.LoginId != null)
                    hashCode = hashCode * 59 + this.LoginId.GetHashCode();
                if (this.OrderId != null)
                    hashCode = hashCode * 59 + this.OrderId.GetHashCode();
                if (this.OrderTotal != null)
                    hashCode = hashCode * 59 + this.OrderTotal.GetHashCode();
                if (this.Phone != null)
                    hashCode = hashCode * 59 + this.Phone.GetHashCode();
                if (this.QuoteNumber != null)
                    hashCode = hashCode * 59 + this.QuoteNumber.GetHashCode();
                if (this.RemoveReplacement != null)
                    hashCode = hashCode * 59 + this.RemoveReplacement.GetHashCode();
                if (this.Replacement != null)
                    hashCode = hashCode * 59 + this.Replacement.GetHashCode();
                if (this.Salutation != null)
                    hashCode = hashCode * 59 + this.Salutation.GetHashCode();
                if (this.State != null)
                    hashCode = hashCode * 59 + this.State.GetHashCode();
                if (this.Status != null)
                    hashCode = hashCode * 59 + this.Status.GetHashCode();
                if (this.SubmittedDate != null)
                    hashCode = hashCode * 59 + this.SubmittedDate.GetHashCode();
                if (this.SubmittedUserEmail != null)
                    hashCode = hashCode * 59 + this.SubmittedUserEmail.GetHashCode();
                if (this.SubmittedUserId != null)
                    hashCode = hashCode * 59 + this.SubmittedUserId.GetHashCode();
                if (this.VatExempted != null)
                    hashCode = hashCode * 59 + this.VatExempted.GetHashCode();
                if (this.WebOrderNumber != null)
                    hashCode = hashCode * 59 + this.WebOrderNumber.GetHashCode();
                if (this.OrderSummary != null)
                    hashCode = hashCode * 59 + this.OrderSummary.GetHashCode();
                if (this.ShippingGroup != null)
                    hashCode = hashCode * 59 + this.ShippingGroup.GetHashCode();
                if (this.PurchaseOrderPayment != null)
                    hashCode = hashCode * 59 + this.PurchaseOrderPayment.GetHashCode();
                if (this.CreditCardPayment != null)
                    hashCode = hashCode * 59 + this.CreditCardPayment.GetHashCode();
                if (this.AdditionalEmailNotifications != null)
                    hashCode = hashCode * 59 + this.AdditionalEmailNotifications.GetHashCode();
                if (this.TierApproverDetails != null)
                    hashCode = hashCode * 59 + this.TierApproverDetails.GetHashCode();
                if (this.LineItems != null)
                    hashCode = hashCode * 59 + this.LineItems.GetHashCode();
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