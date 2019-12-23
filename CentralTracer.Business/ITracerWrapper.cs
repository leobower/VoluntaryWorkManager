using CentralTracer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralTracer.Business.Publisher
{
    public interface ITracerWrapper : IDisposable
    {
        ITraceModel Model { get; set; }


        void TraceMessage(string format, params object[] args);
    }
}
