using System;
using System.Collections.Generic;
using System.Text;

namespace Voluntario.Data.Context
{
    public interface IBaseVoluntarioDbContext : IDisposable
    {
        string Server { get; set; }
        int Port { get; set; }
        string DataBaseName { get; set; }
        string UserName { get; set; }
        string Pass { get; set; }

        //string ToString();
            
    }
}
