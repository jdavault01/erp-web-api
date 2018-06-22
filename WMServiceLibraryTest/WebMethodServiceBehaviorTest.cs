using PKI.eBusiness.WMService.WMServiceLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Collections.ObjectModel;
using System.ServiceModel.Channels;
using PKI.eBusiness.WMService.Entities.Errors;
using PKI.eBusiness.WMService.Utility;
using PKI.eBusiness.WMService.TestUtilities;

namespace PKI.eBusiness.WMService.WMServiceLibraryTest
{       
    /// <summary>
    ///This is a test class for WebMethodServiceBehaviorTest and is intended
    ///to contain all WebMethodServiceBehaviorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class WebMethodServiceBehaviorTest
    {

        /// <summary>
        ///A test for HandleError
        ///</summary>
        [TestMethod()]
        public void HandleErrorTest()
        {
            WebMethodServiceBehavior target = new WebMethodServiceBehavior();
            
            Exception error = new Exception(ErrorMessages.GENERIC_ERRORMESSAGE);
            bool expected = true;
            bool actual = target.HandleError(error);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for HandleError
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(Exception), ErrorMessages.ERROR_HANDLER)]
        public void HandleErrorWithExceptionTest()
        {
            WebMethodServiceBehavior target = new WebMethodServiceBehavior();

            Exception error = null;
            bool actual = target.HandleError(error);
            Assert.Fail(ErrorMessages.ERROR_HANDLER);           
        }

        /// <summary>
        ///A test for ProvideFault
        ///</summary>
        [TestMethod()]
        public void ProvideFaultTest()
        {
            WebMethodServiceBehavior target = new WebMethodServiceBehavior();

            // Covering empty methods:
            target.Validate(new ServiceDescription(), new ServiceHost(new object(), new Uri[1] { new Uri("http://localhost:55814/") }));
            target.AddBindingParameters(new ServiceDescription(), new ServiceHost(new object(), new Uri[1] { new Uri("http://localhost:55814/") }), new Collection<ServiceEndpoint>(), new BindingParameterCollection());

            // 
            Exception error = new Exception("Exception of type 'System.Exception' was thrown.");
            MessageVersion version = MessageVersion.Default;
            
            FaultException<CustomError> fe = new FaultException<CustomError>(new CustomError { ErrorMessage = ErrorMessages.GENERIC_ERRORMESSAGE });
            MessageFault messageFault = fe.CreateMessageFault();
            Message fault = Message.CreateMessage(version, messageFault, "http://www.new.perkinelmergenetics.com/IWMService/CustomErrorFault");            
            target.ProvideFault(error, version, ref fault);

            bool expectedFaultProperties = (!fault.IsEmpty) && 
                                            fault.IsFault && 
                                            (fault.State == MessageState.Created) && 
                                            (fault.Version == MessageVersion.Default);
            
            Assert.AreEqual<bool>(expectedFaultProperties, true);
        }

        /// <summary>
        ///A test for ApplyDispatchBehavior
        ///</summary>
        [TestMethod()]
        public void ApplyDispatchBehaviorTest()
        {   
            WebMethodServiceBehavior target = new WebMethodServiceBehavior();

            target.Validate(new ServiceDescription(), new ServiceHost(new object(), new Uri[1] { new Uri("http://localhost/") }));
            target.AddBindingParameters(new ServiceDescription(), new ServiceHost(new object(), new Uri[1] { new Uri("http://localhost/") }), new Collection<ServiceEndpoint>(), new BindingParameterCollection());

            ServiceHost serviceHost = new ServiceHost(new object(), new Uri[1] { new Uri("http://localhost:55814/") });
            serviceHost.ChannelDispatchers.Add(new ChannelDispatcher(new ChannelListener()));
            target.ApplyDispatchBehavior(new ServiceDescription(), serviceHost );

            int expectedChannelDispatchersCount = 1;
            int actualChannelDispatcherCount = serviceHost.ChannelDispatchers.Count;

            Assert.AreEqual<int>(expectedChannelDispatchersCount, actualChannelDispatcherCount);
        }

        /// <summary>
        ///A test for ProvideFault
        ///</summary>
        [TestMethod()]
        public void ProvideFaultWithFaultTest()
        {
            WebMethodServiceBehavior target = new WebMethodServiceBehavior();

            Exception error = new FaultException<CustomError>( new CustomError() { ErrorMessage = ErrorMessages.GENERIC_ERRORMESSAGE } );
            MessageVersion version = MessageVersion.Default;

            FaultException<CustomError> fe = new FaultException<CustomError>(new CustomError { ErrorMessage = ErrorMessages.GENERIC_ERRORMESSAGE });
            MessageFault messageFault = fe.CreateMessageFault();
            Message fault = Message.CreateMessage(version, messageFault, "http://www.new.perkinelmergenetics.com/IWMService/CustomErrorFault");
            target.ProvideFault(error, version, ref fault);

            bool expectedFaultProperties = (!fault.IsEmpty) && fault.IsFault && (fault.State == MessageState.Created) && (fault.Version == MessageVersion.Default);

            Assert.AreEqual<bool>(expectedFaultProperties, true);
        }
    }
}
