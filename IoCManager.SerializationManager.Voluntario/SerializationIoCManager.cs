using CrossCutting.IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.SerializationManager;

namespace Voluntario.IoCManager.SerializationManager
{
    public class SerializationIoCManager : BaseIoCManager<ICentralSerializationManager<IVoluntario>>
    {
        private readonly string _currentIAdressImplementation = "CentralSerializationManager";

        public ICentralSerializationManager<IVoluntario> GetISerializationCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentIAdressImplementation);
        }
    }
}
