using CentralSharedModel.BaseTest;
using CentralSharedModel.Interfaces;
using CrossCutting.IoCManager.SharedModel;
using NUnit.Framework;

namespace CrossCutting.IoCManager.Test
{
    public class IoCSharedoModelTests : BaseTestClass
    {
            [SetUp]
            public void Setup()
            {

            }

            [Test]

            public void TestSharedModelInjection()
            {
                IAddress obj = null;
                obj = new SharedModelIoCManager(base.Config).GetIAddressCurrentImplementation();
                Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
            }

    }
}