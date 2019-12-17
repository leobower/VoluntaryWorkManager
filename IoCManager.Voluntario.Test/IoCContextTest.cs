using CentralSharedModel.Interfaces;
using IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;

namespace Tests
{
    public class IoCContextTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestMongoContextInjection()
        {
            IMongoDbContext obj = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIMongoContextCurrentImplementation();
            Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
        }

    }
}