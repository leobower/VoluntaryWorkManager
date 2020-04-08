using CrossCutting.IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace Voluntario.IoCManager.Data.Repository
{
    public class RepositoryWriterIoCManager : BaseIoCManager<IRepositoryWriter>
    {
        private readonly string _currentImplementation = "LiteDBVoluntarioWriter"; //
        public IRepositoryWriter GetIRepositoryWriterCurrentImplementation(string dataBaseName, string collectionName)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
