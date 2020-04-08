using CentralTracer.Model;
using CrossCutting.IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.IoCManager.CentralTrace.Model
{
    public class CentralTracerModelIoCManager : BaseIoCManager<ITraceModel>
    {
        private readonly string _currentImplementation = "TraceModel";
        public ITraceModel GetITraceModelCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
