using NUnit.Framework;
using Cryptography;
using System;
using CentralSharedModel.BaseTest;

namespace CryprographyTests
{
    public class CryptoTest : BaseTestClass
    {
        private ICryptography _customCrypto;

        [SetUp]
        public void Setup()
        {
            _customCrypto = new CrossCutting.IoCManager.Cryptography.CryptographyIoCManager(base.Config).GetICryptographyCurrentImplementation();
        }

        [Test]
        public void Encrypt()
        {
            string value = @"123456789";
            string valueEncrypted = _customCrypto.Encrypt(value);
            Assert.IsTrue(!valueEncrypted.Equals(value));
        }

        [Test]
        public void Decrypt()
        {
            string value = @"12345678";

            string valueEncrypted = _customCrypto.Encrypt(value);
            string valueDecrypted = _customCrypto.Decrypt(valueEncrypted);

            Assert.IsTrue(valueDecrypted.Equals(value));
        }
    }
}