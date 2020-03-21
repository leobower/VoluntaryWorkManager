using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDB;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.LiteDB
{
    public class LiteDBVoluntarioWriter : BaseLiteDBRepository, IRepositoryWriter
    {

        public LiteDBVoluntarioWriter(string dataBaseName, string collectionName)
        {
            base.Context = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIContextCurrentImplementation(dataBaseName, collectionName);
        }

        

        public void Add(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                Validate();
                Context.VoluntarioCollection.Insert(voluntario);
            }
        }

        public void Update(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                Validate();
                Context.VoluntarioCollection.Update(voluntario);
            }
        }

        public void Delete(IVoluntario voluntario)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
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
