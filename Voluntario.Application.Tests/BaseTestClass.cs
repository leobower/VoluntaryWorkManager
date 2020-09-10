using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
        protected string connStr { get; set;  }
        protected string dataBase { get; set;  }
        protected string collection { get; set;  }


        public string RequestId { get => _requestId; set => _requestId = value; }
        protected IVoluntario Voluntario { get => _voluntario; set => _voluntario = value; }

        protected IConfiguration Config { get; }

        public BaseTestClass()
        {
            var configurationBuilder = new ConfigurationBuilder();
            string path = "";
            path = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
            if (File.Exists(path))
            {
                configurationBuilder.AddJsonFile(path, false);
                var root = configurationBuilder.Build();
                Config = root;

                connStr = Config["ConnectionString"];
                dataBase = Config["DataBaseName"];
                collection = Config["CollectionName"];
            }
            else
            {
                throw new FileNotFoundException(path);
            }
        }


        [SetUp]
        public void Setup()
        {
            _requestId = Guid.NewGuid().ToString();
            _voluntario = new Voluntario.IoCManager.Model.ModelIoCManager(Config).GetIVoluntarioCurrentImplementation();
            _voluntario.Cep = "11703680";
            _voluntario.Cpf = GerarCpf();
            _voluntario.DataNascimento = "16/02/1982";
            _voluntario.Email = $"le.ribeiro.vca.{new Random().Next(0,1500)}@gmail.com";
            //_voluntario.Email = "test@test.com";
            _voluntario.Id = Guid.NewGuid().ToString();
            _voluntario.Nome = $"Teste : {_voluntario.Id}";
            _voluntario.Senha = "12345678";
            _voluntario.Telefone = "12323123";
            _voluntario.AreasInteresse = new List<string>() { "teste01", "teste02" };
            _voluntario.FotoBase64 = Convert.ToBase64String(new byte[] { 0, 1, 33,56,87,19 });
        }   

        public string GetVoluntarioSerialized()
        {
            ICentralSerializationManager<IVoluntario> serializer = new CrossCutting.IoCManager.Voluntario.SerializationManager.SerializationIoCManager(Config).GetJSonCurrentImplementation();
            return serializer.Serialize(_voluntario);

        }

    }
}
