using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Context.Mongo
{
    public class VoluntarioMongoDbContext : IBaseVoluntarioDbContext<IMongoDatabase, IMongoCollection<IVoluntario>>
    {

        private string _server;
        private int _port;
        private string _dataBaseName;
        private string _userName;
        private string _pass;
        private string _collectionName;
        IMongoDatabase _mongoDb;
        IMongoCollection<IVoluntario> _mongoColl;

        public string Server { get => _server; set => _server = value; }
        public int Port { get => _port; set => _port = value; }
        public string DataBaseName { get => _dataBaseName; set => _dataBaseName = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Pass { get => _pass; set => _pass = value; }

        public string CollectionName { get => _collectionName; set => _collectionName = value; }
        public IMongoDatabase VoluntarioDataBase { get => _mongoDb; set => _mongoDb = value; }
        public IMongoCollection<IVoluntario> VoluntarioCollection { get => _mongoColl; set => _mongoColl = value; }

        public VoluntarioMongoDbContext(string dataBaseName, string collectionName)
        {
            DataBaseName = dataBaseName;
            if (VoluntarioDataBase == null)
            {
                try
                {
                    VoluntarioDataBase = new MongoClient("mongodb://localhost").GetDatabase(DataBaseName);
                    VoluntarioCollection = VoluntarioDataBase.GetCollection<IVoluntario>(collectionName);
                    CollectionName = collectionName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        public void Dispose()
        {
            VoluntarioDataBase = null;
            VoluntarioCollection = null;
        }
    }
}
