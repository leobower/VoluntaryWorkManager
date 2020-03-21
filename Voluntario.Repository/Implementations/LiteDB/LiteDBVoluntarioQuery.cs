using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context.LiteDB;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.LiteDB
{
    public class LiteDBVoluntarioQuery : BaseLiteDBRepository, IRepositoryQuery
    {
        public LiteDBVoluntarioQuery(string dataBaseName, string collectionName)
        {
            base.Context = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIContextCurrentImplementation(dataBaseName, collectionName);
        }

        public IVoluntario GetVoluntarioByCpf(Int64 cpf)
        {
            IVoluntario vol = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                var col = base.Context.VoluntarioDataBase.GetCollection<IVoluntario>(base.Context.CollectionName);
                col.EnsureIndex(x => x.Cpf);
                vol = col.Query()
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
                var col = base.Context.VoluntarioDataBase.GetCollection<IVoluntario>(base.Context.CollectionName);
                col.EnsureIndex(x => x.Nome);
                ret = col.Query()
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
                var col = base.Context.VoluntarioDataBase.GetCollection<IVoluntario>(base.Context.CollectionName);
                col.EnsureIndex(x => x.Id);
                vol = col.Query()
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
                var col = base.Context.VoluntarioDataBase.GetCollection<IVoluntario>(base.Context.CollectionName);
                col.EnsureIndex(x => x.Nome);
                ret = col.Query()
                    .ToList();

            }
            return ret;
        }

        public IVoluntario GetVoluntarioByEmail(string email)
        {
            IVoluntario vol = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                var col = base.Context.VoluntarioDataBase.GetCollection<IVoluntario>(base.Context.CollectionName);
                col.EnsureIndex(x => x.Email);
                vol = col.Query()
                    .Where(c => c.Email == email)
                    .FirstOrDefault();

            }
            return vol;
        }


        public void Dispose()
        {
            if(Context != null && Context.VoluntarioDataBase != null)
                Context.VoluntarioDataBase.Dispose();
            if(Context != null && Context.VoluntarioCollection != null)
                Context.VoluntarioCollection = null;
            Context = null;
            RequestId = null;
        }

    }
}
