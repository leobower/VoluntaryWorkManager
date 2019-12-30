using NUnit.Framework;
using SerializationManager.Voluntario;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
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
                obj = new IoCManager.SerializationManager.Voluntario.SerializationIoCManager().GetISerializationCurrentImplementation();
                Assert.IsTrue(obj != null && obj.GetType().IsClass);
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
