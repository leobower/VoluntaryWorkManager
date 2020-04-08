using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.Mongo
{
    public class BaseMongoDBRepository
    {
        IBaseVoluntarioDbContext<IMongoDatabase, IMongoCollection<IVoluntario>> _context;
        public virtual IBaseVoluntarioDbContext<IMongoDatabase, IMongoCollection<IVoluntario>> Context { get => _context; set => _context = value; }

        public string RequestId { get; set; }

        public void Validate()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (Context == null)
                    throw new Exception("Provide Contructor Information");
                if (String.IsNullOrEmpty(RequestId))
                    throw new Exception("Provide de RequestId Information");
            }

        }
    }
}
