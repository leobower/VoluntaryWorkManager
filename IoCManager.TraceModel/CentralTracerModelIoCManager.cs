using CentralTracer.Model;
using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.IoCManager.CentralTrace.Model
{
    public class CentralTracerModelIoCManager : BaseIoCManager<ITraceModel>
    {
        public CentralTracerModelIoCManager(IConfiguration conf) : base(conf)
        {

        }
        public ITraceModel GetITraceModelCurrentImplementation(string current = null)
        {
            return base.GetCurrentImplementation(current);
        }
    }
}
