using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.Interfaces
{
    public interface IVoluntarioQuery
    {
        IVoluntarioValidations VoluntarioValidations { get; set; }

        Func<string, string, bool> UserLoginByEmail { get; set; }
        Func<Int64, IVoluntario> ByCpf { get; set; }
        Func<string, IVoluntario> ById { get; set; }
        Func<string, IVoluntario> ByEmail { get; set; }
        Func<string, IList<IVoluntario>> ByName { get; set; }
        Func<int, IList<IVoluntario>> SelectAllPaged { get; set; }

        string Pass { get; set; }
        long Cpf { get; set; }
        string Email { get; set; }
        string Id { get; set; }
        string Name { get; set; }
        int CurrentPage { get; set; }

        bool EmailLogIn();
        IVoluntario GetById();
        IVoluntario GetByCpf();
        IVoluntario GetByEmail();
        IList<IVoluntario> GetByName();
        IList<IVoluntario> GetAll();

    }
}
