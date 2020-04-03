using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Interfaces
{
    public interface IRepositoryWriter : IDisposable, IRequest
    {
        object ContextObj { get; }
        void Delete(IVoluntario voluntario);  
        void Update(IVoluntario voluntario);
        void Add(IVoluntario voluntario);
    }
}
