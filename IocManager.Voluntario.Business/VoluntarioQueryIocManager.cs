﻿using IoCManager.BaseClasses;
using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace IoCManager.Voluntario.Business
{
    public class VoluntarioQueryIocManager : BaseIoCManager<IVoluntarioQuery>
    {

        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "VoluntarioQuery";

        public IVoluntarioQuery GetCurrentIVoluntarioQueryImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }


    }
}