using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace PKI.eBusiness.WMService.Entities
{
    public static class Extensions
    {
        public static DateTime? GetDateTime(this string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                return DateTime.ParseExact(val,"yyyyMMdd",CultureInfo.InvariantCulture);

               
            }
            else
            {
                return (DateTime?)null;

            }


        }
    }
}
