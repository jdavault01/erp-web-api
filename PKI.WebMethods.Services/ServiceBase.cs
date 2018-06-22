using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKI.eBusiness.WMService.Entities;
using PKI.eBusiness.WMService.BusinessServicesContracts;
using PKI.eBusiness.WMService.Utility;

namespace PKI.eBusiness.WMService.BusinessServices
{
    /// <summary>
    /// Service Base Class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceBase<T> : IServiceBase<T> where T: EntityBase
    {
        #region Public Methods

        GeneralUtil<T> util = new GeneralUtil<T>();
        public T GenerateObject(string XML)
        {
            return util.ConvertToObject(XML);
        }

        #endregion // Public Methods
    }
}
