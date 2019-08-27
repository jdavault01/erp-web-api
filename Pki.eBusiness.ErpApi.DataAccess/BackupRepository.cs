using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Pki.eBusiness.ErpApi.Contract.DAL;
using Pki.eBusiness.ErpApi.Entities.Settings;

namespace Pki.eBusiness.ErpApi.DataAccess
{
    public class BackupRepository : IBackupRepository
    {
        private readonly BackupDbSettings _settings;
        private readonly IMongoClient _client;
        private readonly ILogger<BackupRepository> _logger;
        private IMongoDatabase _database;

        public BackupRepository(BackupDbSettings settings, ILogger<BackupRepository> logger)
        {
            _settings = settings;
            if (_settings.Enabled)
            {
                _client = new MongoClient(_settings.ConnectionString);
                _database = _client.GetDatabase(_settings.Database);
            }
            _logger = logger;
        }

        public Task InsertOne<T>(T model)
        {
            if (_database != null)
                try
                {
                    var collection = _database.GetCollection<T>(_settings.ErpApiLogCollection);
                    return collection.InsertOneAsync(model);
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Error during insert to DB");
                }

            return null;
        }
    }
}
