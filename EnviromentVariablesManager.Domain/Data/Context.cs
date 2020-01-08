using EnviromentVariablesManager.Domain.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnviromentVariablesManager.Domain.Data
{
    internal class Context : IDisposable
    {
        private IMongoClient _mongoClient;
        private IMongoDatabase _mongoDataBase;
        private IMongoCollection<IDataBaseVariables> _variableCollection;

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
                        Server = new MongoServerAddress(value, 27017)//TODO
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
                    _variableCollection = _mongoDataBase.GetCollection<IDataBaseVariables>(value);

                _collectionName = value;
            }
        }

        public IMongoClient MongoClient
        {
            get
            {
                return _mongoClient;
                //

            }
            set => _mongoClient = value;
        }
        public IMongoDatabase MongoDataBase
        {
            get
            {
                return _mongoDataBase;
            }
            set => _mongoDataBase = value;
        }
        public IMongoCollection<IDataBaseVariables> VariableCollection
        {
            get
            {
                return _variableCollection;
            }
            set => _variableCollection = value;
        }

        public Context()
        {


        }

        public void Dispose()
        {
            _mongoClient = null;
            _mongoDataBase = null;
            _variableCollection = null;
        }
    }
}
