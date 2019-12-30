using CentralSharedModel.Interfaces;
using IoCManager.SharedModel;
using NUnit.Framework;

namespace Tests
{
    public class IoCSharedoModelTests
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