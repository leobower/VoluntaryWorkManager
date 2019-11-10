using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace IocManager.Voluntario
{
    public class VoluntarioPersistenceIocManager
    {
        private readonly string _currentImplementation = "VoluntarioPersistence";

        public IVoluntarioPersistence GetCurrentImplementation()
        {
            IVoluntarioPersistence obj = null;
            foreach (var type in typeof(IVoluntarioPersistence).Assembly.DefinedTypes)
            {
                if(type.IsClass && type.FullName.EndsWith(_currentImplementation))
                {
                    obj = (IVoluntarioPersistence)Assembly.Load(typeof(IVoluntarioPersistence).Assembly.FullName).CreateInstance(type.FullName);
                    break;
                }
            }
            return obj;
        }


    }
}
