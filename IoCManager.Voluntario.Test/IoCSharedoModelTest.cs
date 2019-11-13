using CentralSharedModel.Interfaces;
using IocManager.Voluntario;
using IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class IoCSharedoModelTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestSharedModelInjection()
        {
            IAddress obj = null;
            obj = new SharedModelIoCManager().GetIAddressCurrentImplementation();
            Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
        }

    }
}