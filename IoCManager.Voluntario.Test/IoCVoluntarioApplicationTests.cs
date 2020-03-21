using IoCManager.Voluntario.Application;
using IoCManager.Voluntario.Application.Persistence;
using IoCManager.Voluntario.Application.Query;
using NUnit.Framework;
using System;
using Voluntario.Application.Persistence;
using Voluntario.Application.Query;
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
            persistenceApp = ioc.GetCurrentIPersistenceApplicationImplementation("localhost", "VoluntaryWorkManager", "Voluntario");

            Assert.IsNotNull(persistenceApp);

            Assert.IsTrue(persistenceApp.GetType().IsClass);
            persistenceApp.Dispose();
        }

        [Test]
        public void TestApplicationQueryInjection()
        {
            IQueryApplication app = null;
            QueryApplicationIoCManager ioc = new QueryApplicationIoCManager();
            app = ioc.GetCurrentIQueryApplicationImplementation("localhost", "VoluntaryWorkManager", "Voluntario");

            Assert.IsNotNull(app);

            Assert.IsTrue(app.GetType().IsClass);
            app.Dispose();
        }

    }
}