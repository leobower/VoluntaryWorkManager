﻿using LiteDB;
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
    public class LiteDBVoluntarioQuery : BaseLiteDBRepository, IRepositoryQuery
    {
        public bool IsToDispose { get; set; }
        private readonly IConfiguration _conf;

        public LiteDBVoluntarioQuery(string dataBaseName, string collectionName, IConfiguration conf)
        {
            _conf = conf;

            base.Context = new Voluntario.IoCManager.Data.Context.ContextIoCManager<LiteDatabase, ILiteCollection<IVoluntario>>(conf)
                .GetIContextCurrentImplementation(dataBaseName, collectionName);
            IsToDispose = true;
        }

        public LiteDBVoluntarioQuery(object context, IConfiguration conf)
        {
            _conf = conf;
            base.Context = (IBaseVoluntarioDbContext <LiteDatabase, ILiteCollection< IVoluntario >>)context;
            IsToDispose = false;
        }

        public bool EmailLogIn(string email, string pass)
        {
            bool ret = false;
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                base.Context.VoluntarioCollection.EnsureIndex(x => x.Email);
                ret = (base.Context.VoluntarioCollection.Query()
                    .Where(c => c.Email == email && c.Senha == pass)
                    .FirstOrDefault()) != null;
            }
            return ret;
        }


        public IVoluntario GetVoluntarioByCpf(Int64 cpf)
        {
            IVoluntario vol = null;
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
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
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
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
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
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
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
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
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
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
