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
        void InsertVoluntario();
        void UpdateVoluntario();
        void DeleteVoluntario();
    }
}
