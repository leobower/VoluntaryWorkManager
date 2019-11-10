using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.BusinessObjects
{
    public class VoluntarioValidations : IVoluntarioValidations
    {
        public IVoluntario Voluntario { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private bool ValidateObjVoluntario()
        {
            return Voluntario != null;
        }

        public Func<string, bool> ValidaCPF { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Func<string, bool> ValidaEmail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Func<string, bool> ValidaCEP { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
