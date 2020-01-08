using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnviromentVariablesManager.Domain.Model
{
    public interface IDataBaseVariables
    {
        [BsonId]
        int Environment  { get; set; }
        string ConnectionString { get; set; }
        int Port { get; set; }
        string ServerName { get; set; }
        string DataBaseName { get; set; }
        string CollectionName { get; set; }
    }
}
