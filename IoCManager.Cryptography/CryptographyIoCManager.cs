using CrossCutting.IoCManager.BaseClasses;
using Cryptography;
using Microsoft.Extensions.Configuration;

namespace CrossCutting.IoCManager.Cryptography
{
    public class CryptographyIoCManager : BaseIoCManager<ICryptography>
    {
        public CryptographyIoCManager(IConfiguration conf) : base(conf)
        {

        }

        public ICryptography GetICryptographyCurrentImplementation(string current = null)
        {
            return base.GetCurrentImplementation(current);
        }
    }
}
