using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace IoCManager.Voluntario.Data.Repository
{
    public class RepositoryIoCManager : BaseIoCManager<IRepositoryWriter>
    {
        private readonly string _currentImplementation = "MongoRepositoryWriter"; //
        public IRepositoryWriter GetIMongoRepositoryCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
