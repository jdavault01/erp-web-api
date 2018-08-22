using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace PKI.eBusiness.WMService.Logger
{
    public class PublisherManager : IPublisher
    {

        #region Private
        
        private static PublisherManager _instance = new PublisherManager();
        private const string LOG_SUBSCRIBERS = "LogSubscribers";
        private const string INSTANCE = "Instance";
        #endregion

        #region Public

        public List<ILogSubscriber> Subscribers { get; private set; }

        #endregion

        #region Constructors

        // No lazy initialization - has to be active on start
        public static PublisherManager Instance {
            get { return _instance; }
        }

        /// <summary>
        /// Private constructor for Singleton pattern
        /// </summary>
        private PublisherManager()
        {
            // Initialize subscribers list
            Subscribers = new List<ILogSubscriber>();
            // Read the configuration parameter for semicolon separated classes of subscribers
            string subs = ConfigurationManager.AppSettings[LOG_SUBSCRIBERS];
            string[] subsArray = string.IsNullOrEmpty(subs) ? new string[0] : subs.Split(';');
            foreach (var s in subsArray)
            {
                Type subscriberType = Type.GetType(s);
                // Check if type isn't already included
                if (subscriberType != null && Subscribers.All(c => c.GetType() != subscriberType))
                {
                    PropertyInfo getInstance = subscriberType.GetProperty(INSTANCE);
                    // Get singleton instance or create a new instance of subscriber type
                    object subscriberInstance = getInstance == null ? Activator.CreateInstance(subscriberType) : getInstance.GetValue(null, null);
                    Subscribers.Add((ILogSubscriber)subscriberInstance);
                }
            }
        }

        #endregion

        #region IPublish Members

        /// <summary>
        /// Publish an exception message to all subscribers
        /// </summary>
        /// <param name="exception">Exception to be published</param>
        /// <param name="userId">User Id associated</param>
        /// <param name="nestedExceptions">Nested exceptions hashtable</param>
        public void PublishException(Exception exception, string userId, List<Exception> nestedExceptions)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Log(exception, userId, nestedExceptions);
            }
        }

        /// <summary>
        /// Publish a message to all subscribers
        /// </summary>
        /// <param name="message">Message to be published</param>
        /// <param name="level">TraceLevel of the message</param>
        /// <param name="area">Area of log to be saved to</param>
        public void PublishMessage(string message, TraceLevel level, string area)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Log(message, level, area);
            }
        }

        /// <summary>
        /// Add a subscriber to the list of subscribers
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns>True if added successfully or false otherwise</returns>
        public bool AddSubscriber(ILogSubscriber subscriber)
        {
            // Add subscriber only if it doesn't exist
            Type subType = subscriber.GetType();
            if (Subscribers.All(c => c.GetType() != subType))
            {
                Subscribers.Add(subscriber);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove existing subscriber from the subscriber list
        /// </summary>
        /// <param name="subscriber"></param>
        /// <returns>True if removed successfully or false otherwise</returns>
        public bool RemoveSubscriber(ILogSubscriber subscriber)
        {
            return Subscribers.Remove(subscriber);
        }

        #endregion

    }
}
