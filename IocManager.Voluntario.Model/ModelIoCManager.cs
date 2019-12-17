using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace IoCManager.Voluntario.Model
{
    public class ModelIoCManager :BaseIoCManager<IVoluntario>
    {
        private readonly string _currentImplementation = "Voluntario";
        public IVoluntario GetIVoluntarioCurrentImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
