using CentralSharedModel.BaseTest;
using CrossCutting.IoCManager.Voluntario.Application;
using CrossCutting.IoCManager.Voluntario.Application.Persistence;
using CrossCutting.IoCManager.Voluntario.Application.Query;
using NUnit.Framework;
using System;
using Voluntario.Application.Persistence;
using Voluntario.Application.Query;
using Voluntario.Domain.Entities.Interfaces;

namespace CrossCutting.IoCManager.Test
{
    public class IoCVoluntarioApplicationTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestApplicationPersistenceInjection()
        {
            IPersistenceApplication persistenceApp = null;
            PersistenceApplicationIoCManager ioc = new PersistenceApplicationIoCManager(base.Config);

            persistenceApp = ioc.GetCurrentIPersistenceApplicationImplementation();

            Assert.IsNotNull(persistenceApp);

            Assert.IsTrue(persistenceApp.GetType().IsClass);
            persistenceApp.Dispose();
        }

        [Test]
        public void TestApplicationQueryInjection()
        {
            IQueryApplication app = null;
            QueryApplicationIoCManager ioc = new QueryApplicationIoCManager(base.Config);

            app = ioc.GetCurrentIQueryApplicationImplementation();

            Assert.IsNotNull(app);

            Assert.IsTrue(app.GetType().IsClass);
            app.Dispose();
        }

    }
}