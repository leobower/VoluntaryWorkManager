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
        private const string _senhaObfuscated = "********";

        #region Fields
        private Func<string, string, bool> _userLoginByEmail;
        Func<string, IVoluntario> _byId;
        Func<string, IVoluntario> _byEmail;
        Func<Int64, IVoluntario> _byCpf;
        Func<string, IList<IVoluntario>> _byName;
        Func<int, IList<IVoluntario>> _selectAllPaged;
        private IVoluntarioValidations _voluntarioValidations;

        private Int64 _cpf;
        private string _email;
        private string _id;
        private string _name;
        private int _currentPage;
        private string _pass;
        #endregion

        #region Props
        public IVoluntarioValidations VoluntarioValidations { get => _voluntarioValidations; set => _voluntarioValidations = value; }
        #endregion

        #region Filters (Props)
        public long Cpf { get => _cpf; set => _cpf = value; }
        public string Email { get => _email; set => _email = value; }
        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int CurrentPage { get => _currentPage; set => _currentPage = value; }
        public string Pass { get => _pass; set => _pass = value; }
        #endregion

        #region Delegates (Props)
        public Func<string, string, bool> UserLoginByEmail { get => _userLoginByEmail; set => _userLoginByEmail = value; }
        public Func<string, IVoluntario> ById { get => _byId; set => _byId = value; }
        public Func<string, IVoluntario> ByEmail { get => _byEmail; set => _byEmail = value; }
        public Func<string, IList<IVoluntario>> ByName { get => _byName; set => _byName = value; }
        public Func<int, IList<IVoluntario>> SelectAllPaged { get => _selectAllPaged; set => _selectAllPaged = value; }
        public Func<long, IVoluntario> ByCpf { get => _byCpf; set => _byCpf = value; }
        #endregion

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

        #region Public Methods
        public bool EmailLogIn()
        {
            if (!String.IsNullOrEmpty(Email))
                throw new Exception("Provide Email Property Information");
            if (!String.IsNullOrEmpty(Pass))
                throw new Exception("Provide Pass Property Information");
            return this.UserLoginByEmail(Email, Pass);
        }

        public IVoluntario GetById()
        {
            if (String.IsNullOrEmpty(Id))
                throw new Exception("Provide Id Property Information");
            var ret = this.ById(Id);
            if (ret != null)
                ret.Senha = _senhaObfuscated;
            return ret;
        }

        public IVoluntario GetByCpf()
        {
            Validate();

            if (!VoluntarioValidations.ValidaCPF(Cpf.ToString()))
                throw new Exception("Provide CPF Property Information");
            var ret = this.ByCpf(Cpf);
            if (ret != null)
                ret.Senha = _senhaObfuscated;
            return ret;
        }

        public IVoluntario GetByEmail()
        {
            Validate();
            if (!VoluntarioValidations.ValidaEmail(Email))
                throw new Exception("Provide Email Property Information");
            var ret = this.ByEmail(Email);
            if (ret != null)
                ret.Senha = _senhaObfuscated;
            return ret;
        }

        private IList<IVoluntario> SetSenhaList(IList<IVoluntario> pList)
        {
            var lista = (List<IVoluntario>)pList;
            lista.ForEach(p => { p.Senha = _senhaObfuscated; });
            return lista;
        }

        public IList<IVoluntario> GetByName()
        {
            if (String.IsNullOrEmpty(Name))
                throw new Exception("Provide Name Property Information");
            return SetSenhaList(this.ByName(Name));
        }

        public IList<IVoluntario> GetAll()
        {
            if (CurrentPage < 0)
                throw new Exception("Provide CurrentPage Property Information");
            return SetSenhaList(this.SelectAllPaged(CurrentPage));
        }
        #endregion



    }
}
