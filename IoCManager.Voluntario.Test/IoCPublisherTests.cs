using System;
using System.Collections.Generic;
using System.Text;
using CentralMQManager;
using NUnit.Framework;

namespace Tests
{
    public class IoCPublisherTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestPublisherlInjection()
        {
            try
            {
                IPublisher obj = new IoCManager.CentralMQManager.PublisherIoCManager().GetIPublisherCurrentImplementation();
                Assert.IsTrue(obj != null && obj.GetType().IsClass);

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

    }
}
