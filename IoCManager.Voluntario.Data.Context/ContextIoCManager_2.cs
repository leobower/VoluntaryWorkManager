using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context;

namespace IoCManager.Voluntario.Data.Context
{
    public class ContextIoCManager_2<D, I> : BaseIoCManager<IBaseVoluntarioDbContext<D, I>>
    {
        private readonly string _currentImplementation = "VoluntarioMongoDbContext";
        public IBaseVoluntarioDbContext<D, I> GetIContextCurrentImplementation(string dataBaseName, string collectionName)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
