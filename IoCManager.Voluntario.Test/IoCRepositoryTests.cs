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
            IRepositoryWriter obj = new IoCManager.Voluntario.Data.Repository.RepositoryWriterIoCManager().GetIMongoRepositoryWriterCurrentImplementation();
            Assert.IsTrue(obj != null && obj.GetType().IsClass);

        }

        [Test]
        public void TestRepositoryQueryInjection()
        {
            IRepositoryQuery obj = new IoCManager.Voluntario.Data.Repository.RepositoryQueryIoCManager().GetIMongoRepositoryQueryCurrentImplementation();
            Assert.IsTrue(obj != null && obj.GetType().IsClass);

        }
    }
}
