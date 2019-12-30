using CentralMQManager;
using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoCManager.CentralMQManager
{
    public class PublisherIoCManager : BaseIoCManager<IPublisher>
    {
        private readonly string _currentImplementation = "Publisher";
        public IPublisher GetIPublisherCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }

    }
}
