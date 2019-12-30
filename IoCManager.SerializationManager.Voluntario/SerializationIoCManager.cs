using IoCManager.BaseClasses;
using SerializationManager.Voluntario;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace IoCManager.SerializationManager.Voluntario
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
