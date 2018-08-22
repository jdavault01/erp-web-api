using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PKI.eBusiness.WMService.Logger
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
