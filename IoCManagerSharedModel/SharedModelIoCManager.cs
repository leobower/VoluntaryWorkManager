using CentralSharedModel.Interfaces;
using CrossCutting.IoCManager.BaseClasses;

namespace CrossCutting.IoCManager.SharedModel
{
    public  class SharedModelIoCManager : BaseIoCManager<IAddress>
    {
        private  readonly string _currentIAdressImplementation = "Address";

        public  IAddress GetIAddressCurrentImplementation() 
        {
            return base.GetCurrentImplementation(_currentIAdressImplementation);
        }
    }
}
