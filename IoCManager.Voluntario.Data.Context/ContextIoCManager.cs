using IoCManager.BaseClasses;
using System;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;

namespace IoCManager.Voluntario.Data.Context
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
