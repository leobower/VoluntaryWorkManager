using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Application;

namespace IoCManager.Voluntario.Application
{
    public class PersistenceApplicationIoCManager : BaseIoCManager<IPersistenceApplication>
    {
        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "PersistenceApplication";

        public IPersistenceApplication GetCurrentIPersistenceApplicationImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
