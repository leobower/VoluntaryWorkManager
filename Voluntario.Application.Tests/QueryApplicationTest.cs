using System;
using System.Collections.Generic;
using System.Text;
using CentralSharedModel.Interfaces;
using NUnit.Framework;
using Voluntario.Application;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class QueryApplicationTest : IRequest
    {
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }
        private IVoluntario _voluntario;

        [SetUp]
        public void Setup()
        {
            _requestId = Guid.NewGuid().ToString();
            _voluntario = new IoCManager.Voluntario.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
            _voluntario.Cep = "11703680";
            _voluntario.Cpf = 12753272069;
            _voluntario.DataNascimento = "16/02/1982";
            _voluntario.Email = "teste1@gmail.com";
            _voluntario.Id = Guid.NewGuid().ToString();
            _voluntario.Nome = $"Teste : {Guid.NewGuid().ToString()}";
            _voluntario.Senha = "Senha";
            _voluntario.Telefone = "12323123";
        }


        [Test]
        public void GetByCpf()
        {
            IVoluntario obj = null;
            if (_voluntario == null)
                Setup();
            //Add
            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Add();
            }

            using (QueryApplication qry = new QueryApplication(_requestId))
            {
                qry.Cpf = _voluntario.Cpf;
                try
                {
                    obj = qry.GetByCpf();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Delete();
            }

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }

        [Test]
        public void GetByEmail()
        {
            IVoluntario obj = null;
            if (_voluntario == null)
                Setup();
            //Add
            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Add();
            }

            using (QueryApplication qry = new QueryApplication(_requestId))
            {
                qry.Email = _voluntario.Email;
                try
                {
                    obj = qry.GetByEmail();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Delete();
            }

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }

        [Test]
        public void GetById()
        {
            IVoluntario obj = null;
            if (_voluntario == null)
                Setup();
            //Add
            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Add();
            }

            using (QueryApplication qry = new QueryApplication(_requestId))
            {
                qry.VoluntarioId = _voluntario.Id;
                try
                {
                    obj = qry.GetById();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Delete();
            }

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }

        [Test]
        public void GetByName()
        {
            IList<IVoluntario> obj = null;
            if (_voluntario == null)
                Setup();
            //Add
            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Add();
            }

            using (QueryApplication qry = new QueryApplication(_requestId))
            {
                qry.VoluntarioName = _voluntario.Nome;
                try
                {
                    obj = qry.GetByName();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Delete();
            }

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj[0].Id);
        }


    }
}
