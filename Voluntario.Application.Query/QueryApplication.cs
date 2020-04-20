using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using Voluntario.Application.BaseClasses;
using Voluntario.Data.Context.LiteDb;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application.Query
{
    public class QueryApplication : Validations,IRequest, IQueryApplication
    {
        //private string _requestId;
        private Int64 _cpf;
        private string _email;
        private string _id;
        private string name;
        private int _currentPage;
        private double _totalPages;
        private string _pass;

        //public string RequestId { get => _requestId; set => _requestId = value; }
        public long Cpf { get => _cpf; set => _cpf = value; }
        public string VoluntarioId { get => _id; set => _id = value; }
        public string VoluntarioName { get => name; set => name = value; }
        public string Email { get => _email; set => _email = value; }
        public int CurrentPage { get => _currentPage; set => _currentPage = value; }
        public double TotalPages { get => _totalPages; set => _totalPages = value; }
        public string Pass { get => _pass; set => _pass = value; }

        private IRepositoryQuery _queryRepository;
        private IVoluntarioQuery _voluntarioQuery;
        private IVoluntarioValidations _voluntarioValidations;


        private void InitializeObjects()
        {
            if (!String.IsNullOrEmpty(RequestId))
            {
                if (_voluntarioValidations == null)
                {
                    _voluntarioValidations = new Voluntario.IoCManager.Business.VoluntarioValidationsIocManager().GetCurrentIVoluntarioValidationsImplementation();
                    _voluntarioValidations.ValidaCPF = (a) => CpfValidator.ValidateCPF(Cpf.ToString());
                    _voluntarioValidations.ValidaEmail = (a) => EmailValidator.IsValidEmail(Email);

                }

                if (_voluntarioQuery == null)
                {
                    _voluntarioQuery = new Voluntario.IoCManager.Business.VoluntarioQueryIocManager().GetCurrentIVoluntarioQueryImplementation();
                    _voluntarioQuery.ByCpf = (a) => _queryRepository.GetVoluntarioByCpf(Cpf);
                    _voluntarioQuery.ByEmail = (a) => _queryRepository.GetVoluntarioByEmail(Email);
                    _voluntarioQuery.ById = (a) => _queryRepository.GetVoluntarioById(VoluntarioId);
                    _voluntarioQuery.ByName = (a) => _queryRepository.GetVoluntarioByName(VoluntarioName);
                    _voluntarioQuery.SelectAllPaged = (a) => _queryRepository.GetListVoluntario(CurrentPage);
                    _voluntarioQuery.VoluntarioValidations = _voluntarioValidations;
                }

                _queryRepository.RequestId = RequestId;
            }
            else
                throw new Exception("Provide value for the RequestId Property.");
        }

        public QueryApplication(string connStr, string database, string collectionName)
        {
            if (_queryRepository == null)
            {
                _queryRepository = new Voluntario.IoCManager.Data.Repository.RepositoryQueryIoCManager().GetIRepositoryQueryCurrentImplementation(database, collectionName);
                _queryRepository.RequestId = RequestId;
                _queryRepository.IsToDispose = true;
            }
        }

        public QueryApplication(object context)
        {
            if (_queryRepository == null)
            {
                _queryRepository = new Voluntario.IoCManager.Data.Repository.RepositoryQueryIoCManager().GetIRepositoryQueryCurrentImplementation(context);
                _queryRepository.RequestId = RequestId;
                _queryRepository.IsToDispose = false;
            }
        }

        public bool EmailLogIn()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_queryRepository)
                {
                    return _queryRepository.EmailLogIn(Email, Pass);
                }
            }
        }

        public IVoluntario GetById()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_queryRepository)
                {
                    InitializeObjects();
                    _voluntarioQuery.Id = this.VoluntarioId;
                    return _voluntarioQuery.GetById();
                }
            }
        }

        public IVoluntario GetByCpf()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_queryRepository)
                {
                    InitializeObjects();
                    _voluntarioQuery.Cpf = this.Cpf;
                    return _voluntarioQuery.GetByCpf();
                }
                
            }
        }

        public IVoluntario GetByEmail()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_queryRepository)
                {
                    InitializeObjects();
                    _voluntarioQuery.Email = this.Email;
                    return _voluntarioQuery.GetByEmail();
                }
            }
        }

        public IList<IVoluntario> GetByName()
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_queryRepository)
                {
                    InitializeObjects();
                    _voluntarioQuery.Name = this.VoluntarioName;
                    return _voluntarioQuery.GetByName();
                }
            }
        }

        public IList<IVoluntario> GetAllPaged(int currentPage)
        {
            using (var tracer = new CrossCutting.IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                using (_queryRepository)
                {
                    InitializeObjects();
                    _voluntarioQuery.CurrentPage = currentPage;
                    CurrentPage = currentPage;
                    IList<IVoluntario> ret = null;
                    ret = _voluntarioQuery.GetAll();
                    TotalPages = 10;// _query.TotalPages;
                    return ret;
                }
            }
        }

        public void Dispose()
        {
            _queryRepository.Dispose();
            _voluntarioQuery = null;
            _voluntarioValidations = null;
        }
    }
}
