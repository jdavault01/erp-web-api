using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using PKI.eBusiness.WMService.Utility;
using PKI.eBusiness.WMService.Entities.Errors;
using PKI.eBusiness.WMService.Logger;
using PKI.eBusiness.WMService.BusinessServices;

namespace PKI.eBusiness.WMService.WMServiceLibrary
{
    /// <summary>
    /// This class helps us to have control on the fault error message returned to client and also allows us to have custom logging when ever an exception is raised
    /// </summary>
    public class WebMethodServiceBehavior : Attribute, IErrorHandler, IServiceBehavior
    {
        private readonly IPublisher _publisher = PublisherManager.Instance;

        #region IErrorHandler Members

        /// <summary>
        /// This will handle error, can be used to log error in the file/event viewer
        /// </summary>
        /// <param name="error">error</param>
        /// <returns>true if error is handled</returns>
        public bool HandleError(Exception error)
        {
            try
            {
                LogException(error);
            }
            catch (Exception e)
            {
                throw new Exception(ErrorMessages.ERROR_HANDLER);
            }
            // Let the other ErrorHandler do their jobs
            return true;
        }


        /// <summary>
        /// This method logs exception
        /// </summary>
        /// <param name="exception">exception</param>
        public void LogException(Exception exception)
        {
            string userId = OrderService.CustomerID;
            List<Exception> nestedExceptions = new List<Exception>();
            nestedExceptions.Add(exception.InnerException);
            _publisher.PublishException(exception, userId, nestedExceptions);
        }

        /// <summary>
        /// This will convert exception to fault exception with a generic message
        /// </summary>
        /// <param name="error">error</param>
        /// <param name="version">version</param>
        /// <param name="fault">fault</param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            if (error is FaultException)
                return;

            FaultException<CustomError> fe = new FaultException<CustomError>(new CustomError { ErrorMessage = ErrorMessages.GENERIC_ERRORMESSAGE });
            MessageFault messageFault = fe.CreateMessageFault();
            fault = Message.CreateMessage(version, messageFault, "http://www.new.perkinelmergenetics.com/IWMService/CustomErrorFault");
        }

        #endregion // IErrorHandler Members

        #region IServiceBehavior Members

        /// <summary>
        /// Do nothing here
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        /// <param name="endpoints"></param>
        /// <param name="bindingParameters"></param>
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
            return;
        }

        /// <summary>
        ///  This is used to add the error handler to channel dispatcher
        /// </summary>
        /// <param name="serviceDescription">service description</param>
        /// <param name="serviceHostBase">service host base</param>
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            // Adds a TimeServiceErrorHandler to each ChannelDispatcher
            foreach (var channelDispatcherBase in serviceHostBase.ChannelDispatchers)
            {
                var channelDispatcher = channelDispatcherBase as ChannelDispatcher;
                channelDispatcher.ErrorHandlers.Add(this);
            }
        }

        /// <summary>
        /// Do nothing here
        /// </summary>
        /// <param name="serviceDescription"></param>
        /// <param name="serviceHostBase"></param>
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            return;
        }

        #endregion // IServiceBehavior Members
    }
}
