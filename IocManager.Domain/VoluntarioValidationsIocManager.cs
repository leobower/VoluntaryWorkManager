using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;

namespace IocManager.Voluntario
{
    public class VoluntarioValidationsIocManager
    {
        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "VoluntarioValidations";

        public IVoluntarioValidations GetCurrentImplementation()
        {
            IVoluntarioValidations obj = null;
            foreach (var type in typeof(IVoluntarioValidations).Assembly.DefinedTypes)
            {
                if (type.IsClass && type.FullName.EndsWith(_currentImplementation))
                {
                    obj = (IVoluntarioValidations)Assembly.Load(typeof(IVoluntarioValidations).Assembly.FullName).CreateInstance(type.FullName);
                    break;
                }
            }
            return obj;
        }
    }
}
