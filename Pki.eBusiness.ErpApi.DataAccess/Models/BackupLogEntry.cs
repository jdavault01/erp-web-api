using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Pki.eBusiness.ErpApi.DataAccess.Models
{
    public class BackupLogEntry
    {
        public string Method { get; set; }
        public object Request { get; set; }
        public object Response { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public BackupLogEntry(object request, string method)
        {
            Method = method;
            Request = request;
            Start = DateTime.Now;
        }

        public void AddResponse(object response)
        {
            Response = response;
            End = DateTime.Now;
        }
    }
}
