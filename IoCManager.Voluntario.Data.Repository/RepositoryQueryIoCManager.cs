using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace IoCManager.Voluntario.Data.Repository
{
    public class RepositoryQueryIoCManager : BaseIoCManager<IRepositoryQuery>
    {
        private readonly string _currentImplementation = "MongoRepositoryQuery"; //
        public IRepositoryQuery GetIMongoRepositoryQueryCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
