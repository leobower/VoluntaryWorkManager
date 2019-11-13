using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace IoCManager.SharedModel
{
    public  class SharedModelIoCManager
    {
        private  readonly string _currentIAdressImplementation = "Address";

        public  IAddress GetIAddressCurrentImplementation()
        {
            IAddress obj = null;
            foreach (var type in typeof(IAddress).Assembly.DefinedTypes)
            {
                if (type.IsClass && type.FullName.EndsWith(_currentIAdressImplementation))
                {
                    obj = (IAddress)Assembly.Load(typeof(IAddress).Assembly.FullName).CreateInstance(type.FullName);
                    break;
                }
            }
            return obj;
        }
    }
}
