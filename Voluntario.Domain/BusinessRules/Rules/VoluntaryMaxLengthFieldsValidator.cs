using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Domain.BusinessRules.Rules
{
    public class VoluntaryMaxLengthFieldsValidator
    {
        private IVoluntario _volunt;

        public IVoluntario Volunt { get => _volunt; set => _volunt = value; }

        internal VoluntaryMaxLengthFieldsValidator()
        {
            
        }

        internal bool IdValidator()
        {
            bool ret = false;
            if(_volunt != null)
            {
                Guid guid;
                ret = Guid.TryParse(_volunt.Id,out guid);
                if(ret)
                {
                    var att = typeof(IVoluntario).GetTypeInfo().GetProperty("Id").GetCustomAttribute<CustomMaxLength>();
                    ret = _volunt.Id.Length.Equals(att.MaxLength);
                }
            }

            return ret;
        }

        internal bool CpfValidator()
        {
            bool ret = false;
            if (_volunt != null)
            {
                var att = typeof(IVoluntario).GetTypeInfo().GetProperty("Cpf").GetCustomAttribute<CustomMaxLength>();
                ret = _volunt.Cpf.ToString().Length.Equals(att.MaxLength);
            }

            return ret;
        }

        internal bool CepValidator()
        {
            bool ret = false;
            if (_volunt != null)
            {
                var att = typeof(IVoluntario).GetTypeInfo().GetProperty("Cep").GetCustomAttribute<CustomMaxLength>();
                ret = _volunt.Cep.Length.Equals(att.MaxLength);
            }

            return ret;
        }

        internal bool SenhaValidator()
        {
            bool ret = false;
            if (_volunt != null)
            {
                var att = typeof(IVoluntario).GetTypeInfo().GetProperty("Senha").GetCustomAttribute<CustomMaxLength>();
                ret = _volunt.Senha.Length >= att.MinLength && _volunt.Senha.Length <= att.MaxLength;
            }

            return ret;
        }

       


    }
}
