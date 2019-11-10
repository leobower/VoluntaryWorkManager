using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.BusinessObjects
{
    public class VoluntarioValidations : IVoluntarioValidations
    {
        private IVoluntario _voluntario;

        private Func<string, bool> _validaCPF;
        private Func<string, bool> _validaEmail;
        private Func<string, bool> _validaCEP;

        public Func<string, bool> ValidaCPF { get => _validaCPF; set => _validaCPF = value; }
        public Func<string, bool> ValidaEmail { get => _validaEmail; set => _validaEmail = value; }
        public Func<string, bool> ValidaCEP { get => _validaCEP; set => _validaCEP = value; }
        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }

        private bool ValidateObjVoluntario()
        {
            return Voluntario != null;
        }

    }
}
