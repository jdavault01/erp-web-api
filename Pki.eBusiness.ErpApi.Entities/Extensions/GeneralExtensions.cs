using System;
using System.Globalization;

namespace Pki.eBusiness.ErpApi.Entities.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetString(this DateTime val)
        {
            return (val != DateTime.MinValue) && (val != new DateTime(1900, 1, 1)) ? val.ToString("yyyy-MM-dd") : String.Empty;

        }
        public static string GetString(this DateTime? val)
        {
            return (val != DateTime.MinValue) && (val != new DateTime(1900, 1, 1)) ? val.ToString() : String.Empty;

        }

        public static DateTime? GetDateTime(this string val)
        {
            if (!string.IsNullOrEmpty(val))
            {
                //var date = DateTime.ParseExact(val, "yyyyMMdd", CultureInfo.InvariantCulture);
               // var date = DateTime.Parse(val, CultureInfo.InvariantCulture);
                var date=DateTime.ParseExact(val, "yyyyMMdd", CultureInfo.InvariantCulture);
                return (DateTime?)date.Date;
            }
            else
            {
                return (DateTime?) null;

            }
             

        }
    }
}
