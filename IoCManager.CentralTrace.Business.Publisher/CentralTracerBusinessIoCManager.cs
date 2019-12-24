using CentralTracer.Business.Publisher;
using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCManager.CentralTrace.Business.Publisher
{
    public class CentralTracerBusinessIoCManager : BaseIoCManager<ITracerWrapper>
    {
        private readonly string _currentImplementation = "TracerWrapper";
        public ITracerWrapper GetITraceBusinessCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
