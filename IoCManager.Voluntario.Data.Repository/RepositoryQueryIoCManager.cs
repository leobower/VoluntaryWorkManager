using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace IoCManager.Voluntario.Data.Repository
{
    public class RepositoryQueryIoCManager : BaseIoCManager<IRepositoryQuery>
    {
        private readonly string _currentImplementation = "LiteDBVoluntarioQuery"; //
        public IRepositoryQuery GetIRepositoryQueryCurrentImplementation(string dataBaseName, string collectionName)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
