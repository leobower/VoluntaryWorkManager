using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Interfaces
{
    public interface IRepositoryQuery : IDisposable, IRequest
    {
        string ConnStr { get; set; }
        string DataBase { get; set; }
        string CollectionName { get; set; }
        double TotalPages { get; set; }


        IVoluntario GetVoluntarioByCpf(Int64 cpf);
        IList<IVoluntario> GetVoluntarioByName(string name);
        IVoluntario GetVoluntarioById(string Id);
        IVoluntario GetVoluntarioByEmail(string email);
        IList<IVoluntario> GetListVoluntario(int currentPage);
    }
}
