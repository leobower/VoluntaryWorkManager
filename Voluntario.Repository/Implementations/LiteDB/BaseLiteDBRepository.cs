using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context.LiteDB;

namespace Voluntario.Data.Repository.Implementations.LiteDB
{
    public abstract class BaseLiteDBRepository
    {
        IVoluntarioLiteDbContext _context;
        public IVoluntarioLiteDbContext Context { get => _context; set => _context = value; }
        public string RequestId { get; set; }

        public void Validate()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                if (Context == null)
                    throw new Exception("Provide Contructor Information");
                if (String.IsNullOrEmpty(RequestId))
                    throw new Exception("Provide de RequestId Information");
            }

        }


    }
}
