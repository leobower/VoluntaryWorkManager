using CentralSharedModel.Interfaces;
using Cryptography;
using CrossCutting.IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;
using CentralSharedModel.BaseTest;

namespace CrossCutting.IoCManager.Test
{
    public class IoCCCryptographyTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void TestCryptographyInjection()
        {
            ICryptography obj = new CrossCutting.IoCManager.Cryptography.CryptographyIoCManager(base.Config).GetICryptographyCurrentImplementation();
            Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
        }

    }
}