using System;
using System.Collections.Generic;
using System.Text;

namespace EnviromentVariablesManager.Domain.Model
{
    public enum Environments
    {
        DEV = 0,
        HML = 1,
        PRD = 2
    }
    public abstract class BaseClass
    {
        public Environments Environment { get; set; }
        public int Port { get; set; }
    }
}
