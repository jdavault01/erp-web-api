using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pki.eBusiness.ErpApi.Logger
{
    /// <summary>
    /// Publisher part of the Pub/Sub pattern
    /// </summary>
    public interface IPublisher
    {
        void PublishException(Exception exception, string userId, List<Exception> nestedExceptions);
        void PublishMessage(string message, TraceLevel level, string area);
        bool AddSubscriber(ILogSubscriber subscriber);
        bool RemoveSubscriber(ILogSubscriber subscriber);
    }
}
