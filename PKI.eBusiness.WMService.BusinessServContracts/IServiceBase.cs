using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKI.eBusiness.WMService.BusinessServicesContracts
{
    /// <summary>
    /// Service Base Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IServiceBase<T>
    {
        T GenerateObject(string XML);
    }
}
