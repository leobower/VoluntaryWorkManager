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
    public class MongoRepositoryWriter : BaseMongoRepository, IRepositoryWriter
    { 
       
        public MongoRepositoryWriter()
        {
            if (base._context == null)
                base._context = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIMongoContextCurrentImplementation();
        }


        public void Add(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (base.ValidateProperties())
                {
                    base._context.VoluntarioCollection.InsertOne(voluntario);
                }
            }
        }

        public void Delete(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (base.ValidateProperties())
                {
                    var filter = Builders<IVoluntario>.Filter.Eq("_id", voluntario.Id);//Where(x => x.Id == voluntario.Id);

                    base._context.VoluntarioCollection.DeleteOne(filter);
                }
            }
        }

        public void Update(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (base.ValidateProperties())
                {
                    var filter = Builders<IVoluntario>.Filter.Eq("_id", voluntario.Id);//Where(x => x.Id == voluntario.Id);
                                                                                       // var update = Builders<IVoluntario>.Update. Set(filter, voluntario);
                    base._context.VoluntarioCollection.ReplaceOne(filter, voluntario);

                }
            }
        }


        public void Dispose()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                base.DisposeObj();
            }
        }

    }
}
