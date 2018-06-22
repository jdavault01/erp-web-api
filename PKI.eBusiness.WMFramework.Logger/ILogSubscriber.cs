using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Diagnostics;

namespace PKI.eBusiness.WMService.Logger
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
