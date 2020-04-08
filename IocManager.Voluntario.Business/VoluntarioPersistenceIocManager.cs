using CrossCutting.IoCManager.BaseClasses;
using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;

namespace Voluntario.IoCManager.Business
{
    public class VoluntarioPersistenceIocManager : BaseIoCManager<IVoluntarioPersistence>
    {
        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "VoluntarioPersistence";

        public IVoluntarioPersistence GetCurrentIVoluntarioPersitenceImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }


    }
}
