using System;
using System.Collections.Generic;
using System.Text;

namespace CentralTracer.Model
{
    public class TraceModel : ITraceModel
    {
        private Guid _id;
        private string _requestId;
        private string _startTime;
        private string _endTime;
        private string _className;
        private string _methodName;
        private string _parameters;
        private long _elapsedTime;

        public Guid Id { get => _id; set => _id = value; }
        public string RequestId { get => _requestId; set => _requestId = value; }
        public string StartTime { get => _startTime; set => _startTime = value; }
        public string ClassName { get => _className; set => _className = value; }
        public string MethodName { get => _methodName; set => _methodName = value; }
        public string Parameters { get => _parameters; set => _parameters = value; }
        public string EndTime { get => _endTime; set => _endTime = value; }
        public long ElapsedTime { get => _elapsedTime; set => _elapsedTime = value; }

        public override string ToString()
        {
            return String.Format("StartTime: {0}, RequestId: {1},  Class: {2}, Method: {3}, Parameters: [{4}], EndTime: {5}, Elapsed: {6}ms, Id: {7}", StartTime, RequestId, ClassName, MethodName, Parameters, EndTime, ElapsedTime, Id);
        }

    }
}
