using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pki.eBusiness.ErpApi.Contract.DAL
{
    public interface IBackupRepository
    {
        Task InsertOne<T>(T model);
    }
}
