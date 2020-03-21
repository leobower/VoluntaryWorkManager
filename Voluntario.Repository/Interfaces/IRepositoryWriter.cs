using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDB;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Interfaces
{
    public interface IRepositoryWriter : IDisposable, IRequest
    {
        IVoluntarioLiteDbContext Context { get; set; }

        void Delete(IVoluntario voluntario);  
        void Update(IVoluntario voluntario);
        void Add(IVoluntario voluntario);
    }
}
