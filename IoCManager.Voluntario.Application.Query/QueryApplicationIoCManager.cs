using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using Voluntario.Application.Query;

namespace CrossCutting.IoCManager.Voluntario.Application.Query
{
    public class QueryApplicationIoCManager : BaseIoCManager<IQueryApplication>
    {
        public QueryApplicationIoCManager(IConfiguration conf) : base(conf)
        {

        }

        public IQueryApplication GetCurrentIQueryApplicationImplementation(string current = null)
        {
            object[] arrParams = new object[] { base.Config };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }

        public IQueryApplication GetCurrentIQueryApplicationImplementation(object context, string current = null)
        {
            object[] arrParams = new object[] { context, base.Config };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }
    }
}
