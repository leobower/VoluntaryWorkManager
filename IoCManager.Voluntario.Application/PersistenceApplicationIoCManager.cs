using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using Voluntario.Application.Persistence;

namespace CrossCutting.IoCManager.Voluntario.Application.Persistence
{
    public class PersistenceApplicationIoCManager : BaseIoCManager<IPersistenceApplication>
    {
        public PersistenceApplicationIoCManager(IConfiguration conf) : base(conf)
        {

        }

        public IPersistenceApplication GetCurrentIPersistenceApplicationImplementation(string current = null)
        {
            object[] arrParams = new object[] { base.Config};
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }       
    }
}
