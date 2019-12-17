using IoCManager.BaseClasses;
using System;
using Voluntario.Data.Context;

namespace IoCManager.Voluntario.Data.Context
{
    public class ContextIoCManager : BaseIoCManager<IMongoDbContext>
    {
        private readonly string _currentImplementation = "MongoDbContext";
        public IMongoDbContext GetIMongoContextCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
