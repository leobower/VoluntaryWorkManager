using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.IoCManager.Business
{
    public class VoluntarioQueryIocManager : BaseIoCManager<IVoluntarioQuery>
    {

        public VoluntarioQueryIocManager(IConfiguration conf) : base(conf) { }

        public IVoluntarioQuery GetCurrentIVoluntarioQueryImplementation(string current = null)
        {
            return base.GetCurrentImplementation(current);
        }

    }
}
