using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.Mongo
{
    public class MongoDBVoluntarioQuery : BaseMongoDBRepository, IRepositoryQuery
    {
        public bool IsToDispose { get; set; }
        private readonly IConfiguration _conf;
        public MongoDBVoluntarioQuery(string dataBaseName, string collectionName, IConfiguration conf)
        {
            _conf = conf;
            base.Context = new Voluntario.IoCManager.Data.Context.ContextIoCManager<IMongoDatabase, IMongoCollection<IVoluntario>>(conf).GetIContextCurrentImplementation(dataBaseName, collectionName, null);
            IsToDispose = true;
        }

        public MongoDBVoluntarioQuery(object context, IConfiguration conf)
        {
            _conf = conf;
            base.Context = (IBaseVoluntarioDbContext<IMongoDatabase, IMongoCollection<IVoluntario>>)context;
            IsToDispose = false;
        }

        //TODO PAGINATION
        public IList<IVoluntario> GetListVoluntario(int currentPage)
        {
            IList<IVoluntario> ret = null;
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                IMongoQueryable<IVoluntario> query = base.Context.VoluntarioCollection.AsQueryable();
                                        //.OrderBy(x => x.Nome);

                ret = query.ToList();
            }
            return ret;
        }

        public IVoluntario GetVoluntarioByCpf(long cpf)
        {
            IVoluntario ret = null;
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                Expression<Func<IVoluntario, bool>> filter = x => x.Cpf.Equals(cpf);
                ret = base.Context.VoluntarioCollection.Find(filter).First();
            }
            return ret;
        }

        public IVoluntario GetVoluntarioByEmail(string email)
        {
            IVoluntario ret = null;
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                Expression<Func<IVoluntario, bool>> filter = x => x.Email.Equals(email);
                ret = base.Context.VoluntarioCollection.Find(filter).First();
            }
            return ret;
        }

        public IVoluntario GetVoluntarioById(string Id)
        {
            IVoluntario ret = null;
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                Expression<Func<IVoluntario, bool>> filter = x => x.Id.Equals(Id);
                ret = base.Context.VoluntarioCollection.Find(filter).First();
            }
            return ret;
        }

        public IList<IVoluntario> GetVoluntarioByName(string name)
        {
            IList<IVoluntario> ret = null;
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                IMongoQueryable<IVoluntario> query = base.Context.VoluntarioCollection.AsQueryable()
                                        .Where(x => x.Nome.Contains(name))
                                        .OrderBy(x => x.Nome);

                ret = query.ToList();
            }
            return ret;
        }

        public void Dispose()
        {
            if (IsToDispose)
            {
                if (Context != null && Context.VoluntarioDataBase != null)
                    Context.VoluntarioDataBase = null;
                if (Context != null && Context.VoluntarioCollection != null)
                    Context.VoluntarioCollection = null;
                Context = null;
                RequestId = null;
            }
        }

        public bool EmailLogIn(string email, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
