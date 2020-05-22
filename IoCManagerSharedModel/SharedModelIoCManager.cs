using CentralSharedModel.Interfaces;
using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;

namespace CrossCutting.IoCManager.SharedModel
{
    public  class SharedModelIoCManager : BaseIoCManager<IAddress>
    {
        public SharedModelIoCManager(IConfiguration conf) : base(conf)
        {

        }

        public  IAddress GetIAddressCurrentImplementation(string current = null) 
        {
            return base.GetCurrentImplementation(current);
        }
    }
}
