using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Data.Context;
using IoCManager.Voluntario.Data.Context;
using CentralSharedModel.Interfaces;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Voluntario.Data.Repository.Implementations
{
    public class MongoRepositoryWriter : IRepositoryWriter
    {
        private readonly IMongoDbContext _context;

        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        private string _connStr;
        private string _dataBase;
        private string _collectionName;

        public string ConnStr { get => _connStr; set => _connStr = value; }
        public string DataBase { get => _dataBase; set => _dataBase = value; }
        public string CollectionName { get => _collectionName; set => _collectionName = value; }

        private bool ValidateProperties()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {

                return (!String.IsNullOrEmpty(_connStr) &&
                        !String.IsNullOrEmpty(_dataBase) &&
                        !String.IsNullOrEmpty(_collectionName)
                       );
            }

        }

        public MongoRepositoryWriter()
        {
            if (_context == null)
                _context = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIMongoContextCurrentImplementation();
        }


        public void Add(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (ValidateProperties())
                {
                    _context.ConnStr = _connStr;
                    _context.DataBase = _dataBase;
                    _context.CollectionName = _collectionName;

                    _context.VoluntarioCollection.InsertOne(voluntario);
                }
            }
        }

        public void Delete(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (ValidateProperties())
                {
                    _context.ConnStr = _connStr;
                    _context.DataBase = _dataBase;
                    _context.CollectionName = _collectionName;

                    var filter = Builders<IVoluntario>.Filter.Eq("_id", voluntario.Id);//Where(x => x.Id == voluntario.Id);

                    _context.VoluntarioCollection.DeleteOne(filter);
                }
            }
        }

        public void Update(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (ValidateProperties())
                {
                    _context.ConnStr = _connStr;
                    _context.DataBase = _dataBase;
                    _context.CollectionName = _collectionName;

                    var filter = Builders<IVoluntario>.Filter.Eq("_id", voluntario.Id);//Where(x => x.Id == voluntario.Id);
                   // var update = Builders<IVoluntario>.Update. Set(filter, voluntario);

                    _context.VoluntarioCollection.ReplaceOne(filter, voluntario);

                }
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
