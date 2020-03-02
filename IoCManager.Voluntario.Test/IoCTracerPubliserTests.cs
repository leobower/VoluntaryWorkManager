using CentralTracer.Business.Publisher;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class IoCTracerPubliserTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestTracerInjectionNoParameters()
        {
            ITracerWrapper obj;
            try
            {
                obj = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(Guid.NewGuid().ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
        }
    }
}
