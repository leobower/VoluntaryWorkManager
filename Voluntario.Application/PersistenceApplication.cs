using CentralSharedModel.Interfaces;
using Cryptography;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application
{
    public class PersistenceApplication : IRequest, IDisposable, IPersistenceApplication
    {
        private Validations             _validations;
        private IRepositoryWriter       _repositoryWriter;
        private IVoluntarioPersistence  _voluntarioPersistence;
        private IVoluntarioValidations  _voluntarioValidations;
        private ICryptography _cryptography;
        private IVoluntarioQuery _query;
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        private IVoluntario _voluntario;
        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }

        private void InitializeObjects()
        {
            if (_voluntario != null && !String.IsNullOrEmpty(RequestId))
            {
               

                if (_cryptography == null)
                    _cryptography = new IoCManager.Cryptography.CryptographyIoCManager().GetICryptographyCurrentImplementation();

                if (_validations == null)
                    _validations = new Validations(RequestId);

                if (_repositoryWriter == null)
                {
                    _repositoryWriter = new IoCManager.Voluntario.Data.Repository.RepositoryWriterIoCManager().GetIMongoRepositoryWriterCurrentImplementation();
                    _repositoryWriter.RequestId = this.RequestId;
                    _repositoryWriter.ConnStr = "localhost";///TODO
                    _repositoryWriter.DataBase = "VoluntaryWorkManager";///TODO
                    _repositoryWriter.CollectionName = "Voluntario";///TODO
                }

                if (_voluntarioValidations == null)
                {
                    _voluntarioValidations = new IoCManager.Voluntario.Business.VoluntarioValidationsIocManager().GetCurrentIVoluntarioValidationsImplementation();
                    _voluntarioValidations.LengthValidator.Volunt = _voluntario;
                    _voluntarioValidations.Voluntario = _voluntario;
                    _voluntarioValidations.ValidaCEP = (a) => _validations.CepValidator.ValidateCep(_voluntario.Cep);
                    _voluntarioValidations.ValidaCPF = (a) => _validations.CpfValidator.ValidateCPF(_voluntario.Cpf.ToString());
                    _voluntarioValidations.ValidaEmail = (a) => _validations.EmailValidator.IsValidEmail(_voluntario.Email);
                }

                if (_voluntarioPersistence == null)
                {
                    _voluntarioPersistence = new IoCManager.Voluntario.Business.VoluntarioPersistenceIocManager().GetCurrentIVoluntarioPersitenceImplementation();
                    _voluntarioPersistence.VoluntarioValidations = _voluntarioValidations;
                    _voluntarioPersistence.Voluntario = _voluntario;
                    _voluntarioPersistence.Encrypt = (a) => _cryptography.Encrypt(_voluntario.Senha);
                    _voluntarioPersistence.Insert = (a) => _repositoryWriter.Add(_voluntario);
                    _voluntarioPersistence.Update = (a) => _repositoryWriter.Update(_voluntario);
                    _voluntarioPersistence.Delete = (a) => _repositoryWriter.Delete(_voluntario);

                }
                if (_query == null)
                {
                    _query = new IoCManager.Voluntario.Business.VoluntarioQueryIocManager().GetCurrentIVoluntarioQueryImplementation();
                    _voluntarioPersistence.ExistsCPF = (a) => _query.ByCpf(_voluntario.Cpf);
                    _voluntarioPersistence.ExistsEmail = (a) => _query.ByEmail(_voluntario.Email);

                }
            }
            else
            {
                throw new Exception("Povide Values for the Voluntario and RequestId Properties.");
            }

        }

        public PersistenceApplication()
        {

        }

        //public PersistenceApplication(IVoluntario voluntario, string requestId)
        //{
        //    RequestId = requestId;
        //    if (voluntario != null)
        //    {
        //        _voluntario = voluntario;
        //        InitializeObjects();
        //    }

        //}

        public void Add()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                InitializeObjects();
                _voluntarioPersistence.InsertVoluntario();
            }
           
        }

        public void Update()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                InitializeObjects();
                _voluntarioPersistence.UpdateVoluntario();
            }
        }

        public void Delete()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                InitializeObjects();
                _voluntarioPersistence.DeleteVoluntario();
            }
        }

        public void Dispose()
        {
            _validations = null;
            _repositoryWriter = null;
            _voluntarioPersistence = null;
            _voluntarioValidations = null;
        }
    }
}


   
