using Voluntario.IoCManager.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using System;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.IoCManager.Tests
{
    public class IoCVoluntarioModelTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestVoluntarioModelInjection()
        {
            IVoluntario voluntario = null;
            ModelIoCManager iocManager = new ModelIoCManager(base.Config);
            voluntario = iocManager.GetIVoluntarioCurrentImplementation();

            Assert.IsNotNull(voluntario);

            Assert.IsTrue(voluntario.GetType().IsClass);

        }

    }
}