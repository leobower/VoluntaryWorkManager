using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;

namespace Voluntario.IoCManager.Business
{
    public class VoluntarioPersistenceIocManager : BaseIoCManager<IVoluntarioPersistence>
    {
        public VoluntarioPersistenceIocManager(IConfiguration conf) : base(conf) { }

        public IVoluntarioPersistence GetCurrentIVoluntarioPersitenceImplementation(string current = null)
        {
            return base.GetCurrentImplementation(current);
        }


    }
}
