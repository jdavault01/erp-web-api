using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pki.eBusiness.ErpApi.Entities.Settings
{
    public class BackupDbSettings
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string ErpApiLogCollection { get; set; }
        public bool Enabled { get; set; }
    }
}
