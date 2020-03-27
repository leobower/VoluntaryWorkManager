using CentralSharedModel.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Voluntario.Application;
using Voluntario.Application.Persistence;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class PersistenceApplicationTest : IRequest
    {
        private string _requestId;
        //"localhost", "VoluntaryWorkManager", "Voluntario"
        private string connStr = "localhost";
        private string dataBase = "VoluntaryWorkManager_TestPersistence";
        private string collection = "Voluntario";


        public string RequestId { get => _requestId; set => _requestId = value; }

        private IVoluntario _voluntario;

        [SetUp]
        public void Setup()
        {
            _requestId = Guid.NewGuid().ToString();
            _voluntario = new IoCManager.Voluntario.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
            _voluntario.Cep = "11703680";
            _voluntario.Cpf = 22140614011;
            _voluntario.DataNascimento = "16/02/1982";
            _voluntario.Email = "le.ribeiro.vca1@gmail.com";
            _voluntario.Id = Guid.NewGuid().ToString();
            _voluntario.Nome = $"Teste : {Guid.NewGuid().ToString()}";
            _voluntario.Senha = "12345678";
            _voluntario.Telefone = "12323123";
            _voluntario.AreasInteresse = new List<string>() { "teste01", "teste02" };
            _voluntario.Foto = new byte[] { 0, 1, 33 };
        }

        [Test]
        public void AddTest()
        {
            if (_voluntario == null)
                Setup();
            IPersistenceApplication per = new IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);
            per.Voluntario = _voluntario;
            per.RequestId = _requestId;
            per.Add();
            
        }

        [Test]
        public void UpdateTest()
        {
            //AddTest();
            IPersistenceApplication per = new IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);
            per.Voluntario = _voluntario;
            per.RequestId = _requestId;

            _voluntario.Email = "leandro_vca@hotmail.com";
            per.Update();

        }

        [Test]
        public void DeleteTest()
        {
            //AddTest();
            IPersistenceApplication per = new IoCManager.Voluntario.Application.Persistence.PersistenceApplicationIoCManager().GetCurrentIPersistenceApplicationImplementation(connStr, dataBase, collection);
            per.Voluntario = _voluntario;
            per.RequestId = _requestId;
            per.Delete();
            
        }

    }
}