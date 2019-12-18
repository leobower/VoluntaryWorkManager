using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CentralTracer
{
    public class TraceWrapper : IDisposable
    {
        private bool _disposed = false;

        private string _methodName;
        private string _className;

        public TraceWrapper()
        {
            StackFrame frame;
            MethodBase method;

            frame = new StackFrame(1);
            method = frame.GetMethod();
            this._methodName = method.Name;
            this._className = method.DeclaringType.Name;

            //MyEventSourceClass.Log.TraceEnter(this.className, this.methodName);
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
                //MyEventSourceClass.Log.TraceExit(this.className, this.methodName);
            }
        }


    }
}
