using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.Rules
{
    public class VoluntarioValidations : IVoluntarioValidations
    {
        //TODO - PARAM
        private const Int16 MIN_AGE = 18;

        #region Fields
        private VoluntaryFieldsValidator _lengthValidator;
        private IVoluntario _voluntario;
        private Func<string, bool> _validaCPF;
        private Func<string, bool> _validaEmail;
        private Func<string, bool> _validaCEP;
        #endregion

        #region External Rules (Props Delegates)
        public Func<string, bool> ValidaCPF { get => _validaCPF; set => _validaCPF = value; }
        public Func<string, bool> ValidaEmail { get => _validaEmail; set => _validaEmail = value; }
        public Func<string, bool> ValidaCEP { get => _validaCEP; set => _validaCEP = value; }
        #endregion

        #region Internal Rules (Props Delegates)
        public Func<bool> ValidaIdade { get => AgeValidator; }
        public Func<bool> ValidaId { get => _lengthValidator.IdValidator; }
        public Func<bool> ValidaLengthCpf { get => _lengthValidator.CpfValidator; }
        public Func<bool> ValidaSenha { get => _lengthValidator.SenhaValidator; }

        #endregion

        #region Props
        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }
        public VoluntaryFieldsValidator LengthValidator { get => _lengthValidator; set => _lengthValidator = value; }

        #endregion

        public VoluntarioValidations()
        {
            _lengthValidator = new VoluntaryFieldsValidator();
        }

        private bool AgeValidator()
        {
            if (_voluntario == null)
                throw new Exception("Voluntario is null");
            bool ret;
            int currentYear = DateTime.Today.Year;
            int age = currentYear - DateTime.Parse(_voluntario.DataNascimento).Year;
            ret = age >= MIN_AGE;
            return ret;
        }

    }
}
