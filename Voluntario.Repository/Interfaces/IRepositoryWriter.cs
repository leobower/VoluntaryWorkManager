using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Repository.Interfaces
{
    public interface IRepositoryWriter : IDisposable
    {
        string ConnStr { get; set; }
        string DataBase { get; set; }
        string CollectionName { get; set; }

        void Delete<T>(T voluntario) where T : class, IVoluntario, new();
        void Update<T>(T voluntario) where T : class, IVoluntario, new();
        void Add<T>(T voluntario) where T : class, IVoluntario, new();
    }
}
