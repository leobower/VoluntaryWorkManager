using LiteDB;
using System;
using System.IO;
using System.Reflection;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Data.Context.LiteDb
{
    public class VoluntarioLiteDbContext : IBaseVoluntarioDbContext<LiteDatabase, ILiteCollection<IVoluntario>>  //IVoluntarioLiteDbContext
    {
        private string _server;
        private int _port;
        private string _dataBaseName;
        private string _userName;
        private string _pass;
        private string _collectionName;

        public string Server { get => _server; set => _server = value; }
        public int Port { get => _port; set => _port = value; }
        public string DataBaseName { get => _dataBaseName; set => _dataBaseName = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Pass { get => _pass; set => _pass = value; }

        public LiteDatabase VoluntarioDataBase { get; set; }
        public ILiteCollection<IVoluntario> VoluntarioCollection { get; set; }
        public string CollectionName { get => _collectionName; set => _collectionName = value; }
       

        public VoluntarioLiteDbContext(string dataBaseName, string collectionName)
        {
            DataBaseName = dataBaseName;
            if(VoluntarioDataBase == null)
            {
                try
                {
                    string fullName = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), DataBaseName);
                    VoluntarioDataBase = new LiteDatabase(fullName);
                   //Environment.  DataBaseName);
                    VoluntarioCollection = VoluntarioDataBase.GetCollection<IVoluntario>(collectionName);
                    CollectionName = collectionName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        public void Dispose()
        {
            VoluntarioDataBase.Dispose();
            VoluntarioCollection = null;
        }
    }
}
