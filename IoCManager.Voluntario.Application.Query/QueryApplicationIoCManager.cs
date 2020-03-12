using IoCManager.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Application;
using Voluntario.Application.Query;

namespace IoCManager.Voluntario.Application.Query
{
    public class QueryApplicationIoCManager : BaseIoCManager<IQueryApplication>
    {
        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "QueryApplication";

        public IQueryApplication GetCurrentIQueryApplicationImplementation()
        {
            return base.GetCurrentImplementation(_currentImplementation);
        }
    }
}
