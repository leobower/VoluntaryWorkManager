using IoCManager.Voluntario.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class IoCVoluntarioModelTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestVoluntarioModelInjection()
        {
            IVoluntario voluntario = null;
            ModelIoCManager iocManager = new ModelIoCManager();
            voluntario = iocManager.GetIVoluntarioCurrentImplementation();

            Assert.IsNotNull(voluntario);

            Assert.IsTrue(voluntario.GetType().IsClass);

        }

    }
}