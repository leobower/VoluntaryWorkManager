using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;

namespace Voluntario.IoCManager.Business
{
    public class VoluntarioValidationsIocManager : BaseIoCManager<IVoluntarioValidations>
    {
        public VoluntarioValidationsIocManager(IConfiguration conf) : base(conf) { }

        public IVoluntarioValidations GetCurrentIVoluntarioValidationsImplementation(string current = null)
        {
            return base.GetCurrentImplementation(current);
        }
    }
}
