using CentralSharedModel.Interfaces;
using IoCManager.SharedModel;
using LiteDB;
using NUnit.Framework;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class IoCContextTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestContextInjection()
        {
            IBaseVoluntarioDbContext<LiteDatabase, ILiteCollection<IVoluntario>> obj =
                    new IoCManager.Voluntario.Data.Context.ContextIoCManager<LiteDatabase, ILiteCollection<IVoluntario>>().GetIContextCurrentImplementation("VoluntaryWorkManager_TestIoCContext", "VoluntarioCollectionTest");
            //IVoluntarioLiteDbContext obj = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIContextCurrentImplementation("VoluntaryWorkManager_TestIoCContext", "VoluntarioCollectionTest");
            Assert.IsTrue(obj != null && obj.GetType().IsClass);
            obj.Dispose();
        }

    }
}