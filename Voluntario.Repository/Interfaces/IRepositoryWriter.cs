using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Interfaces
{
    public interface IRepositoryWriter : IDisposable, IRequest
    {
        string ConnStr { get; set; }
        string DataBase { get; set; }
        string CollectionName { get; set; }

        void Delete(IVoluntario voluntario);  
        void Update(IVoluntario voluntario);
        void Add(IVoluntario voluntario);
    }
}
