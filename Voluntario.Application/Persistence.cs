using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application
{
    public class Persistence : IDisposable
    {
        private Validations             _validations;
        private IRepositoryWriter       _repositoryWriter;
        private IVoluntarioPersistence  _voluntarioPersistence;
        private IVoluntarioValidations  _voluntarioValidations;

        private IVoluntario _voluntario;

        private void InitializeObjects()
        {
            _validations = new Validations();

            _repositoryWriter = new IoCManager.Voluntario.Data.Repository.RepositoryIoCManager().GetIMongoRepositoryCurrentImplementation();
            _repositoryWriter.ConnStr = "";
            _repositoryWriter.DataBase = "";
            _repositoryWriter.CollectionName = "";

            _voluntarioPersistence = new IoCManager.Voluntario.Business.VoluntarioPersistenceIocManager().GetCurrentIVoluntarioPersitenceImplementation();

            _voluntarioValidations = new IoCManager.Voluntario.Business.VoluntarioValidationsIocManager().GetCurrentIVoluntarioValidationsImplementation();
            _voluntarioValidations.ValidaCEP = (a) => _validations.CepValidator.ValidateCep(_voluntario.Cep);
            _voluntarioValidations.ValidaCPF = (a) => _validations.CpfValidator.ValidateCPF(_voluntario.Cpf.ToString());
            _voluntarioValidations.ValidaEmail = (a) => _validations.EmailValidator.IsValidEmail(_voluntario.Email);

            _voluntarioPersistence.VoluntarioValidations = _voluntarioValidations;
            _voluntarioPersistence.Voluntario = _voluntario;
            _voluntarioPersistence.Insert = (a) => _repositoryWriter.Add(_voluntario);


        }

        public Persistence(IVoluntario voluntario)
        {
            if (voluntario != null)
            {
                _voluntario = voluntario;
                InitializeObjects();
            }

        }

        public void Add()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation())
            {
                _voluntarioPersistence.InsertVoluntario();
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


   
