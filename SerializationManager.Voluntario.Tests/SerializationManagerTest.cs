using NUnit.Framework;
using SerializationManager.Voluntario;
using System;
using Voluntario.Domain.Entities.Interfaces;

namespace SerializationManager.Voluntario.Tests
{
    public class SerializationManagerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SerializeTest()
        {
            try
            {
                IVoluntario voluntario = new IoCManager.Voluntario.Model.ModelIoCManager().GetIVoluntarioCurrentImplementation();

                voluntario.Cep = "11703680";
                voluntario.Cpf = 31495307840;
                voluntario.DataNascimento = "16/02/1982";
                voluntario.Email = "le.ribeiro.vca@gmail.com";
                voluntario.Id = Guid.NewGuid();
                voluntario.Nome = "Leandro Figueiredo Silva Ribeiro";
                voluntario.Senha = "Senha";
                voluntario.Telefone = "12323123";

                ICentralSerializationManager<IVoluntario> ser = new IoCManager.SerializationManager.Voluntario.SerializationIoCManager().GetISerializationCurrentImplementation();

                string message = ser.Serialize(voluntario);
                Assert.IsNotNull(message);
                Assert.IsNotEmpty(message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}