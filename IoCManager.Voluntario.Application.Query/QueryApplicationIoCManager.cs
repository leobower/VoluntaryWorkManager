﻿using IoCManager.BaseClasses;
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

        public IQueryApplication GetCurrentIQueryApplicationImplementation(string connStr, string database, string collectionName)
        {
            object[] arrParams = new object[] { connStr, database, collectionName };
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }
    }
}
