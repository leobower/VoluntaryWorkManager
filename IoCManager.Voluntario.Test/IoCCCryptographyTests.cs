using CentralSharedModel.Interfaces;
using Cryptography;
using IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;

namespace Tests
{
    public class IoCCCryptographyTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCryptographyInjection()
        {
            ICryptography obj = new IoCManager.Cryptography.CryptographyIoCManager().GetICryptographyCurrentImplementation();
            Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
        }

    }
}