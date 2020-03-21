using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Context.LiteDB
{
    public interface IVoluntarioLiteDbContext : IBaseVoluntarioDbContext
    {
        LiteDatabase VoluntarioDataBase { get; set; }
        ILiteCollection<IVoluntario> VoluntarioCollection { get; set; }
        string CollectionName { get; set; }
    }
}
