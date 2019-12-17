﻿using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Data.Context;
using IoCManager.Voluntario.Data.Context;

namespace Voluntario.Data.Repository.Implementations
{
    public class MongoRepositoryWriter : IRepositoryWriter
    {
        private readonly IMongoDbContext _context;

        private string _connStr;
        private string _dataBase;
        private string _collectionName;

        public string ConnStr { get => _connStr; set => _connStr = value; }
        public string DataBase { get => _dataBase; set => _dataBase = value; }
        public string CollectionName { get => _collectionName; set => _collectionName = value; }

        private bool ValidateProperties()
        {
            return (!String.IsNullOrEmpty(_connStr) &&
                    !String.IsNullOrEmpty(_dataBase) &&
                    !String.IsNullOrEmpty(_collectionName)
                   );

        }

        public MongoRepositoryWriter()
        {
            if (_context == null)
                _context = new IoCManager.Voluntario.Data.Context.ContextIoCManager().GetIMongoContextCurrentImplementation();
        }


        void IRepositoryWriter.Add<T>(T voluntario)
        {
            if (ValidateProperties())
            {
                _context.ConnStr = _connStr;
                _context.DataBase = _dataBase;
                _context.CollectionName = _collectionName;

                _context.VoluntarioCollection.InsertOne(voluntario);
            }
        }

        void IRepositoryWriter.Delete<T>(T voluntario)
        {
            if (ValidateProperties())
            {
                _context.ConnStr = _connStr;
                _context.DataBase = _dataBase;
                _context.CollectionName = _collectionName;

                //_context.VoluntarioCollection.DeleteOne()
            }
        }

        void IRepositoryWriter.Update<T>(T voluntario)
        {
            if (ValidateProperties())
            {
                _context.ConnStr = _connStr;
                _context.DataBase = _dataBase;
                _context.CollectionName = _collectionName;

                //_context.VoluntarioCollection.DeleteOne()
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
