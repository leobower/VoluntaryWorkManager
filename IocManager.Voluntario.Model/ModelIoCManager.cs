﻿using CrossCutting.IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.IoCManager.Model
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
