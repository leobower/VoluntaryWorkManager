using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Data.Repository.Interfaces;

namespace Voluntario.IoCManager.Data.Repository
{
    public class RepositoryQueryIoCManager : BaseIoCManager<IRepositoryQuery>
    {
        public RepositoryQueryIoCManager(IConfiguration conf) : base(conf) { }
        public IRepositoryQuery GetIRepositoryQueryCurrentImplementation(string dataBaseName, string collectionName, string current = null)
        {
            object[] arrParams = new object[] { dataBaseName, collectionName, base.Config };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }

        public IRepositoryQuery GetIRepositoryQueryCurrentImplementation(object context, string current = null)
        {
            object[] arrParams = new object[] { context, base.Config };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }
    }
}
