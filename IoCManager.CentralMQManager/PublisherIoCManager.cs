using CentralMQManager;
using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.IoCManager.CentralMQManager
{
    public class PublisherIoCManager : BaseIoCManager<IPublisher>
    {
        public PublisherIoCManager(IConfiguration conf) : base(conf)
        {

        }

        public IPublisher GetIPublisherCurrentImplementation(string current = null)
        {
            return base.GetCurrentImplementation(current);
        }

    }
}
