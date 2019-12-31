using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application
{
    public class Persistence : IRequest, IDisposable
    {
        private Validations             _validations;
        private IRepositoryWriter       _repositoryWriter;
        private IVoluntarioPersistence  _voluntarioPersistence;
        private IVoluntarioValidations  _voluntarioValidations;
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        private IVoluntario _voluntario;

        private void InitializeObjects()
        {
            _validations = new Validations(RequestId);

            _repositoryWriter = new IoCManager.Voluntario.Data.Repository.RepositoryIoCManager().GetIMongoRepositoryCurrentImplementation();
            _repositoryWriter.RequestId = this.RequestId;
            _repositoryWriter.ConnStr = "localhost";///TODO
            _repositoryWriter.DataBase = "VoluntaryWorkManager";///TODO
            _repositoryWriter.CollectionName = "Voluntario";///TODO

            _voluntarioPersistence = new IoCManager.Voluntario.Business.VoluntarioPersistenceIocManager().GetCurrentIVoluntarioPersitenceImplementation();

            _voluntarioValidations = new IoCManager.Voluntario.Business.VoluntarioValidationsIocManager().GetCurrentIVoluntarioValidationsImplementation();
            _voluntarioValidations.ValidaCEP = (a) => _validations.CepValidator.ValidateCep(_voluntario.Cep);
            _voluntarioValidations.ValidaCPF = (a) => _validations.CpfValidator.ValidateCPF(_voluntario.Cpf.ToString());
            _voluntarioValidations.ValidaEmail = (a) => _validations.EmailValidator.IsValidEmail(_voluntario.Email);

            _voluntarioPersistence.VoluntarioValidations = _voluntarioValidations;
            _voluntarioPersistence.Voluntario = _voluntario;
            _voluntarioPersistence.Insert = (a) => _repositoryWriter.Add(_voluntario);
            _voluntarioPersistence.Update = (a) => _repositoryWriter.Update(_voluntario);
            _voluntarioPersistence.Delete = (a) => _repositoryWriter.Delete(_voluntario);


        }

        public Persistence(IVoluntario voluntario, string requestId)
        {
            RequestId = requestId;
            if (voluntario != null)
            {
                _voluntario = voluntario;
                InitializeObjects();
            }

        }

        public void Add()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                _voluntarioPersistence.InsertVoluntario();
            }
           
        }

        public void Update()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                _voluntarioPersistence.UpdateVoluntario();
            }
        }

        public void Delete()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
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


   
