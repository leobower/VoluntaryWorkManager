﻿using MongoDB.Driver;
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

        public MongoDBVoluntarioQuery(string dataBaseName, string collectionName)
        {
            //TODO
            base.Context = new IoCManager.Voluntario.Data.Context.ContextIoCManager_2<IMongoDatabase, IMongoCollection<IVoluntario>>().GetIContextCurrentImplementation(dataBaseName, collectionName);
            IsToDispose = true;
        }

        public MongoDBVoluntarioQuery(object context)
        {
            base.Context = (IBaseVoluntarioDbContext<IMongoDatabase, IMongoCollection<IVoluntario>>)context;
            IsToDispose = false;
        }



        public IList<IVoluntario> GetListVoluntario(int currentPage)
        {
            IList<IVoluntario> ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                IMongoQueryable<IVoluntario> query = base.Context.VoluntarioCollection.AsQueryable()
                                        .OrderBy(x => x.Nome);

                ret = query.ToList();
            }
            return ret;
        }

        public IVoluntario GetVoluntarioByCpf(long cpf)
        {
            IVoluntario ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                Expression<Func<IVoluntario, bool>> filter = x => x.Cpf.Equals(cpf);
                ret = base.Context.VoluntarioCollection.Find(filter).First();
            }
            return ret;
        }

        public IVoluntario GetVoluntarioByEmail(string email)
        {
            IVoluntario ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                Expression<Func<IVoluntario, bool>> filter = x => x.Email.Equals(email);
                ret = base.Context.VoluntarioCollection.Find(filter).First();
            }
            return ret;
        }

        public IVoluntario GetVoluntarioById(string Id)
        {
            IVoluntario ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                Expression<Func<IVoluntario, bool>> filter = x => x.Id.Equals(Id);
                ret = base.Context.VoluntarioCollection.Find(filter).First();
            }
            return ret;
        }

        public IList<IVoluntario> GetVoluntarioByName(string name)
        {
            IList<IVoluntario> ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
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


    }
}
