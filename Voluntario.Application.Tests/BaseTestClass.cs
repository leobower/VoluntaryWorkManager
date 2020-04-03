using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;

namespace Voluntario.Application.Tests
{
    public abstract class BaseTestClass
    {
        private IVoluntario _voluntario;
        private string _requestId;
        //"localhost", "VoluntaryWorkManager", "Voluntario"
        protected string connStr { get => "localhost"; }
        protected string dataBase { get => "VoluntaryWorkManager_TestPersistence"; }
        protected string collection { get => "Voluntario"; }


        public string RequestId { get => _requestId; set => _requestId = value; }
        protected IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }

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

    }
}
