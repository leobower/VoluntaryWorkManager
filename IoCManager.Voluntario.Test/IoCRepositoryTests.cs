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
            IRepositoryWriter obj = new IoCManager.Voluntario.Data.Repository.RepositoryWriterIoCManager().GetIRepositoryWriterCurrentImplementation("VoluntaryWorkManager_TestIoCRepository", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

        [Test]
        public void TestRepositoryQueryInjection()
        {
            IRepositoryQuery obj = new IoCManager.Voluntario.Data.Repository.RepositoryQueryIoCManager().GetIRepositoryQueryCurrentImplementation("VoluntaryWorkManager_TestIoCRepository", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

        [Test]
        public void TestRepositoryWriterInjection2()
        {
            IRepositoryWriter obj = new IoCManager.Voluntario.Data.Repository.RepositoryWriterTempIoCManager().GetIRepositoryWriterCurrentImplementation("VoluntaryWorkManager_TestIoCRepository", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

        [Test]
        public void TestRepositoryQueryInjection2()
        {
            IRepositoryQuery obj = new IoCManager.Voluntario.Data.Repository.RepositoryTempIoCManager().GetIRepositoryQueryCurrentImplementation("VoluntaryWorkManager_TestIoCRepository", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }
    }
}
