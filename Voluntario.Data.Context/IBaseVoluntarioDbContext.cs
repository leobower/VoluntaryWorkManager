using System;
using System.Collections.Generic;
using System.Text;

namespace Voluntario.Data.Context
{
    public interface IBaseVoluntarioDbContext<D,I> : IDisposable
    {
        string Server { get; set; }
        int Port { get; set; }
        string DataBaseName { get; set; }
        string UserName { get; set; }
        string Pass { get; set; }
        string CollectionName { get; set; }
        D VoluntarioDataBase { get; set; }
        I VoluntarioCollection { get; set; }
    }
}
