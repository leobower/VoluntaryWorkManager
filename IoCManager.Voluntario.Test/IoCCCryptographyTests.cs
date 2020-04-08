using CentralSharedModel.Interfaces;
using Cryptography;
using CrossCutting.IoCManager.SharedModel;
using NUnit.Framework;
using Voluntario.Data.Context;

namespace CrossCutting.IoCManager.Test
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
            ICryptography obj = new CrossCutting.IoCManager.Cryptography.CryptographyIoCManager().GetICryptographyCurrentImplementation();
            Assert.IsTrue(obj != null &&  obj.GetType().IsClass);
        }

    }
}