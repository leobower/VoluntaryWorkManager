using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.Interfaces
{
    public interface IVoluntarioPersistence
    {
        IVoluntarioValidations VoluntarioValidations { get; set; }
        IVoluntario Voluntario { get; set; }

        Action<IVoluntario> Insert { get; set; }
        Action<IVoluntario> Delete { get; set; }
        Action<IVoluntario> Update { get; set; }
        Func<string,string> Encrypt { set; }
        Func<string, IVoluntario> ExistsEmail { get; set; }
        Func<Int64, IVoluntario> ExistsCPF { get; set; }
        void InsertVoluntario();
        void UpdateVoluntario();
        void DeleteVoluntario();
    }
}
