using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pki.eBusiness.ErpApi.Web.Models
{
    public class ExceptionResponse
    {
        public string ClassName { get; set; }
        public string Message { get; set; }
        public string[] StackTrace { get; set; }

        public ExceptionResponse(Exception e)
        {
            ClassName = e.GetType().Name;
            Message = e.Message;
            StackTrace = Regex.Split(e.StackTrace, "\r\n|\r|\n");
        }
    }
}
