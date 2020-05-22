using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.Mongo
{
    public class MongoDBVoluntarioWriter : BaseMongoDBRepository, IRepositoryWriter
    {
        public object ContextObj { get => (object)base.Context; }
        private readonly IConfiguration _conf;

        public MongoDBVoluntarioWriter(string dataBaseName, string collectionName, IConfiguration conf)
        {
            _conf = conf;
            base.Context = new Voluntario.IoCManager.Data.Context.ContextIoCManager<IMongoDatabase, IMongoCollection<IVoluntario>>(_conf)
                .GetIContextCurrentImplementation(dataBaseName, collectionName);
        }

        public void Add(IVoluntario voluntario)
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                Validate();
                base.Context.VoluntarioCollection.InsertOne(voluntario);
            }
        }

        public void Delete(IVoluntario voluntario)
        {
            DeleteResult delresult = base.Context.VoluntarioCollection.DeleteOne(Builders<IVoluntario>.Filter.Eq("_id", voluntario.Id));
        }

        public void Update(IVoluntario voluntario)
        {
            ReplaceOneResult upResult = base.Context.VoluntarioCollection.ReplaceOne(Builders<IVoluntario>.Filter.Eq("_id",voluntario.Id), voluntario);
        }

        public void Dispose()
        {
            Context.VoluntarioDataBase = null;
            Context.VoluntarioCollection = null;
            Context = null;
            RequestId = null;
        }
    }
}
