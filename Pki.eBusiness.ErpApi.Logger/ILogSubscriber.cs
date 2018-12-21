using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Pki.eBusiness.ErpApi.Logger
{
    /// <summary>
    /// Subscriber for the Pub/Sub pattern of logging
    /// </summary>
    public interface ILogSubscriber
    {
        bool Log(Exception exception, string userId, List<Exception> nestedExceptions);
        bool Log(string message,TraceLevel level,string area);
		
    }
}
