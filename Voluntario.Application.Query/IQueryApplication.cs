using System;
using System.Collections.Generic;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application.Query
{
    public interface IQueryApplication : IDisposable
    {
        string RequestId { get; set; }
        long Cpf { get; set; }
        string VoluntarioId { get; set; }
        string VoluntarioName { get; set; }
        string Email { get; set; }
        int CurrentPage { get; set; }
        double TotalPages { get; set; }
        string Pass { set; }

        bool EmailLogIn();
        IVoluntario GetById();
        IVoluntario GetByCpf();
        IVoluntario GetByEmail();
        IList<IVoluntario> GetByName();
        IList<IVoluntario> GetAllPaged(int currentPage);
    }
}
