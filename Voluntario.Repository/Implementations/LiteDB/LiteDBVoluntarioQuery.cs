using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.LiteDB
{
    public class LiteDBVoluntarioQuery : BaseLiteDBRepository, IRepositoryQuery
    {
        public bool IsToDispose { get; set; }
        public LiteDBVoluntarioQuery(string dataBaseName, string collectionName)
        {
            base.Context = new IoCManager.Voluntario.Data.Context.ContextIoCManager<LiteDatabase, ILiteCollection<IVoluntario>>().GetIContextCurrentImplementation(dataBaseName, collectionName);
            IsToDispose = true;
        }

        public LiteDBVoluntarioQuery(object context)
        {
            base.Context = (IBaseVoluntarioDbContext < LiteDatabase, ILiteCollection < IVoluntario >> )context;
            IsToDispose = false;
        }

        public IVoluntario GetVoluntarioByCpf(Int64 cpf)
        {
            IVoluntario vol = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                base.Context.VoluntarioCollection.EnsureIndex(x => x.Cpf);
                vol = base.Context.VoluntarioCollection.Query()
                    .Where(c => c.Cpf == cpf)
                    .FirstOrDefault();

            }
            return vol;
        }

        public IList<IVoluntario> GetVoluntarioByName(string name)
        {
            IList<IVoluntario> ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                base.Context.VoluntarioCollection.EnsureIndex(x => x.Nome);
                ret = base.Context.VoluntarioCollection.Query()
                    .Where(x => x.Nome.ToUpper().Contains(name.ToUpper()))
                    .OrderBy(x => x.Nome)
                    .Limit(100)
                    .ToList();

            }
            return ret;
        }

        public IVoluntario GetVoluntarioById(string Id)
        {
            IVoluntario vol = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                base.Context.VoluntarioCollection.EnsureIndex(x => x.Id);
                vol = base.Context.VoluntarioCollection.Query()
                    .Where(c => c.Id == Id)
                    .FirstOrDefault();

            }
            return vol;
        }

        /// <summary>
        /// TODO - pagnination
        /// </summary>
        /// <param name="currentPage"></param>
        /// <returns></returns>
        public IList<IVoluntario> GetListVoluntario(int currentPage)
        {
            IList<IVoluntario> ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                base.Context.VoluntarioCollection.EnsureIndex(x => x.Nome);
                ret = base.Context.VoluntarioCollection.Query()
                    .ToList();

            }
            return ret;
        }

        public IVoluntario GetVoluntarioByEmail(string email)
        {
            IVoluntario vol = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                base.Context.VoluntarioCollection.EnsureIndex(x => x.Email);
                vol = base.Context.VoluntarioCollection.Query()
                    .Where(c => c.Email == email)
                    .FirstOrDefault();

            }
            return vol;
        }


        public void Dispose()
        {
            if(IsToDispose)
            {
                if (Context != null && Context.VoluntarioDataBase != null)
                    Context.VoluntarioDataBase.Dispose();
                if (Context != null && Context.VoluntarioCollection != null)
                    Context.VoluntarioCollection = null;
                Context = null;
                RequestId = null;
            }

        }

    }
}
