using System.Runtime.Serialization;

namespace Pki.eBusiness.WebApi.Entities.Errors
{
    /// <summary>
    /// Process Order Submission Fault
    /// </summary>
    [DataContract]
    public class CustomError
    {
        #region Properties

        [DataMember]
        public string ErrorMessage { get; set; }

        #endregion // Properties
    }
}