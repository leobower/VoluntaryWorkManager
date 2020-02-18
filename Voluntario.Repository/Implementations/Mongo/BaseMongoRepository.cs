using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;

namespace Voluntario.Data.Repository.Implementations.Mongo
{
    public abstract class BaseMongoRepository
    {
        protected IMongoDbContext _context;

        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        private string _connStr;
        private string _dataBase;
        private string _collectionName;

        public string ConnStr
        {
            get => _connStr;
            set
            {
                _connStr = value;
                if (_context != null)
                    _context.ConnStr = _connStr;
            } 
        }
        public string DataBase
        {
            get => _dataBase;
            set
            {
                _dataBase = value;
                if (_context != null)
                    _context.DataBase = _dataBase;
            }
        }
        public string CollectionName
        {
            get => _collectionName;
            set
            {
                _collectionName = value;
                if (_context != null)
                    _context.CollectionName = _collectionName;
            }
        }

        protected bool ValidateProperties()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {

                return (!String.IsNullOrEmpty(_connStr) &&
                        !String.IsNullOrEmpty(_dataBase) &&
                        !String.IsNullOrEmpty(_collectionName)
                       );
            }

        }

        protected void DisposeObj()
        {
            DataBase = null;
            _context = null;
            CollectionName = null;
            ConnStr = null;
        }


    }
}
