using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;

namespace Voluntario.IoCManager.Tests
{
    public class IoCRepositoryTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestRepositoryWriterInjection()
        {
            string connStr = base.Config["ConnectionString"];
            string dataBase = base.Config["DataBaseName"];
            string collection = base.Config["CollectionName"];

            IRepositoryWriter obj = new Voluntario.IoCManager.Data.Repository.RepositoryWriterIoCManager(base.Config)
                .GetIRepositoryWriterCurrentImplementation(connStr, dataBase);
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

        [Test]
        public void TestRepositoryQueryInjection()
        {
            string connStr = base.Config["ConnectionString"];
            string dataBase = base.Config["DataBaseName"];
            string collection = base.Config["CollectionName"];

            IRepositoryQuery obj = new Voluntario.IoCManager.Data.Repository.RepositoryQueryIoCManager(base.Config)
                .GetIRepositoryQueryCurrentImplementation(connStr, dataBase);
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();

        }

       
    }
}
