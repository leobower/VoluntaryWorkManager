using CentralSharedModel.BaseTest;
using CentralSharedModel.Interfaces;
using CentralTracer.Model;
using CrossCutting.IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;

namespace CrossCutting.IoCManager.Test
{
    public class IoCTracerModelTests : BaseTestClass
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
                ITraceModel obj = new CrossCutting.IoCManager.CentralTrace.Model.CentralTracerModelIoCManager(base.Config).GetITraceModelCurrentImplementation();
                Assert.IsTrue(obj != null && obj.GetType().IsClass);

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

    }
}