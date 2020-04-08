using CentralSharedModel.Interfaces;
using CentralTracer.Model;
using CrossCutting.IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;

namespace CrossCutting.IoCManager.Test
{
    public class IoCTracerModelTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestTracerModelInjection()
        {
            try
            {
                ITraceModel obj = new CrossCutting.IoCManager.CentralTrace.Model.CentralTracerModelIoCManager().GetITraceModelCurrentImplementation();
                Assert.IsTrue(obj != null && obj.GetType().IsClass);

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

    }
}