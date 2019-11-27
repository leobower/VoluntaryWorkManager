using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Repository.Interfaces
{
    public interface IRepositoryWriter : IDisposable
    {
        void Delete<T>(T voluntario) where T : class, IVoluntario, new();
        void Update<T>(T voluntario) where T : class, IVoluntario, new();
        void Add<T>(T voluntario) where T : class, IVoluntario, new();
    }
}
