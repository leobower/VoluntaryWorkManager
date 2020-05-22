using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using Voluntario.Data.Context;

namespace Voluntario.IoCManager.Data.Context
{
    public class ContextIoCManager<D,I> : BaseIoCManager<IBaseVoluntarioDbContext<D,I>>
    {
       
        public ContextIoCManager(IConfiguration conf) : base(conf) { }


        public IBaseVoluntarioDbContext<D, I> GetIContextCurrentImplementation(string dataBaseName, string collectionName, string current = null)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }
    }
}
