using Cryptography;
using EnviromentVariablesManager.Domain.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace EnviromentVariablesManager.Domain.Data
{
    public class Repository : IDisposable
    {
        private Context _dbContext;

        public Repository()
        {
            _dbContext = new Context();
        }

        public void Add(IDataBaseVariables variable)
        {
            //TODO
            CustomCrypto crypto = new CustomCrypto();
            variable.ConnectionString = crypto.Encrypt(variable.ConnectionString);
            _dbContext.VariableCollection.InsertOne(variable);
        }

        public void Delete(IDataBaseVariables variable)
        {
            var filter = Builders<IDataBaseVariables>.Filter.Eq("Enviroment", variable.Environment);//Where(x => x.Id == voluntario.Id);
                                                                                    // var update = Builders<IVoluntario>.Update. Set(filter, voluntario);
            _dbContext.VariableCollection.DeleteOne(filter);
        }

        public void Update (IDataBaseVariables variable)
        {
            var filter = Builders<IDataBaseVariables>.Filter.Eq("Enviroment", variable.Environment);//Where(x => x.Id == voluntario.Id);
                                                                                    // var update = Builders<IVoluntario>.Update. Set(filter, voluntario);
            _dbContext.VariableCollection.ReplaceOne(filter, variable);
        }

        public IDataBaseVariables GetByEnviroment(Environments environment)
        {
            IDataBaseVariables ret = null;
            var filter = Builders<IDataBaseVariables>.Filter.Eq("Enviroment", (int)environment);

            return ret;
        }
        public void Dispose()
        {
            _dbContext = null;
        }
    }
}
