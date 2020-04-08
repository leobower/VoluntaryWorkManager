using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Implementations.LiteDB
{
    public abstract class BaseLiteDBRepository
    {
        IBaseVoluntarioDbContext<LiteDatabase, ILiteCollection<IVoluntario>> _context;
        public virtual IBaseVoluntarioDbContext<LiteDatabase, ILiteCollection<IVoluntario>> Context { get => _context; set => _context = value; }
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
