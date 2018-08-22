using Pki.eBusiness.WebApi.Contracts.BL.Genetics;
using Pki.eBusiness.WebApi.Contracts.DAL;
using Pki.eBusiness.WebApi.Entities.Constants;
using Pki.eBusiness.WebApi.Entities.Extensions;
using Pki.eBusiness.WebApi.Entities.Orders;
using PKI.eBusiness.WMService.Logger;

namespace Pki.eBusiness.WebApi.Business
{
    /// <summary>
    /// Order Service Class
    /// </summary>
    public class OrderService: IOrderService
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;
        private readonly IOrderDAL _orderDAL;


        #region Properties

        public static string CustomerID { get; set; }

        #endregion // Properties

        #region Private variables

        private readonly IWebMethodClient _webMethodClient;

        #endregion // Private variables

        #region Constructors

        /// <summary>
        /// Class Constructor used for dependency injection
        /// </summary>
        /// <param name="webMethodClient"></param>
        public OrderService(IWebMethodClient webMethodClient,IOrderDAL orderDAL)
        {
            _webMethodClient = webMethodClient;
            _orderDAL=orderDAL;
        }

        #endregion // Constructors

        #region Public methods

        /// <summary>
        /// Process Order Submission
        /// </summary>
        /// <param name="order">Order to be processed</param>
        /// <returns></returns>
        public OrderSubmissionResponse ProcessSubmision(Order order)
        {
            // Set CustomerID first:
            CustomerID = order.CustomerID;

            // Map order to Pediatrix object:

            string strResponse= _webMethodClient.ProcessOrderSubmission(order);
            LogResponse(strResponse);
     
            // Convert the xml response to OrderSubmissionResponse object:
        
            OrderSubmissionResponse response = strResponse.ConvertToObject<OrderSubmissionResponse>();

            return response;
            
        }
        /// <summary>
        /// This method will log input request
        /// </summary>
        /// <param name="xml">xml</param>
        private void LogInputRequest(string xml)
        {
            Log(ErrorMessages.SEND_DATA_INPUT_REQUEST);
            Log(xml.Replace("\r\n", ""));
            Log(ErrorMessages.INVOKING_SERVICE);
			
        
        }
        /// <summary>
        /// This method will log response
        /// </summary>
        /// <param name="data">data</param>
        private void LogResponse(string data)
        {
            Log(ErrorMessages.RESPONSE_FROM_SERVICE);
            Log(data);
        }
       /// <summary>
       /// This method will update the order status for a given wm order
       /// </summary>
       /// <param name="orderNumber">ordernumber</param>
        public void UpdateOrderStatus(string orderNumber)
        {
            if(!(string.IsNullOrEmpty(orderNumber)))
            {
                int orderStatus=Constants.PENDING_ORDER_STATUS_KEY.ConfigValue<int>();

                orderNumber = orderNumber.Replace(Constants.LAB_NUMBER_PREPEND_VALUE.ConfigValue<string>(),string.Empty);
                _orderDAL.UpdateOrderStatus(orderNumber, orderStatus);
            }
        }
        /// <summary>
        /// This method will log message to log file
        /// </summary>
        /// <param name="message">message</param>
        public void Log(string message)
        {
            _publisher.PublishMessage(message, System.Diagnostics.TraceLevel.Info, Constants.LOG_AREA);
        }

        #endregion // Public methods
    }
}
