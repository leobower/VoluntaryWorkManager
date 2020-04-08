using CrossCutting.IoCManager.BaseClasses;
using Cryptography;

namespace CrossCutting.IoCManager.Cryptography
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
