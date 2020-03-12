using CentralSharedModel.Interfaces;
using Cryptography;
using System;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.Application.BaseClasses;
using Voluntario.Application.Query;

namespace Voluntario.Application.Persistence
{
    public class PersistenceApplication : Validations, IDisposable, IPersistenceApplication
    {
       // private Validations             _validations;
        private IRepositoryWriter       _repositoryWriter;
        private IVoluntarioPersistence  _voluntarioPersistence;
        private IVoluntarioValidations  _voluntarioValidations;
        private ICryptography _cryptography;
        private IQueryApplication _query;
        private string _requestId;

        private IVoluntario _voluntario;
        public IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }

        private void InitializeObjects()
        {
            if (_voluntario != null && !String.IsNullOrEmpty(RequestId))
            {
                if (_cryptography == null)
                    _cryptography = new IoCManager.Cryptography.CryptographyIoCManager().GetICryptographyCurrentImplementation();

                //if (_validations == null)
                //    _validations = new Validations(RequestId);

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
                    _voluntarioValidations.ValidaCEP = (a) => base.CepValidator.ValidateCep(_voluntario.Cep);
                    _voluntarioValidations.ValidaCPF = (a) => base.CpfValidator.ValidateCPF(_voluntario.Cpf.ToString());
                    _voluntarioValidations.ValidaEmail = (a) => base.EmailValidator.IsValidEmail(_voluntario.Email);
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
                    _query = new IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation();
                    _query.Cpf = _voluntario.Cpf;
                    _query.Email = _voluntario.Email;
                    _voluntarioPersistence.ExistsCPF = (a) => _query.GetByCpf();//  ByCpf(_voluntario.Cpf);
                    _voluntarioPersistence.ExistsEmail = (a) => _query.GetByEmail();

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
            _repositoryWriter = null;
            _voluntarioPersistence = null;
            _voluntarioValidations = null;
        }
    }
}


   
