using CentralSharedModel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Data.Repository.Interfaces;
using Voluntario.Domain.BusinessRules.Interfaces;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application
{
    public class QueryApplication : IRequest, IDisposable
    {
        private string _requestId;
        private Int64 _cpf;
        private string _email;
        private string _id;
        private string name;
        private int _currentPage;
        private double _totalPages;

        public string RequestId { get => _requestId; set => _requestId = value; }
        public long Cpf { get => _cpf; set => _cpf = value; }
        public string VoluntarioId { get => _id; set => _id = value; }
        public string VoluntarioName { get => name; set => name = value; }
        public string Email { get => _email; set => _email = value; }
        public int CurrentPage { get => _currentPage; set => _currentPage = value; }
        public double TotalPages { get => _totalPages; set => _totalPages = value; }

        private IRepositoryQuery _query;
        private IVoluntarioQuery _voluntarioQuery;
        private Validations _validations;
        private IVoluntarioValidations _voluntarioValidations;


        private void InitializeObjects()
        {
            _voluntarioQuery = new IoCManager.Voluntario.Business.VoluntarioQueryIocManager().GetCurrentIVoluntarioQueryImplementation();
            _query = new IoCManager.Voluntario.Data.Repository.RepositoryQueryIoCManager().GetIMongoRepositoryQueryCurrentImplementation();
            _voluntarioValidations = new IoCManager.Voluntario.Business.VoluntarioValidationsIocManager().GetCurrentIVoluntarioValidationsImplementation();
            _validations = new Validations(RequestId);
            
            _query.ConnStr = "localhost";///TODO
            _query.DataBase = "VoluntaryWorkManager";///TODO
            _query.CollectionName = "Voluntario";///TODO

            _voluntarioQuery.ByCpf = (a) => _query.GetVoluntarioByCpf(Cpf);
            _voluntarioQuery.ByEmail = (a) => _query.GetVoluntarioByEmail(Email);
            _voluntarioQuery.ById = (a) => _query.GetVoluntarioById(VoluntarioId);
            _voluntarioQuery.ByName = (a) => _query.GetVoluntarioByName(VoluntarioName);
            _voluntarioQuery.SelectAllPaged = (a) => _query.GetListVoluntario(CurrentPage);

            //_voluntarioValidations.ValidaCEP = (a) => _validations.CepValidator.ValidateCep(Cep);
            _voluntarioValidations.ValidaCPF = (a) => _validations.CpfValidator.ValidateCPF(Cpf.ToString());
            _voluntarioValidations.ValidaEmail = (a) => _validations.EmailValidator.IsValidEmail(Email);

            _voluntarioQuery.VoluntarioValidations = _voluntarioValidations;

        }

        public QueryApplication(string requestId)
        {
            RequestId = requestId;
            InitializeObjects();
        }

        public IVoluntario GetById()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                _voluntarioQuery.Id = this.VoluntarioId;
                return _voluntarioQuery.GetById();
            }
        }

        public IVoluntario GetByCpf()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                _voluntarioQuery.Cpf = this.Cpf;
                return _voluntarioQuery.GetByCpf();
            }
        }

        public IVoluntario GetByEmail()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                _voluntarioQuery.Email = this.Email;
                return _voluntarioQuery.GetByEmail();
            }
        }

        public IList<IVoluntario> GetByName()
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                _voluntarioQuery.Name = this.VoluntarioName;
                return _voluntarioQuery.GetByName();
            }
        }

        public IList<IVoluntario> GetAllPaged(int currentPage)
        {
            using (var tracer = new IoCManager.CentralTrace.Business.Publisher.CentralTracerBusinessIoCManager().GetITraceBusinessCurrentImplementation(RequestId))
            {
                _voluntarioQuery.CurrentPage = currentPage;
                CurrentPage = currentPage;
                IList<IVoluntario> ret = null;
                ret = _voluntarioQuery.GetAll();
                TotalPages = _query.TotalPages;
                return ret;
            }
        }

        public void Dispose()
        {
            _validations = null;
            _query = null;
            _voluntarioQuery = null;
            _voluntarioValidations = null;
        }
    }
}
