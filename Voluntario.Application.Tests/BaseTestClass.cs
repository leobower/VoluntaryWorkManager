using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Voluntario.Domain.Entities.Interfaces;
using Voluntario.SerializationManager;

namespace Voluntario.Application.Tests
{
    public abstract class BaseTestClass
    {
        private Int64 GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return Int64.Parse(semente);
        }

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
            _voluntario = new Voluntario.IoCManager.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();
            _voluntario.Cep = "11703680";
            _voluntario.Cpf = GerarCpf();
            _voluntario.DataNascimento = "16/02/1982";
            _voluntario.Email = $"le.ribeiro.vca.{new Random().Next(0,500)}@gmail.com";
            _voluntario.Id = Guid.NewGuid().ToString();
            _voluntario.Nome = $"Teste : {_voluntario.Id}";
            _voluntario.Senha = "12345678";
            _voluntario.Telefone = "12323123";
            _voluntario.AreasInteresse = new List<string>() { "teste01", "teste02" };
           // _voluntario.Foto = new byte[] { 0, 1, 33 };
        }

        public string GetVoluntarioSerialized()
        {
            ICentralSerializationManager<IVoluntario> serializer = new Voluntario.IoCManager.SerializationManager.SerializationIoCManager().GetJSonCurrentImplementation();
            return serializer.Serialize(_voluntario);

        }

    }
}
