using NUnit.Framework;
using Cryptography;
using System;

namespace CryprographyTests
{
    public class CryptoTest
    {
        private ICryptography _customCrypto;

        [SetUp]
        public void Setup()
        {
            _customCrypto = new IoCManager.Cryptography.CryptographyIoCManager().GetICryptographyCurrentImplementation();
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

            Assert.IsTrue(valueEncrypted.Equals(value));
        }
    }
}