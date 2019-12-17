using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Context
{
    public class MongoDbContext : IMongoDbContext
    {
        private IMongoClient _mongoClient;
        private IMongoDatabase _mongoDataBase;
        private IMongoCollection<IVoluntario> _voluntarioEntityCollection;

        private string _connStr;
        private string _dataBase;
        private string _collectionName;
        public string ConnStr
        {
            get
            {
                return _connStr;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    MongoClientSettings settings = new MongoClientSettings
                    {
                        Server = new MongoServerAddress(value, 27017)
                    };
                    _mongoClient = new MongoClient(settings);

                }
                _connStr = value;
            }
        }
        public string DataBase
        {
            get => _dataBase;
            set
            {
                if (!string.IsNullOrEmpty(value) && _mongoClient != null)
                    _mongoDataBase = _mongoClient.GetDatabase(value);

                _dataBase = value;
            }
        }
        public string CollectionName
        {
            get => _collectionName;
            set
            {
                if (!String.IsNullOrEmpty(value) && _mongoDataBase != null)
                    _voluntarioEntityCollection = _mongoDataBase.GetCollection<IVoluntario>(value);

                _collectionName = value;
            }
        }

        public IMongoClient MongoClient
        {
            get
            {
                //if (_mongoClient == null)
                //{
                //    if (!String.IsNullOrEmpty(_connStr))
                //        _mongoClient = new MongoClient(_connStr);
                //    else
                //        throw new Exception("Provide ConnStr Property information");

                //}
                return _mongoClient;
                //

            }
            //get => _mongoClient;
            set => _mongoClient = value;
        }
        public IMongoDatabase MongoDataBase
        {
            get
            {
                //if (_mongoDataBase == null)
                //{
                //    if (!String.IsNullOrEmpty(_dataBase))
                //        _mongoDataBase = _mongoClient.GetDatabase(_dataBase);
                //    else
                //        throw new Exception("Provide DataBase Property information");
                //}
                return _mongoDataBase;
            }
            set => _mongoDataBase = value;
        }
        public IMongoCollection<IVoluntario> VoluntarioCollection
        {
            get
            {
                //if (_logEntityCollection == null)
                //{
                //    if (!String.IsNullOrEmpty(_collectionName))
                //        _logEntityCollection = _mongoDataBase.GetCollection<IEntity>(_collectionName);
                //    else
                //        throw new Exception("Provide CollectionName Property information");
                //}
                return _voluntarioEntityCollection;
            }
            set => _voluntarioEntityCollection = value;
        }

        public MongoDbContext()
        {


        }
        
        public void Dispose()
        {
            _mongoClient = null;
            _mongoDataBase = null;
            _voluntarioEntityCollection = null;
        }
    }
}
