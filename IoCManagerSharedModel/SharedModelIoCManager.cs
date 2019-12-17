using CentralSharedModel.Interfaces;
using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IoCManager.SharedModel
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
