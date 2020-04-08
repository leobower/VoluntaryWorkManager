using CrossCutting.IoCManager.BaseClasses;
using Voluntario.Application.Persistence;

namespace CrossCutting.IoCManager.Voluntario.Application.Persistence
{
    public class PersistenceApplicationIoCManager : BaseIoCManager<IPersistenceApplication>
    {
        /// <summary>
        /// TODO
        /// Be Flexible
        /// </summary>
        private readonly string _currentImplementation = "PersistenceApplication";

        //public IPersistenceApplication GetCurrentIPersistenceApplicationImplementation()
        //{
        //    return base.GetCurrentImplementation(_currentImplementation);
        //}

        public IPersistenceApplication GetCurrentIPersistenceApplicationImplementation(string connStr, string database, string collectionName)
        {
            object[] arrParams = new object[] { connStr, database , collectionName};
            return base.GetCurrentImplementationWithParameters(_currentImplementation, arrParams);
        }       
    }
}
