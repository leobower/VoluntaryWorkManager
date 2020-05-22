using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace Voluntario.IoCManager.Data.Repository
{
    public class RepositoryWriterIoCManager : BaseIoCManager<IRepositoryWriter>
    {
        public RepositoryWriterIoCManager(IConfiguration conf) : base(conf) { }
        public IRepositoryWriter GetIRepositoryWriterCurrentImplementation(string dataBaseName, string collectionName, string current = null)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName, base.Config };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }
    }
}
