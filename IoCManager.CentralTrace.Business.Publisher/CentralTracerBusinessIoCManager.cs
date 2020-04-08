using CentralTracer.Business.Publisher;
using CrossCutting.IoCManager.BaseClasses;

namespace CrossCutting.IoCManager.CentralTrace.Business.Publisher
{
    public class CentralTracerBusinessIoCManager : BaseIoCManager<ITracerWrapper>
    {
        private readonly string _currentImplementation = "TracerWrapper";
        public ITracerWrapper GetITraceBusinessCurrentImplementation(string requestId)
        {
            object[] arrParams = new object[] { requestId };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
