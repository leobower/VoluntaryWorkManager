using CrossCutting.IoCManager.BaseClasses;
using Voluntario.Data.Context;

namespace Voluntario.IoCManager.Data.Context
{
    public class ContextIoCManager<D,I> : BaseIoCManager<IBaseVoluntarioDbContext<D,I>>
    {
        private readonly string _currentImplementation = "VoluntarioLiteDbContext";
        public IBaseVoluntarioDbContext<D, I> GetIContextCurrentImplementation(string dataBaseName, string collectionName)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
