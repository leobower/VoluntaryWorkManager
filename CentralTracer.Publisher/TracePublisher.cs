using CentralMQManager;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralTracer.Publisher
{
    public class TracePublisher : BasePublisher
    {
        public void Publish(object model)
        {
            base.Enqueue(model);
        }
    }
}
