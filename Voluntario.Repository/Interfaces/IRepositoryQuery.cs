using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Interfaces
{
    public interface IRepositoryQuery : IDisposable, IRequest
    {
       // IVoluntarioLiteDbContext Context { get; set; }
        bool IsToDispose { get; set; }

        bool EmailLogIn(string email, string pass);
        IVoluntario GetVoluntarioByCpf(Int64 cpf);
        IList<IVoluntario> GetVoluntarioByName(string name);
        IVoluntario GetVoluntarioById(string Id);
        IVoluntario GetVoluntarioByEmail(string email);
        IList<IVoluntario> GetListVoluntario(int currentPage);
    }
}
