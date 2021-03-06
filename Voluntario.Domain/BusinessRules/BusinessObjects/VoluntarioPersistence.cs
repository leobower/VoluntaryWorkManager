﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.BusinessObjects
{
    public class VoluntarioPersistence : IVoluntarioPersistence
    {
        #region Fields
        private IVoluntarioValidations _voluntarioValidations;
        private IVoluntario _voluntario;
        private Action<IVoluntario> _insert;
        private Action<IVoluntario> _delete;
        private Action<IVoluntario> _update;
        private Func<string, IVoluntario> _existsEmail;
        private Func<Int64, IVoluntario> _existsCPF;
        private Func<string, string> _encrypt;
        #endregion

        #region Props
        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }
        public IVoluntarioValidations VoluntarioValidations { get => _voluntarioValidations; set => _voluntarioValidations = value; }
        #endregion

        #region Props Delegates
        public Action<IVoluntario> Insert { get => _insert; set => _insert = value; }
        public Action<IVoluntario> Delete { get => _delete; set => _delete = value; }
        public Action<IVoluntario> Update { get => _update; set => _update = value; }
        public Func<string, string> Encrypt { set => _encrypt = value; }
        public Func<string, IVoluntario> ExistsEmail { get => _existsEmail; set => _existsEmail = value; }
        public Func<Int64, IVoluntario> ExistsCPF { get => _existsCPF; set => _existsCPF = value; }
        #endregion

        private bool ValidateObjVoluntario()
        {
            return Voluntario != null;
        }

        private bool ValidateObjVoluntarioValidation()
        {
            return ((VoluntarioValidations != null) &&
                    (VoluntarioValidations.ValidaId != null &&
                    VoluntarioValidations.ValidaLengthCpf != null &&
                    VoluntarioValidations.ValidaSenha != null && 
                    VoluntarioValidations.ValidaCEP != null &&
                    VoluntarioValidations.ValidaCPF != null &&
                    VoluntarioValidations.ValidaEmail != null 
                    )
                   );
        }

        private void ValidateVoluntario()
        {
            if (!ValidateObjVoluntario())
                throw new Exception("Null Reference of 'IVoluntario' property");

            if(!VoluntarioValidations.ValidaId())
                throw new Exception("Invalid Valur for the Id property");

            if (!VoluntarioValidations.ValidaLengthCpf())
                throw new Exception("Invalid Valur for the Cpf property");

            if (!VoluntarioValidations.ValidaSenha())
                throw new Exception("Invalid Valur for the Senha property");

            if (!ValidateObjVoluntarioValidation())
                throw new Exception("Set the IVoluntarioValidations property and it's properties");

            if (!VoluntarioValidations.ValidaCEP(Voluntario.Cep.ToString()))
                throw new Exception("Invalid CEP");

            if (!VoluntarioValidations.ValidaCPF(Voluntario.Cpf.ToString()))
                throw new Exception("invalid CPF");

            if (!VoluntarioValidations.ValidaEmail(Voluntario.Email))
                throw new Exception("Invalid Email");

            if(!VoluntarioValidations.ValidaIdade.Invoke())
                throw new Exception("Invalid Age");

        }

        private void SetSenha()
        {
            var att = typeof(IVoluntario).GetTypeInfo().GetProperty("Senha").GetCustomAttribute<CustomMaxLength>();
            if(!String.IsNullOrEmpty(Voluntario.Senha))
            {
                if(!Voluntario.Senha.Length.Equals(att.MaxLength))
                {
                    if (Voluntario.Senha.Length.Equals(att.MinLength))
                        Voluntario.Senha = _encrypt(Voluntario.Senha);
                    else
                        throw new Exception("Invalid value for Senha Property");
                }
            }
           
        }

        #region Public Methods
        public void InsertVoluntario()
        {
            ValidateVoluntario();
            SetSenha();

            if (String.IsNullOrEmpty(Voluntario.Id))
                Voluntario.Id = Guid.NewGuid().ToString();

            if (ExistsCPF(_voluntario.Cpf) != null)
                throw new Exception("Check the CPF information!");
            else
               if (ExistsEmail(_voluntario.Email) != null)
                throw new Exception("Check the Email information!");

            this.Insert(Voluntario);
        }

        public void UpdateVoluntario()
        {
            ValidateVoluntario();
            SetSenha();
            this.Update(Voluntario);
        }

        public void DeleteVoluntario()
        {
            if (!ValidateObjVoluntario())
                throw new Exception("Null Reference of 'IVoluntario' property");

            this.Delete(Voluntario);
        }
        #endregion


    }
}
