using IoCManager.BaseClasses;
using System;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDB;

namespace IoCManager.Voluntario.Data.Context
{
    public class ContextIoCManager : BaseIoCManager<IVoluntarioLiteDbContext>
    {
        private readonly string _currentImplementation = "VoluntarioLiteDbContext";
        public IVoluntarioLiteDbContext GetIContextCurrentImplementation(string dataBaseName, string collectionName)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
