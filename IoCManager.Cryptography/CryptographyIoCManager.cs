using Cryptography;
using IoCManager.BaseClasses;
using System;

namespace IoCManager.Cryptography
{
    public class CryptographyIoCManager : BaseIoCManager<ICryptography>
    {
        private readonly string _currentIAdressImplementation = "CustomCrypto";

        public ICryptography GetICryptographyCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentIAdressImplementation);
        }
    }
}
