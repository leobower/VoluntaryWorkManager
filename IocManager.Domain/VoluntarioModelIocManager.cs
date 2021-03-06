﻿using System.Reflection;
using Voluntario.Domain.Entities.Interfaces;

namespace IocManager.Voluntario
{
    public class VoluntarioModelIocManager
    {

        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "Voluntario";

        public IVoluntario GetCurrentImplementation()
        {
            IVoluntario obj = null;
            foreach (var type in typeof(IVoluntario).Assembly.DefinedTypes)
            {
                if(type.IsClass && type.FullName.EndsWith(_currentImplementation))
                {
                    obj = (IVoluntario)Assembly.Load(typeof(IVoluntario).Assembly.FullName).CreateInstance(type.FullName);
                    break;
                }
            }
            return obj;
        }


    }
}
