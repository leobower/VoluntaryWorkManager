using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace IocManager.Voluntario
{
    public class VoluntarioQueryIocManager
    {

        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "VoluntarioQuery";

        public IVoluntarioQuery GetCurrentImplementation()
        {
            IVoluntarioQuery obj = null;
            foreach (var type in typeof(IVoluntarioQuery).Assembly.DefinedTypes)
            {
                if(type.IsClass && type.FullName.EndsWith(_currentImplementation))
                {
                    obj = (IVoluntarioQuery)Assembly.Load(typeof(IVoluntarioQuery).Assembly.FullName).CreateInstance(type.FullName);
                    break;
                }
            }
            return obj;
        }


    }
}
