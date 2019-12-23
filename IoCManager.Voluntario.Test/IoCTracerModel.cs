using CentralSharedModel.Interfaces;
using CentralTracer.Model;
using IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;

namespace Tests
{
    public class IoCTracerModel
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestTracerModelInjection()
        {
            ITraceModel obj = new IoCManager.CentralTrace.Model.CentralTracerModelIoCManager().GetITraceModelCurrentImplementation();
            Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
        }

    }
}