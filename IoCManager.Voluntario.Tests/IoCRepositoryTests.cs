using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace Voluntario.IoCManager.Tests
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
            IRepositoryWriter obj = new Voluntario.IoCManager.Data.Repository.RepositoryWriterIoCManager().GetIRepositoryWriterCurrentImplementation("VoluntaryWorkManager_TestIoCRepository", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

        [Test]
        public void TestRepositoryQueryInjection()
        {
            IRepositoryQuery obj = new Voluntario.IoCManager.Data.Repository.RepositoryQueryIoCManager().GetIRepositoryQueryCurrentImplementation("VoluntaryWorkManager_TestIoCRepository", "VoluntarioCollection");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

       
    }
}
