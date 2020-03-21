using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace Tests
{
    public class IoCRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRepositoryWriterInjection()
        {
            IRepositoryWriter obj = new IoCManager.Voluntario.Data.Repository.RepositoryWriterIoCManager().GetIRepositoryWriterCurrentImplementation("Voluntario", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

        [Test]
        public void TestRepositoryQueryInjection()
        {
            IRepositoryQuery obj = new IoCManager.Voluntario.Data.Repository.RepositoryQueryIoCManager().GetIRepositoryQueryCurrentImplementation("Voluntario", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }
    }
}
