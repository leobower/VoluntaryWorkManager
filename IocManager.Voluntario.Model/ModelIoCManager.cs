using CrossCutting.IoCManager.BaseClasses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.IoCManager.Model
{
    public class ModelIoCManager :BaseIoCManager<IVoluntario>
    {
        public ModelIoCManager(IConfiguration conf) : base(conf) { }
        public IVoluntario GetIVoluntarioCurrentImplementation(string current = null)
        {
            return base.GetCurrentImplementation(current);
        }
    }
}
