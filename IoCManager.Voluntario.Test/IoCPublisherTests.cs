using System;
using System.Collections.Generic;
using System.Text;
using CentralMQManager;
using CentralSharedModel.BaseTest;
using NUnit.Framework;

namespace CrossCutting.IoCManager.Test
{
    public class IoCPublisherTests : BaseTestClass
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
                IPublisher obj = new CrossCutting.IoCManager.CentralMQManager.PublisherIoCManager(base.Config).GetIPublisherCurrentImplementation();
                Assert.IsTrue(obj != null && obj.GetType().IsClass);

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

    }
}
