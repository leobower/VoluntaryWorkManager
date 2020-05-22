using LiteDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.LiteDB
{
    public class LiteDBVoluntarioWriter : BaseLiteDBRepository, IRepositoryWriter
    {
        public object ContextObj {get => (object)base.Context;}
        private readonly IConfiguration _conf;

        public LiteDBVoluntarioWriter(string dataBaseName, string collectionName, IConfiguration conf)
        {
            _conf = conf;
            base.Context = new Voluntario.IoCManager.Data.Context.ContextIoCManager<LiteDatabase, ILiteCollection<IVoluntario>>(_conf)
                .GetIContextCurrentImplementation(dataBaseName, collectionName);
        }

        public void Add(IVoluntario voluntario)
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                Validate();
                Context.VoluntarioCollection.Insert(voluntario);
            }
        }

        public void Update(IVoluntario voluntario)
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                Validate();
                Context.VoluntarioCollection.Update(voluntario);
            }
        }

        public void Delete(IVoluntario voluntario)
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                Validate();
                Context.VoluntarioCollection.Delete(voluntario.Id);
            }
        }

        public void Dispose()
        {
            Context.VoluntarioDataBase.Dispose();
            Context.VoluntarioCollection = null;
            Context = null;
            RequestId = null;
        }

    }
}
