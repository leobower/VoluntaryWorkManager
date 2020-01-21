using IoCManager.Voluntario.Application;
using NUnit.Framework;
using System;
using Voluntario.Application;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class IoCVoluntarioApplicationTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestApplicationPersistenceInjection()
        {
            IPersistenceApplication persistenceApp = null;
            PersistenceApplicationIoCManager ioc = new PersistenceApplicationIoCManager();
            persistenceApp = ioc.GetCurrentIPersistenceApplicationImplementation();

            Assert.IsNotNull(persistenceApp);

            Assert.IsTrue(persistenceApp.GetType().IsClass);

        }

        [Test]
        public void TestApplicationQueryInjection()
        {
            IQueryApplication app = null;
            QueryApplicationIoCManager ioc = new QueryApplicationIoCManager();
            app = ioc.GetCurrentIQueryApplicationImplementation();

            Assert.IsNotNull(app);

            Assert.IsTrue(app.GetType().IsClass);

        }

    }
}