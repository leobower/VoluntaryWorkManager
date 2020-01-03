using CentralSharedModel.Interfaces;
using NUnit.Framework;
using System;
using Voluntario.Application;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class PersistenceApplicationTest : IRequest
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
            _voluntario.Cpf = 31495307840;
            _voluntario.DataNascimento = "16/02/1982";
            _voluntario.Email = "le.ribeiro.vca@gmail.com";
            _voluntario.Id = Guid.NewGuid().ToString();
            _voluntario.Nome = $"Teste : {Guid.NewGuid().ToString()}";
            _voluntario.Senha = "Senha";
            _voluntario.Telefone = "12323123";
        }

        [Test]
        public void AddTest()
        {
            if (_voluntario == null)
                Setup();

            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Add();
            }
        }

        [Test]
        public void UpdateTest()
        {
            AddTest();
            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                _voluntario.Email = "leandro_vca@hotmail.com";
                per.Update();
            }
        }

        [Test]
        public void DeleteTest()
        {
            AddTest();
            using (PersistenceApplication per = new PersistenceApplication(_voluntario, _requestId))
            {
                per.Delete();
            }
        }

    }
}