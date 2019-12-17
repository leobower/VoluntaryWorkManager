using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.Repository.Interfaces;

namespace Voluntario.Repository.Implementations
{
    public class MongoRepositoryWriter : IRepositoryWriter
    {

        private IMongo _provider;
        private IMongoDatabase _db { get { return this._provider.Database; } }
        public MongoRepository()
        {
            _provider = Mongo.Create(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        }

        public void Add<T>(T voluntario) where T : class, IVoluntario, new();
        {
           
        }

        public void IRepositoryWriter.Delete<T>(T voluntario)
        {
            throw new NotImplementedException();
        }

        public void IRepositoryWriter.Update<T>(T voluntario)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MongoRepositoryWriter()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
