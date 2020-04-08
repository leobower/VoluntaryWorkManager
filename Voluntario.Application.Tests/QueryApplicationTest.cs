using System;
using System.Collections.Generic;
using System.Text;
using CentralSharedModel.Interfaces;
using NUnit.Framework;
using Voluntario.Application;
using Voluntario.Application.Persistence;
using Voluntario.Application.Query;
using Voluntario.Application.Tests;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class QueryApplicationTest : BaseTestClass, IRequest
    {
       

        private IList<IVoluntario> ListaAll()
        {
            IList<IVoluntario> obj = null;
            if (Voluntario == null)
                Setup();
            //Add
            //AddListVolunt();

            using (IQueryApplication qry = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                try
                {
                    qry.RequestId = RequestId;
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

        private void AddListVolunt()
        {
            RequestId = Guid.NewGuid().ToString();
            for (int i = 0; i < 5; i++)
            {
                Voluntario = new Voluntario.IoCManager.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
                Voluntario.Cep = "11703680";
                Voluntario.Cpf = 31495307840;
                Voluntario.DataNascimento = "16/02/1982";
                Voluntario.Email = $"teste{i.ToString()}@gmail.com";
                Voluntario.Id = Guid.NewGuid().ToString();
                Voluntario.Nome = $"Teste : {Guid.NewGuid().ToString()}";
                Voluntario.Senha = "12345678";
                Voluntario.Telefone = "12323123";

                AddVoluntario();
                Voluntario = null;
            }
        }

        private void AddVoluntario()
        {
            IPersistenceApplication per = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);
            per.Voluntario = Voluntario;
            per.RequestId = RequestId;
            per.Add();
        }

        private void DeleteVoluntario()
        {
            IPersistenceApplication per = new CrossCutting.IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);
            per.Voluntario = Voluntario;
            per.RequestId = RequestId;
            per.Delete();
        }


        [Test]
        public void GetByCpf()
        {
            IVoluntario obj = null;
            Int64 cpf = ListaAll()[0].Cpf;

            using (IQueryApplication qry = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = RequestId;
                qry.Cpf = cpf;
                try
                {
                    obj = qry.GetByCpf();
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
            string email = ListaAll()[0].Email;

            using (IQueryApplication qry = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = RequestId;
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

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }

        [Test]
        public void GetById()
        {
            IVoluntario obj = null;
            string id = ListaAll()[0].Id;

            using (IQueryApplication qry = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = RequestId;
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

            Assert.IsNotNull(obj);
            Assert.IsNotEmpty(obj.Id);
        }

        [Test]
        public void GetByName()
        {
            IList<IVoluntario> obj = null;
            string nome = ListaAll()[0].Nome.Split(':')[0];

            using (IQueryApplication qry = new CrossCutting.IoCManager.Voluntario.Application.Query.QueryApplicationIoCManager().GetCurrentIQueryApplicationImplementation(connStr, dataBase, collection))
            {
                qry.RequestId = RequestId;
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
