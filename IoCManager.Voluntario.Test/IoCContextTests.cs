using CentralSharedModel.Interfaces;
using IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;
using Voluntario.Data.Context.LiteDB;

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
            IVoluntarioLiteDbContext obj = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIContextCurrentImplementation("VoluntarioDBTest","VoluntarioCollectionTest");
            Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
            obj.Dispose();
        }

    }
}