using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.SerializationManager;

namespace CrossCutting.IoCManager.Voluntario.SerializationManager
{
    public class SerializationIoCManager : BaseIoCManager<ICentralSerializationManager<IVoluntario>>
    {
        public SerializationIoCManager(IConfiguration conf) : base(conf) { }

        public ICentralSerializationManager<IVoluntario> GetJSonCurrentImplementation(string current = null)
        {
            object[] arrParams = new object[] { base.Config };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }
    }
}
