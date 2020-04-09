using NUnit.Framework;
using System;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.SerializationManager;

namespace Voluntario.IoCManager.Tests
{
    public class IoCSerializationManagerTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestSerializationManagerInjection()
        {
            try
            {
                ICentralSerializationManager<IVoluntario> obj = null;
                obj = new CrossCutting.IoCManager.Voluntario.SerializationManager.SerializationIoCManager().GetJSonCurrentImplementation();
                Assert.IsTrue(obj != null && obj.GetType().IsClass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
