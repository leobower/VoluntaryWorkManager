using System;
using System.Collections.Generic;
using System.Text;

namespace CentralTracer
{
    public interface ITracerWrapper : IDisposable
    {
        void TraceMessage(string format, params object[] args);
    }
}
