using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace IoCManager.Voluntario.Data.Repository
{
    public class RepositoryWriterTempIoCManager : BaseIoCManager<IRepositoryWriter>
    {
        private readonly string _currentImplementation = "MongoDBVoluntarioWriter"; //
        public IRepositoryWriter GetIRepositoryWriterCurrentImplementation(string dataBaseName, string collectionName)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
