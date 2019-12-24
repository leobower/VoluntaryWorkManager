using CentralSharedModel.Interfaces;
using NUnit.Framework;
using System;
using Voluntario.Application;
using Voluntario.Domain.Entities.Interfaces;

namespace Tests
{
    public class ApplicationTest : IRequest
    {
        private string _requestId;
        public string RequestId { get => _requestId; set => _requestId = value; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddTest()
        {
            IVoluntario voluntario = new IoCManager.Voluntario.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
            _requestId = Guid.NewGuid().ToString();

            voluntario.Cep = "11703680";
            voluntario.Cpf = 31495307840;
            voluntario.DataNascimento = "16/02/1982";
            voluntario.Email = "le.ribeiro.vca@gmail.com";
            voluntario.Id = Guid.NewGuid();
            voluntario.Nome = "Leandro Figueiredo Silva Ribeiro";
            voluntario.Senha = "Senha";
            voluntario.Telefone = "12323123";

            using (Persistence per = new Persistence(voluntario, _requestId))
            {
                per.Add();
            }
        }
    }
}