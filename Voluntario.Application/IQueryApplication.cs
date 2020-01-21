using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application
{
    public interface IQueryApplication : IDisposable
    {
        string RequestId { get; set; }
        IVoluntario GetById();
        IVoluntario GetByCpf();
        IVoluntario GetByEmail();
        IList<IVoluntario> GetByName();
        IList<IVoluntario> GetAllPaged(int currentPage);
    }
}
