using CentralMQManager;
using CentralSharedModel.Interfaces;
using CentralTracer.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;

namespace CentralTracer.Business.Publisher
{
    public class TracerWrapper : IRequest, ITracerWrapper
    {
        private bool _disposed = false;
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }
        public ITraceModel Model { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IConfiguration Config { get; set; }

        private ITraceModel _model;
        private Stopwatch _sw;
        private StackFrame _frame;
        private MethodBase _method;

        private IPublisher _publisher;


        private void GetConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = "";
            path = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
            Console.WriteLine("===================================" + File.Exists(path).ToString());
            if (File.Exists(path))
            {
                Console.WriteLine("************************** PATH: " + path + "******************************************************");
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                Config = root;
            }
            else
            {
                Console.WriteLine(path + " NOOOOOOOOT EXXXISTS");
                throw new FileNotFoundException(path);
            }
        }


        private void InitializeObjects(string requestId)
        {
            GetConfiguration();
            _publisher = new CrossCutting.IoCManager.CentralMQManager.PublisherIoCManager(Config).GetIPublisherCurrentImplementation();

            _publisher.HostName = Config["MQHostName"];
            _publisher.Port = int.Parse(Config["MQPort"]);//TODO
            _publisher.QueueName = Config["MQQueueName"];
            RequestId = requestId;

            _model = new CrossCutting.IoCManager.CentralTrace.Model.CentralTracerModelIoCManager(Config).GetITraceModelCurrentImplementation();
            _frame = new StackFrame(1);
            _method = _frame.GetMethod();

            _model.Id = Guid.NewGuid();
            _model.RequestId = RequestId;
            _model.ClassName = _method.DeclaringType.Name;
            _model.MethodName = _method.Name;
            _model.Parameters = GetParameters(_method.GetParameters());
            _model.StartTime = DateTime.Now.ToString();
            _model.ElapsedTime = 0;
            _model.EndTime = null;

            _publisher.Enqueue(_model.ToString());
            _sw = Stopwatch.StartNew();
        }

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

        public TracerWrapper()
        {
            InitializeObjects(null);
        }


        public TracerWrapper(string requestId)
        {
            InitializeObjects(requestId);
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
                _publisher.Enqueue(_model.ToString());
                // Console.WriteLine(String.Format("EndTime: {0}, RequestId{1},  Class: {2}, Method: {3}, TimeElapsed {4}ms", DateTime.UtcNow, _correlationId, this.className, this.methodName, sw.ElapsedMilliseconds));
                _sw = null;
                _publisher = null;
            }
        }


    }
}
    