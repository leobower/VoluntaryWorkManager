using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;

namespace IocManager.Voluntario
{
    public class VoluntarioPersistenceIocManager
    {
        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
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
