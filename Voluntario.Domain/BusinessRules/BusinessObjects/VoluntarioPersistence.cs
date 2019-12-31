using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.BusinessObjects
{
    public class VoluntarioPersistence : IVoluntarioPersistence
    {
        private IVoluntarioValidations _voluntarioValidations;
        private IVoluntario _voluntario;

        private Action<IVoluntario> _insert;
        private Action<IVoluntario> _delete;
        private Action<IVoluntario> _update;

        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }
        public IVoluntarioValidations VoluntarioValidations { get => _voluntarioValidations; set => _voluntarioValidations = value; }

        public Action<IVoluntario> Insert { get => _insert; set => _insert = value; }
        public Action<IVoluntario> Delete { get => _delete; set => _delete = value; }
        public Action<IVoluntario> Update { get => _update; set => _update = value; }

        private bool ValidateObjVoluntario()
        {
            return Voluntario != null;
        }

        private bool ValidateObjVoluntarioValidation()
        {
            return ((VoluntarioValidations != null) &&
                         (VoluntarioValidations.ValidaCEP != null &&
                            VoluntarioValidations.ValidaCPF != null &&
                            VoluntarioValidations.ValidaEmail != null)
                   );
        }

        private void ValidateVoluntario()
        {
            if (!ValidateObjVoluntario())
                throw new Exception("Null Reference of 'IVoluntario' property");

            if (!ValidateObjVoluntarioValidation())
                throw new Exception("Set the IVoluntarioValidations property and it's properties");

            if (!VoluntarioValidations.ValidaCEP(Voluntario.Cep.ToString()))
                throw new Exception("");

            if (!VoluntarioValidations.ValidaCPF(Voluntario.Cpf.ToString()))
                throw new Exception("");

            if (!VoluntarioValidations.ValidaEmail(Voluntario.Email))
                throw new Exception("");

        }


        public void InsertVoluntario()
        {
            ValidateVoluntario();

            this.Insert(Voluntario);
        }

        public void UpdateVoluntario()
        {
            ValidateVoluntario();

            this.Update(Voluntario);
        }

        public void DeleteVoluntario()
        {
            if (!ValidateObjVoluntario())
                throw new Exception("Null Reference of 'IVoluntario' property");

            this.Delete(Voluntario);
        }
    }
}
