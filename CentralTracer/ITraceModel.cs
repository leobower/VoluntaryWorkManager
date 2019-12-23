using System;
using System.Collections.Generic;
using System.Text;

namespace CentralTracer.Model
{
    public interface ITraceModel
    {
        Guid Id { get; set; }
        string RequestId { get; set; }
        string StartTime { get; set; }
        string EndTime { get; set; }
        string ClassName { get; set; }
        string MethodName { get; set; }
        string Parameters { get; set; }
        long ElapsedTime { get; set; }
    }
}
