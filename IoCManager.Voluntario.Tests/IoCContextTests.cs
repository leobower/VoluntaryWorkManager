using LiteDB;
using MongoDB.Driver;
using NUnit.Framework;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.IoCManager.Tests
{
    public class IoCContextTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestContextInjection()
        {
            IBaseVoluntarioDbContext<LiteDatabase, ILiteCollection<IVoluntario>> obj =
                    new Voluntario.IoCManager.Data.Context.ContextIoCManager<LiteDatabase, ILiteCollection<IVoluntario>>(base.Config).GetIContextCurrentImplementation("VoluntaryWorkManager_TestIoCContext", "VoluntarioCollectionTest");
            //IVoluntarioLiteDbContext obj = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIContextCurrentImplementation("VoluntaryWorkManager_TestIoCContext", "VoluntarioCollectionTest");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();
        }

    }
}