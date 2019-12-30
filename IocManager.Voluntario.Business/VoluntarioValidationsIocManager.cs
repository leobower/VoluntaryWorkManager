﻿using IoCManager.BaseClasses;
using System.Reflection;
using Voluntario.Domain.BusinessRules.Interfaces;

namespace IoCManager.Voluntario.Business
{
    public class VoluntarioValidationsIocManager : BaseIoCManager<IVoluntarioValidations>
    {
        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "VoluntarioValidations";

        public IVoluntarioValidations GetCurrentIVoluntarioValidationsImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}