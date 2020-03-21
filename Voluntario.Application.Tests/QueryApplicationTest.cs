using System;
using System.Collections.Generic;
using System.Text;
using CentralSharedModel.Interfaces;
using NUnit.Framework;
using Voluntario.Application;
using Voluntario.Application.Persistence;
using Voluntario.Application.Query;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class QueryApplicationTest : IRequest
    {
        private string _requestId;
        private string connStr = "localhost";
        private string dataBase = "VoluntaryWorkManager";
        private string collection = "Voluntario";
        public string RequestId { get => _requestId; set => _requestId = value; }
        private IVoluntario _voluntario;

        private IList<IVoluntario> ListaAll()
        {
            IList<IVoluntario> obj = null;
            if (_voluntario == null)
                Setup();
            //Add
            //AddListVolunt();

            using (IQueryApplication qry = new IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                try
                {
                    qry.RequestId = _requestId;
                    int current = 1;
                    obj = qry.GetAllPaged(current);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return obj;
        }

        [SetUp]
        public void Setup()
        {
            _requestId = Guid.NewGuid().ToString();
            _voluntario = new IoCManager.Voluntario.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
            _voluntario.Cep = "11703680";
            _voluntario.Cpf = 31495307840;
            _voluntario.DataNascimento = "16/02/1982";
            _voluntario.Email = "teste1@gmail.com";
            _voluntario.Id = Guid.NewGuid().ToString();
            _voluntario.Nome = $"Teste : {Guid.NewGuid().ToString()}";
            _voluntario.Senha = "12345678";
            _voluntario.Telefone = "12323123";
        }

        private void AddListVolunt()
        {
            _requestId = Guid.NewGuid().ToString();
            for (int i = 0; i < 5; i++)
            {
                _voluntario = new IoCManager.Voluntario.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
                _voluntario.Cep = "11703680";
                _voluntario.Cpf = 31495307840;
                _voluntario.DataNascimento = "16/02/1982";
                _voluntario.Email = $"teste{i.ToString()}@gmail.com";
                _voluntario.Id = Guid.NewGuid().ToString();
                _voluntario.Nome = $"Teste : {Guid.NewGuid().ToString()}";
                _voluntario.Senha = "12345678";
                _voluntario.Telefone = "12323123";

                AddVoluntario();
                _voluntario = null;
            }
        }

        private void AddVoluntario()
        {
            IPersistenceApplication per = new IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);
            per.Voluntario = _voluntario;
            per.RequestId = _requestId;
            per.Add();
        }

        private void DeleteVoluntario()
        {
            IPersistenceApplication per = new IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);
            per.Voluntario = _voluntario;
            per.RequestId = _requestId;
            per.Delete();
        }


        [Test]
        public void GetByCpf()
        {
            IVoluntario obj = null;
            //if (_voluntario == null)
            //    Setup();
            //Add
            //AddVoluntario();
            Int64 cpf = ListaAll()[0].Cpf;

            using (IQueryApplication qry = new IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = _requestId;
                qry.Cpf = cpf;
                try
                {
                    obj = qry.GetByCpf();
                    //DeleteVoluntario();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
           

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }
              

        [Test]
        public void GetByEmail()
        {
            IVoluntario obj = null;
            //if (_voluntario == null)
            //    Setup();
            ////Add
            //AddVoluntario();
            string email = ListaAll()[0].Email;

            using (IQueryApplication qry = new IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = _requestId;
                qry.Email = email;
                try
                {
                    obj = qry.GetByEmail();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            //DeleteVoluntario();

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }

        [Test]
        public void GetById()
        {
            IVoluntario obj = null;
            //if (_voluntario == null)
            //    Setup();
            //Add
            //AddVoluntario();
            string id = ListaAll()[0].Id;

            using (IQueryApplication qry = new IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = _requestId;
                qry.VoluntarioId = id;
                try
                {
                    obj = qry.GetById();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            //DeleteVoluntario();

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }

        [Test]
        public void GetByName()
        {
            IList<IVoluntario> obj = null;
            //if (_voluntario == null)
            //    Setup();
            //Add
            //AddVoluntario();
            string nome = ListaAll()[0].Nome.Split(':')[0];

            using (IQueryApplication qry = new IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = _requestId;
                qry.VoluntarioName = nome;
                try
                {
                    obj = qry.GetByName();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            //DeleteVoluntario();

            Assert.IsNotNull(obj);
            Assert.GreaterOrEqual(obj.Count, 1);
            Assert.IsNotEmpty(obj[0].Id);
        }

        [Test]
        public void GetAll()
        {
            var obj = ListaAll();

            Assert.IsNotNull(obj);
            Assert.GreaterOrEqual(obj.Count, 1);
            Assert.IsNotEmpty(obj[0].Id);
        }


    }
}
