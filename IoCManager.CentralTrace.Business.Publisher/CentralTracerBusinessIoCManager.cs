using CentralTracer.Business.Publisher;
using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;

namespace CrossCutting.IoCManager.CentralTrace.Business.Publisher
{
    public class CentralTracerBusinessIoCManager : BaseIoCManager<ITracerWrapper>
    {
        public CentralTracerBusinessIoCManager(IConfiguration conf) : base(conf)
        {

        }
        public ITracerWrapper GetITraceBusinessCurrentImplementation(string requestId, string current = null)
        {
            object[] arrParams = new object[] { requestId };
            return base.GetCurrentImplementationWithParameters(arrParams, current);
        }
    }
}
