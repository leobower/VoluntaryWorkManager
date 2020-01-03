using System;
//using System.Linq;
using System.Collections.Generic;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.Entities.Interfaces;
using MongoDB.Driver.Linq;
using MongoDB.Driver;
using System.Text.RegularExpressions;
using MongoDB.Bson;

namespace Voluntario.Data.Repository.Implementations
{
    public class MongoRepositoryQuery : BaseMongoRepository, IRepositoryQuery
    {
        public MongoRepositoryQuery()
        {
            if (base._context == null)
                base._context = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIMongoContextCurrentImplementation();
        }


        public IList<IVoluntario> GetListVoluntario(int currentPage, double totalPages)
        {
            IList<IVoluntario> ret = null;
            double pagesTotal = 0;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (!base.ValidateProperties())
                    throw new Exception("Provide the ConnStr, DataBase and CollectionName properties information");

                int pageSize = 2;
                double totalDocuments = _context.VoluntarioCollection.CountDocuments(FilterDefinition<IVoluntario>.Empty);
                pagesTotal = Math.Ceiling(totalDocuments / pageSize);

                ret = _context.VoluntarioCollection.Find(FilterDefinition<IVoluntario>.Empty)
                            .Skip((currentPage - 1) * pageSize)
                            .Limit(pageSize).ToList();


            }
            totalPages = pagesTotal;
            return ret;
        }


        public IVoluntario GetVoluntarioByCpf(long cpf)
        {
            IVoluntario ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (!base.ValidateProperties())
                    throw new Exception("Provide the ConnStr, DataBase and CollectionName properties information");

                var filter = Builders<IVoluntario>.Filter.Eq("Cpf", cpf);

                ret = base._context.VoluntarioCollection.Find(filter).First();

            }
            return ret;
        }

        public IVoluntario GetVoluntarioByEmail(string email)
        {
            IVoluntario ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (!base.ValidateProperties())
                    throw new Exception("Provide the ConnStr, DataBase and CollectionName properties information");

                var filter = Builders<IVoluntario>.Filter.Eq("Email", email);

                ret = base._context.VoluntarioCollection.Find(filter).First();

            }
            return ret;
        }

        public IVoluntario GetVoluntarioById(string id)
        {
            IVoluntario ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (!base.ValidateProperties())
                    throw new Exception("Provide the ConnStr, DataBase and CollectionName properties information");

                var filter = Builders<IVoluntario>.Filter.Eq("_id", id);
                ret = base._context.VoluntarioCollection.Find(filter).First();
            }
            return ret;
        }

        public IList<IVoluntario> GetVoluntarioByName(string name)
        {
            IList<IVoluntario> ret = null;
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (!base.ValidateProperties())
                    throw new Exception("Provide the ConnStr, DataBase and CollectionName properties information");
                var regex = new Regex($"^{name}");

                var filter = Builders<IVoluntario>.Filter.ElemMatch(x => x.Nome, x => Regex.IsMatch(name, $"^{name}"));
                ret = base._context.VoluntarioCollection.Find(filter).ToList();

            }
            return ret;
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
