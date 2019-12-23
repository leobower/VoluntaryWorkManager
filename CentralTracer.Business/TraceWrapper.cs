﻿using CentralMQManager;
using CentralTracer.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CentralTracer.Business.Publisher
{
    public class TraceWrapper : BasePublisher, IDisposable
    {
        private bool _disposed = false;
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }


        private ITraceModel _model;
        private Stopwatch _sw;
        private StackFrame _frame;
        private MethodBase _method;


        private string GetParameters(ParameterInfo[] arrParam)
        {
            StringBuilder stb = new StringBuilder();

            if (arrParam != null)
            {
                stb.Append("{");
                for (int i = 0; i < arrParam.Length; i++)
                {
                    stb.Append(string.Format("[Param_{0}] - Name: {1} - Type: {2} - Value: {3}]", i, arrParam[i].Name, arrParam[i].ParameterType.Name, "ds"));
                }
                stb.Append("}");
            }

            return stb.ToString();
        }

        public TraceWrapper()
        {
            base.HostName = "";///TODO
            base.Port = 0;//TODO
            base.QueueName = "";//TODO

            _model = new IoCManager.CentralTrace.Model.CentralTracerModelIoCManager().GetITraceModelCurrentImplementation();
            _frame = new StackFrame(1);
            _method = _frame.GetMethod();

            _model.Id = Guid.NewGuid();
            _model.RequestId = RequestId;
            _model.ClassName = _method.DeclaringType.Name;
            _model.MethodName = _method.Name;
            _model.Parameters = GetParameters(_method.GetParameters());
            _model.StartTime = DateTime.Now.ToString();

            base.Enqueue(_model);
            _sw = Stopwatch.StartNew();
        }

        public void TraceMessage(string format, params object[] args)
        {
            string message = String.Format(format, args);
           // MyEventSourceClass.Log.TraceMessage(message);
        }

        public void Dispose()
        {
            if (!this._disposed)
            {
                this._disposed = true;
                _sw.Stop();
                _model.EndTime = DateTime.Now.ToString();
                _model.ElapsedTime = _sw.ElapsedMilliseconds;
                base.Enqueue(_model);
                // Console.WriteLine(String.Format("EndTime: {0}, RequestId{1},  Class: {2}, Method: {3}, TimeElapsed {4}ms", DateTime.UtcNow, _correlationId, this.className, this.methodName, sw.ElapsedMilliseconds));
                _sw = null;
            }
        }


    }
}
