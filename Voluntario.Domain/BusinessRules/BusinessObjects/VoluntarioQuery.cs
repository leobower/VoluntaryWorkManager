using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.BusinessObjects
{
    public class VoluntarioQuery : IVoluntarioQuery
    {
        Func<string, IVoluntario> _byId;
        Func<string, IVoluntario> _byEmail;
        Func<Int64, IVoluntario> _byCpf;
        Func<string, IList<IVoluntario>> _byName;
        Func<int, double, IList<IVoluntario>> _selectAllPaged;
        private IVoluntarioValidations _voluntarioValidations;
        private Int64 _cpf;
        private string _email;
        private string _id;
        private string _name;


        public IVoluntarioValidations VoluntarioValidations { get => _voluntarioValidations; set => _voluntarioValidations = value; }

        public Func<string, IVoluntario> ById { get => _byId; set => _byId = value; }
        public Func<string, IVoluntario> ByEmail { get => _byEmail; set => _byEmail = value; }
        public Func<string, IList<IVoluntario>> ByName { get => _byName; set => _byName = value; }
        public Func<int, double, IList<IVoluntario>> SelectAllPaged { get => _selectAllPaged; set => _selectAllPaged = value; }
        public Func<long, IVoluntario> ByCpf { get => _byCpf; set => _byCpf = value; }
        public long Cpf { get => _cpf; set => _cpf = value; }
        public string Email { get => _email; set => _email = value; }
        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }

        private bool ValidateObjVoluntarioValidation()
        {
            return ((VoluntarioValidations != null) &&
                            VoluntarioValidations.ValidaCPF != null &&
                            VoluntarioValidations.ValidaEmail != null)
                   ;
        }

        private void Validate()
        {
            if (!ValidateObjVoluntarioValidation())
                throw new Exception("Set the IVoluntarioValidations property and it's properties");

        }

       
        public IVoluntario GetById()
        {
            if (String.IsNullOrEmpty(Id))
                throw new Exception("Provide Id Property Information");
            return this.ById(Id);
        }

        public IVoluntario GetByCpf()
        {
            Validate();

            if (!VoluntarioValidations.ValidaCPF(Cpf.ToString()))
                throw new Exception("Provide CPF Property Information");
            return this.ByCpf(Cpf);
        }

        public IVoluntario GetByEmail()
        {
            Validate();
            if (!VoluntarioValidations.ValidaEmail(Email))
                throw new Exception("Provide Email Property Information");
            return this.ByEmail(Email);
        }

        public IList<IVoluntario> GetByName()
        {
            if (String.IsNullOrEmpty(Name))
                throw new Exception("Provide Name Property Information");
            return this.ByName(Name);
        }

    }
}
