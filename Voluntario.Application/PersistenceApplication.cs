﻿using Cryptography;
using System;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.Application.BaseClasses;
using Voluntario.Application.Query;
using Voluntario.SerializationManager;
using Microsoft.Extensions.Configuration;

namespace Voluntario.Application.Persistence
{
    public class PersistenceApplication : Validations, IDisposable, IPersistenceApplication
    {
        #region Fields
        private IRepositoryWriter _repositoryWriter;
        private IVoluntarioPersistence _voluntarioPersistence;
        private IVoluntarioValidations _voluntarioValidations;
        private ICryptography _cryptography;
        private IQueryApplication _query;
        private ICentralSerializationManager<IVoluntario> _serializer;
        private IVoluntario _voluntario;
        private readonly IConfiguration _conf;
        #endregion

        #region Props
        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }

        public string VoluntarioSerialized
        {
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _serializer = new CrossCutting.IoCManager.Voluntario.SerializationManager.SerializationIoCManager(_conf).GetJSonCurrentImplementation();
                    Voluntario = _serializer.Deserialize(value);
                }
            }
        }
        #endregion

        #region private methods
        private void InitializeObjects()
        {
            if (_voluntario != null && !String.IsNullOrEmpty(RequestId))
            {
                if (_cryptography == null)
                    _cryptography = new CrossCutting.IoCManager.Cryptography.CryptographyIoCManager(_conf).GetICryptographyCurrentImplementation();

                if (_voluntarioValidations == null)
                {
                    _voluntarioValidations = new Voluntario.IoCManager.Business.VoluntarioValidationsIocManager(_conf).GetCurrentIVoluntarioValidationsImplementation();
                    _voluntarioValidations.LengthValidator.Volunt = _voluntario;
                    _voluntarioValidations.Voluntario = _voluntario;
                    _voluntarioValidations.ValidaCEP = (a) => base.CepValidator.ValidateCep(_voluntario.Cep);
                    _voluntarioValidations.ValidaCPF = (a) => base.CpfValidator.ValidateCPF(_voluntario.Cpf.ToString());
                    _voluntarioValidations.ValidaEmail = (a) => base.EmailValidator.IsValidEmail(_voluntario.Email);
                }

                if (_voluntarioPersistence == null)
                {
                    _voluntarioPersistence = new Voluntario.IoCManager.Business.VoluntarioPersistenceIocManager(_conf).GetCurrentIVoluntarioPersitenceImplementation();
                    _voluntarioPersistence.VoluntarioValidations = _voluntarioValidations;
                    _voluntarioPersistence.Voluntario = _voluntario;
                    _voluntarioPersistence.Encrypt = (a) => _cryptography.Encrypt(_voluntario.Senha);
                    _voluntarioPersistence.Insert = (a) => _repositoryWriter.Add(_voluntario);
                    _voluntarioPersistence.Update = (a) => _repositoryWriter.Update(_voluntario);
                    _voluntarioPersistence.Delete = (a) => _repositoryWriter.Delete(_voluntario);

                }
                if (_query != null)
                {
                    _query.Cpf = _voluntario.Cpf;
                    _query.Email = _voluntario.Email;
                    _query.RequestId = base.RequestId;
                    _voluntarioPersistence.ExistsCPF = (a) => _query.GetByCpf();
                    _voluntarioPersistence.ExistsEmail = (a) => _query.GetByEmail();

                }
                _repositoryWriter.RequestId = this.RequestId;

            }
            else
            {
                throw new Exception("Povide Values for the Voluntario and RequestId Properties.");
            }

        }
        #endregion

        public PersistenceApplication(IConfiguration conf) : base(conf)
        {

            _conf = conf;
            string connStr = _conf["ConnectionString"]; string database = _conf["DataBaseName"]; string collectionName = _conf["CollectionName"];
            if (_repositoryWriter == null)
            {
                _repositoryWriter = new Voluntario.IoCManager.Data.Repository.RepositoryWriterIoCManager(_conf).GetIRepositoryWriterCurrentImplementation(database, collectionName);
                _repositoryWriter.RequestId = this.RequestId;
            }
            if (_query == null)
            {
                _query = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager(_conf).GetCurrentIQueryApplicationImplementation(_repositoryWriter.ContextObj);

            }
        }

        #region public methods
        public void Add()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_repositoryWriter)
                {
                    InitializeObjects();
                    try
                    {
                        _voluntarioPersistence.InsertVoluntario();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

            }

        }

        public void Update()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_repositoryWriter)
                {
                    InitializeObjects();
                    _voluntarioPersistence.UpdateVoluntario();
                }
            }
        }

        public void Delete()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager(_conf).GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_repositoryWriter)
                {
                    InitializeObjects();
                    _voluntarioPersistence.DeleteVoluntario();
                }
            }
        }

        public void Dispose()
        {
            _repositoryWriter.Dispose();
            _voluntarioPersistence = null;
            _voluntarioValidations = null;
        }
        #endregion

    }
}


   
