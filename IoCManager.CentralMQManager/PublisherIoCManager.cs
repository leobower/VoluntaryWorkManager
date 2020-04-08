using CentralMQManager;
using CrossCutting.IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.IoCManager.CentralMQManager
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
