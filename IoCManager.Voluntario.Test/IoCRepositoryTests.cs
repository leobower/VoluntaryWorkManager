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
        public void TestRepositoryInjection()
        {
            IRepositoryWriter obj = new IoCManager.Voluntario.Data.Repository.RepositoryIoCManager().GetIMongoRepositoryCurrentImplementation();
            Assert.IsTrue(obj != null && obj.GetType().IsClass);

        }
    }
}
