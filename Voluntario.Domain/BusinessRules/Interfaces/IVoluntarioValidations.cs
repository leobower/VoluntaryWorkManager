using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.Interfaces
{
    public interface IVoluntarioValidations
    {
        IVoluntario Voluntario { get; set; }

        Func<string, bool> ValidaCPF { get; set; }
        Func<string, bool> ValidaEmail { get; set; }
        Func<string, bool> ValidaCEP { get; set; }

        Func<bool> ValidaIdade { get;}


    }
}
