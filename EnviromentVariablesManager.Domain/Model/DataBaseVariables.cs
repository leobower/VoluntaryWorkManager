using System;
using System.Collections.Generic;
using System.Text;

namespace EnviromentVariablesManager.Domain.Model
{
    public class DataBaseVariables : BaseClass, IDataBaseVariables
    {
        private int _enviroment;
        private string _connectionString;
        private string _serverName;
        private string _dataBaseName;
        private string _collectionName;

        public int Environment { get => (int)base.Environment; set => _enviroment = (int)base.Environment; }
        
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }
        public string ServerName { get => _serverName; set => _serverName = value; }
        public string DataBaseName { get => _dataBaseName; set => _dataBaseName = value; }
        public string CollectionName { get => _collectionName; set => _collectionName = value; }
    }
}
