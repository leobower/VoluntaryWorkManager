using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.BusinessObjects
{
    public class VoluntarioValidations : IVoluntarioValidations
    {
        //TODO - PARAM
        private const Int16 MIN_AGE = 18; 

        private IVoluntario _voluntario;

        private Func<string, bool> _validaCPF;
        private Func<string, bool> _validaEmail;
        private Func<string, bool> _validaCEP;
        private Func< bool> _validaIdade;

        public Func<string, bool> ValidaCPF { get => _validaCPF; set => _validaCPF = value; }
        public Func<string, bool> ValidaEmail { get => _validaEmail; set => _validaEmail = value; }
        public Func<string, bool> ValidaCEP { get => _validaCEP; set => _validaCEP = value; }
        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }
        public Func< bool> ValidaIdade { get => validaIdade;}

        private bool validaIdade()
        {
            if (_voluntario == null)
                throw new Exception("Voluntario is null");
            bool ret = false;
            int currentYear = DateTime.Today.Year;
            int age = currentYear - DateTime.Parse(_voluntario.DataNascimento).Year;
            ret = age >= MIN_AGE;
            return ret;
        }
        private bool ValidateObjVoluntario()
        {
            return Voluntario != null;
        }

    }
}
